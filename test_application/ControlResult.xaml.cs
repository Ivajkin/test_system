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
    public partial class ControlResult : UserControl
    {
        public ControlResult(int correctAnswersCount, int answerCount, int score, MainPage parent)
        {
            InitializeComponent();

            this.parent = parent;

            result_label.Content = "Вы ответили верно на " + correctAnswersCount + " вопроса из " + answerCount;
            result_label_2.Content = "Вы набрали " + score + " баллов";
        }

        private MainPage parent = null;
        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            parent.NavigateHomepage();
        }
    }
}
