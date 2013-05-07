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
    public class ControlTest : Test
    {
        public ControlTest(Guid id, string glavaName, MainPage parent)
            : base(id, glavaName, parent)
        {
        }

        protected override void AfterInitialisation()
        {
            time = 60 * questions.Length;

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0); // 1 секунда
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }

        void timer_tick(object sender, EventArgs e)
        {
            if (time < 15) time_label.Foreground = new SolidColorBrush(Colors.Red);
            time_label.Content = String.Format("{1} мин {0} сек", time % 60, (time - time % 60) / 60);
            --time;
            if (time < 1) FinishTest();
        }

        /*protected override void answer_button_Click(object sender, RoutedEventArgs e)
        {
            var answer = (Button)sender;

            if (isAnswerCorrect(answer))
            {
                ++correctAnswersCount;
            }
            selectQuestion();
        }*/

        // в Balls, Tasks, Answerd записываются количество набранных балов(по одному за каждый вариант ответа), количество заданий и количество правильно решенных зданий соответственно.Тип данных int
        // в Glava записывается азвание главы, по которой шло тестирование. Тип данных string.
        protected override void WriteStatistics(int Balls, int Tasks, int Answered, string Glava)
        {
            // по завершению контрольного тестирования в таблицу результатов записывается следующее:
            // в ID генерируется ключ
            var ID = Guid.NewGuid();
            // в Data записывается число и месяц (тип данных string а соответственно выглядеть будет примерно так: 19 марта)
            string Date = DateTime.Today.ToString("d MMM", new System.Globalization.CultureInfo("ru-RU")),
            // в Time записывается время окончания теста (тут тоже string, а соответственно записываем по форме чч:мм)
            Time = DateTime.Now.ToString("HH:mm");
            // в Computer и IP_address записываются имя кмпьютера и ип-адрес компьютера, на котором проводилось тестирование (тип данных string)
            ServiceReference1.DatabaseSilverlightServiceClient client = new ServiceReference1.DatabaseSilverlightServiceClient();
            client.GetDNSInfoCompleted += (e, ea) =>
            {
                string Computer = ea.Result.Computer,
                IP_address = ea.Result.IP_address;
                // Записываем в базу
                client.AddStatisticAsync(ID, Date, Time, Computer, IP_address, Balls, Tasks, Answered, Glava);
            };
            client.GetDNSInfoAsync();
        }

        private int time = -1;
    }
}
