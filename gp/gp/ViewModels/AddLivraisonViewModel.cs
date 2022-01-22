using gp.Models;
using Realms;
using System.Windows.Input;
using Xamarin.Forms;

namespace gp.ViewModels
{

    public class AddLivraisonViewModel : BaseViewModel
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

        public AddLivraisonViewModel()
        {

            SaveLivraisonCommand = new Command(SaveLivraison);
        }

        async void SaveLivraison()
        {

            Realm context = Realm.GetInstance();

            context.Write(() =>
            {

                context.Add<Livraison>(new Livraison() { NomEmetteur = NomEmetteur, CINEmetteur = CINEmetteur, Tel = Tel, Adresse1 = Adresse1, NomCollecteur = NomCollecteur, CINCollecteur = CINCollecteur, Adresse2 = Adresse2 });
            });


            // After adding new entry to database close this page
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}