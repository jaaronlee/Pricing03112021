using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pricing03112021.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace Pricing03112021
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("uwp=da2ff7be-656a-4ded-bde8-37ccd50d3381;" +
                  "android={Your Android App secret here}" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
