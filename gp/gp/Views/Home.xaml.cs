using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Maps());
        }
        private async void Contact(object sender, EventArgs e)
        {
           
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GPS());
        }
        private async void OnclickedButtonNextPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}