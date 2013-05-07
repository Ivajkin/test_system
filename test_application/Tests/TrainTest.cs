using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace test_application
{
    public class TrainTest : Test
    {
        public TrainTest(Guid id, string glavaName, MainPage parent)
            : base(id, glavaName, parent)
        {

            time_label_label.Visibility = time_label.Visibility = System.Windows.Visibility.Collapsed;
        }
        /*protected override void answer_button_Click(object sender, RoutedEventArgs e)
        {
            var answer = (Button)sender;

            if (isAnswerCorrect(answer))
            {
                ++correctAnswersCount;
                TrainSuccess(answer);
            }
            else
            {
                TrainFail(answer);
            }
            result_label.Visibility = next_button.Visibility = System.Windows.Visibility.Visible;
            foreach (UIElement elem in answersStackPanel.Children)
            {
                ((Button)elem).IsEnabled = false;
            }
        }*/

        /*void TrainSuccess(Button clicked)
        {
            result_label.Foreground = next_button.Background = clicked.Background = new SolidColorBrush(Colors.Green);
            result_label.Content = "Правильно!";
        }
        void TrainFail(Button clicked)
        {
            result_label.Foreground = next_button.Background = clicked.Background = new SolidColorBrush(Colors.Red);
            result_label.Content = "Неправильно!";
        }*/
        protected override void WriteStatistics(int Balls, int Tasks, int Answered, string Glava)
        {
        }
        protected override void AfterInitialisation()
        {
        }
    }
}
