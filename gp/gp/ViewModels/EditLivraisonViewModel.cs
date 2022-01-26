using gp.Models;
using Realms;
using System.Windows.Input;
using Xamarin.Forms;
namespace gp.ViewModels
{
    class EditLivraisonViewModel : BaseViewModel
    {

        private string nome;
        public string NomEmetteur
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged("NomEmetteur");
            }
        }

        private string cine;
        public string CINEmetteur
        {
            get { return cine; }
            set
            {
                cine = value;
                OnPropertyChanged("CINEmetteur");
            }
        }

        private string tel;
        public string Tel
        {
            get { return tel; }
            set
            {
                tel = value;
                OnPropertyChanged("Tel");
            }
        }

        private string adresse1;
        public string Adresse1
        {
            get { return adresse1; }
            set
            {
                adresse1 = value;
                OnPropertyChanged("Adresse1");
            }
        }

        private string nomc;
        public string NomCollecteur
        {
            get { return nomc; }
            set
            {
                nomc = value;
                OnPropertyChanged("NomCollecteur");
            }
        }

        private string cinc;
        public string CINCollecteur
        {
            get { return cinc; }
            set
            {
                cinc = value;
                OnPropertyChanged("CINCollecteur");
            }
        }

        private string adresse2;
        public string Adresse2
        {
            get { return adresse2; }
            set
            {
                adresse2 = value;
                OnPropertyChanged("Adresse2");
            }
        }

        public ICommand SaveLivraisonCommand { get; private set; }

        private string _livraisonId;

        public EditLivraisonViewModel(string livraisonId)
        {

            Realm context = Realm.GetInstance();

            var livraison = context.Find<Reserver>(livraisonId);
            _livraisonId = livraison.LivraisonId;

            NomEmetteur = livraison.NomEmetteur;
            CINEmetteur = livraison.CINEmetteur;
            Tel = livraison.Tel;
            Adresse1 = livraison.Adresse1;
            NomCollecteur = livraison.NomCollecteur;
            CINCollecteur = livraison.CINCollecteur;
            Adresse2 = livraison.Adresse2;

            SaveLivraisonCommand = new Command(SaveLivraison);
        }

        async void SaveLivraison()
        {

            Realm context = Realm.GetInstance();

            var livraison = context.Find<Reserver>(_livraisonId);

            context.Write(() =>
            {

                livraison.NomEmetteur = NomEmetteur;
                livraison.CINEmetteur = CINEmetteur;
                livraison.Tel = Tel;
                livraison.Adresse1 = Adresse1;
                livraison.NomCollecteur = NomCollecteur;
                livraison.CINCollecteur = CINCollecteur;
                livraison.Adresse2 = Adresse2;

                context.Add<Reserver>(livraison, update: true);
            });

            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
