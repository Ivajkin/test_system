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
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            
            var databaseSilverlightServiceClient = new ServiceReference1.DatabaseSilverlightServiceClient();
            databaseSilverlightServiceClient.GetTestDataCompleted += (e, ea) =>
            {
                // Узнаем текущую главу и режим тестирования, запускаем тест с этой главой в этом режиме
                if(ea.Result.isControlMode)
                    Navigate(new ControlTest(ea.Result.glavaID, ea.Result.glavaName, this));
                else
                    Navigate(new TrainTest(ea.Result.glavaID, ea.Result.glavaName, this));
            };
            databaseSilverlightServiceClient.GetTestDataAsync();
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        internal void NavigateHomepage()
        {
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://localhost:49641/"), "_self");
        }
    }
}
