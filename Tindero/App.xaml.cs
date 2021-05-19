using Microsoft.Extensions.DependencyInjection;
using MonkeyCache.FileStore;
using System;
using Tindero.DI;
using Tindero.Views;
using Xamarin.Forms;

namespace Tindero
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = "TinderoApp";

            InitializeDI();

            MainPage = new StartupPage();
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

        private static void InitializeDI()
        {
            ServiceProvider =
                 new ServiceCollection()
                .RegisterServices()
                .BuildServiceProvider();
        }

    }
}
