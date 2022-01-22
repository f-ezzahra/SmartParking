using gp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using System.Diagnostics;
using Xamarin.Forms;


namespace gp
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            
            
             Push.PushNotificationReceived += (s, e) =>
             {
                 Debug.WriteLine("Notification Received!!!");
                 Debug.WriteLine($"Title: {e.Title}");
                 Debug.WriteLine($"Message: {e.Message}");
             };  


            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
            AppCenter.Start("f505ffaa-8708-4e92-a91a-ce42be038154", typeof(Push));

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
