using gp.Models;
using Realms;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private string nome;
        public string Username
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged("Username");
            }
        }

        private string cine;
        public string Password
        {
            get { return cine; }
            set
            {
                cine = value;
                OnPropertyChanged("Password");
            }
        }

        private string tel;
        public string Email
        {
            get { return tel; }
            set
            {
                tel = value;
                OnPropertyChanged("Email");
            }
        }

    

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };

            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                   

                        Realm context = Realm.GetInstance();


                    context.Write(() =>
                    {

                        context.Add<User>(new User()
                        {
                           
                            Username = Username,
                            Password = Password,
                            Email = Email
                        });
                    });


                    // After adding new entry to database close this page
                    
                    
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            else
            {
                messageLabel.Text = "merci de donner des informations correctes";
            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
        private async void OnLoginButtonHome(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Home());
        }
    }
}