using gp.Models;
using gp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LivraisonsListPage : ContentPage
    {
        public LivraisonsListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new LivraisonListViewModel();
        }

        private async void LivraisonTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var livraison = (Reserver)e.Item;
                await Navigation.PushAsync(new LivraisonDetailsPage(livraison.LivraisonId));
            }
        }
    }
}