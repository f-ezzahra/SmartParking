using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gp.Models;
using gp.Views;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login2 : ContentPage
    {
    

        public login2()
        {
            InitializeComponent();
        }
      

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new Admin
            {
                User = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);

            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new GestionLivreurs(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Nom ou mot de passe incorrecte !";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(Admin user)
        {
            return user.User == "admin" && user.Password == "admin";
        }

    }
}