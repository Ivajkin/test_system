using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace test_application
{
    public abstract partial class Test : UserControl
    {
        public Test(Guid id, string glavaName, MainPage parent)
        {
            InitializeComponent();

            this.glavaName = glavaName;
            this.parent = parent;

            var databaseSilverlightServiceClient = new ServiceReference1.DatabaseSilverlightServiceClient();
            databaseSilverlightServiceClient.GetVoprForGlavCompleted += (e, ea) =>
                {
                    var r = new Random();
                    // Вопросы в случайном порядке
                    var sortedQuestions = ea.Result;
                    sortedQuestions.Shuffle();

                    int initialisedCount = sortedQuestions.Count();

                    questions = new QuestionState[sortedQuestions.Count()];
                    for (int i = 0; i < questions.Count(); ++i)
                    {
                        questions[i] = new QuestionState(sortedQuestions.ElementAt(i), () => { initialisedCount--; if (initialisedCount == 0) { selectQuestion(); } });
                    }
                    AfterInitialisation();
                };
            databaseSilverlightServiceClient.GetVoprForGlavAsync(id);


            close_button.Click += new RoutedEventHandler(close_button_Click);


            next_button.IsEnabled = false;
            next_button.Click += new RoutedEventHandler(next_button_Click);
        }

        protected abstract void AfterInitialisation();

        void next_button_Click(object sender, RoutedEventArgs e)
        {
            countScore();
            selectQuestion();
        }

        private void countScore()
        {
            int currentScore = 0;
            bool isFullyAnswered = true;
            foreach (CheckBox answerCheckBox in answersStackPanel.Children)
            {
                bool isCorrect = isAnswerCorrect(answerCheckBox),
                    isSelected = (bool)answerCheckBox.IsChecked;
                if (isCorrect)
                    if (isSelected)
                        ++currentScore;
                    else
                        isFullyAnswered = false;
                else
                    if (isSelected)
                        isFullyAnswered = false;
            }
            score += currentScore;
            if (isFullyAnswered)
            {
                ++answered;
            }
        }

        void close_button_Click(object sender, RoutedEventArgs e)
        {
            FinishTest();
        }

        protected readonly MainPage parent;
        protected QuestionState[] questions;
        protected class QuestionState
        {
            public QuestionState(ServiceReference1.Vopr vopr, Action func)
            {
                this.vopr = vopr;
                var databaseSilverlightServiceClient = new ServiceReference1.DatabaseSilverlightServiceClient();
                databaseSilverlightServiceClient.GetOtvetCompleted += (e, ea) =>
                {
                    // Ответы в случайном порядке
                    answers = ea.Result;
                    answers.Shuffle();

                    func();
                };
                databaseSilverlightServiceClient.GetOtvetAsync(vopr.ID_vopr);
            }
            public IList<ServiceReference1.Otv> answers;
            public readonly ServiceReference1.Vopr vopr;
        }
                
        protected void selectQuestion()
        {
            if (currentQuestion >= questions.Count())
            {
                FinishTest();
                return;
            }

            var question = questions[currentQuestion];
            questionTextBox.Text = question.vopr.Vopr1;

            answersStackPanel.Children.Clear();
            foreach (ServiceReference1.Otv otv in question.answers)
            {
                var answer_checkbox = new CheckBox();
                answer_checkbox.Content = otv.Otv1;
                //checkbox.Width = 240;
                //checkbox.Margin = new Thickness(10);
                if (otv.Bool == 1)
                {
                    setAnswerCorrect(answer_checkbox);
                }
                answer_checkbox.Click += (e, ea) =>
                {
                    next_button.IsEnabled = true;
                };
                answersStackPanel.Children.Add(answer_checkbox);
            }
            ++currentQuestion;

            //result_label.Visibility = System.Windows.Visibility.Collapsed;
        }
        int currentQuestion = 0;

        // Количество набранных балов(по одному за каждый вариант ответа), количество заданий и количество правильно решенных зданий соответственно
        // Название главы
        protected abstract void WriteStatistics(int Balls, int Tasks, int Answered, string Glava);

        protected void FinishTest()
        {
            var Tasks = questions.Count();
            WriteStatistics(score, Tasks, answered, glavaName);
            parent.Navigate(new ControlResult(answered, Tasks, score, parent));
        }

        protected bool isAnswerCorrect(ContentControl answer)
        {
            return 27 == answer.MaxHeight;
        }
        private void setAnswerCorrect(ContentControl answer)
        {
            answer.MaxHeight = 27;
        }

        // количество набранных балов(по одному за каждый вариант ответа)
        protected int score = 0;
        // количество правильно решенных зданий
        protected int answered = 0;

        private readonly string glavaName;
    }
}
