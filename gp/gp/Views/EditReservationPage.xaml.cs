
using gp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditLivraisonPage : ContentPage
    {
        public string _livraisonId;

        public EditLivraisonPage(string livraisonId)
        {
            InitializeComponent();

            _livraisonId = livraisonId;
        }

        protected override void OnAppearing()
        {

            BindingContext = new EditLivraisonViewModel(_livraisonId);
        }

    }
}