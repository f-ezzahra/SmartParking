using gp.Models;
using Realms;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Nom ou mot de passe incorrecte !";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }
        private async void OnLoginButtonHome(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Home());
        }
        private async void OnSignUpAdminButtonClicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new login2());
        }
    }
}