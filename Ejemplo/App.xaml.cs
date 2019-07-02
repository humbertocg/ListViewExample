using System;
using Ejemplo.Services.Local;
using Ejemplo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejemplo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IoCContainer.Configure();

            MainPage = new NavigationPage(new ListViewEjemploView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
