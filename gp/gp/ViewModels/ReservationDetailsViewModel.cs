using gp.Models;
using gp.Views;
using Realms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace gp.ViewModels
{
    class ReservationDetailsViewModel : BaseViewModel
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

        private ObservableCollection<Atu> coliss;
        public ObservableCollection<Atu> Coliss
        {
            get { return coliss; }
            set { coliss = value; }
        }

        public ICommand AddColisCommand { get; private set; }
        public ICommand EditLivraisonCommand { get; private set; }
        public ICommand DeleteLivraisonCommand { get; private set; }

        public ICommand SuivreCommand { get; private set; }

        private string _livraisonId;

        public ReservationDetailsViewModel(string livraisonId)
        {

            _livraisonId = livraisonId;

            Realm context = Realm.GetInstance();

            var livraison = context.Find<Reserver>(livraisonId);

            // Setting property values from livraison object
            // that we get from database
            NomEmetteur = livraison.NomEmetteur;
            CINEmetteur = livraison.CINEmetteur;
            Tel = livraison.Tel;
            Adresse1 = livraison.Adresse1;
            NomCollecteur = livraison.NomCollecteur;
            CINCollecteur = livraison.CINCollecteur;
            Adresse2 = livraison.Adresse2;

            // You can not do like this:
            // Players = new ObservableCollection<Player>(context.All<Player>().Where(p => p.Team.TeamId == teamId));
            // Querying by nested RealmObjects attributes is not currently supported:
            Coliss = new ObservableCollection<Atu>(context.All<Atu>().Where(p => p.Livraison == livraison));

            // Commands for toolbar items
            AddColisCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddColisPage(livraison.LivraisonId)));
            EditLivraisonCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new EditLivraisonPage(livraison.LivraisonId)));
            DeleteLivraisonCommand = new Command(DeleteLivraison);
            SuivreCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new MapPage(livraison.Adresse1, livraison.Adresse2)));
        }

        void DeleteLivraison()
        {

            Realm context = Realm.GetInstance();
            var livraison = context.Find<Reserver>(_livraisonId);

            context.Write(() =>
            {
                context.Remove(livraison);
            });

            Application.Current.MainPage.Navigation.PopAsync();
        }
        public Command NavToListCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ListOfLivreurs());
                });
            }
        }

    }
}
