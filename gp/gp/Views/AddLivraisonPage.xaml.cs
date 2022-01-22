using gp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLivraisonPage : ContentPage
    {
        public AddLivraisonPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            BindingContext = new AddLivraisonViewModel();
            base.OnAppearing();
        }
    }
}