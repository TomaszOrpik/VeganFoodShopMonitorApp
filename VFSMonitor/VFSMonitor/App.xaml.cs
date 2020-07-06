using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VFSMonitor
{
    public partial class App : Application
    {
        public static string url = "https://monitor-api-nine.now.sh";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.White,
                BarTextColor = Color.Green
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
