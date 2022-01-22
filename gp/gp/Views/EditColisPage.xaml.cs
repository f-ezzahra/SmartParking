
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditColisPage : ContentPage
    {
        private string _colisId;

        public EditColisPage(string colisId)
        {
            InitializeComponent();

            _colisId = colisId;
        }

        protected override void OnAppearing()
        {

            BindingContext = new EditColisViewModel(_colisId);
        }
    }
}