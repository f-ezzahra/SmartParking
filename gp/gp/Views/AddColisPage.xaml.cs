
using gp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace gp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddColisPage : ContentPage
    {
        private string _livraisonId;
        public AddColisPage(string livraisonId)
        {
            InitializeComponent();

            _livraisonId = livraisonId;
        }

        protected override void OnAppearing()
        {
            BindingContext = new AddColisViewModel(_livraisonId);
        }
    }
}