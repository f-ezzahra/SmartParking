
using gp.Models;
using gp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LivraisonDetailsPage : ContentPage
    {

        private string _livraisonId;

        public LivraisonDetailsPage(string livraisonId)
        {
            InitializeComponent();
            _livraisonId = livraisonId;
        }

        protected override void OnAppearing()
        {

            BindingContext = new LivraisonDetailsViewModel(_livraisonId);
            base.OnAppearing();
        }

        private void OnColisTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item != null)
            {

                var colis = (Colis)e.Item;

                Navigation.PushAsync(new EditColisPage(colis.ColisId));
            }
        }

    }
}