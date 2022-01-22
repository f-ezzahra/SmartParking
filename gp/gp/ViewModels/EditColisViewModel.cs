using gp.Models;
using Realms;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace gp.ViewModels
{

    public class EditColisViewModel : BaseViewModel
    {

        private string livraisonName;
        public string LivraisonName
        {
            get { return livraisonName; }
            set
            {
                livraisonName = value;
                OnPropertyChanged("LivraisonName");
            }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                OnPropertyChanged("Nom");
            }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        private string reference;
        public string Reference
        {
            get { return reference; }
            set
            {
                reference = value;
                OnPropertyChanged("Reference");
            }
        }

        public ICommand SaveColisCommand { get; private set; }

        private string _colisId;

        public EditColisViewModel(string colisId)
        {

            Realm context = Realm.GetInstance();

            var colis = context.Find<Colis>(colisId);

            _colisId = colis.ColisId;

            LivraisonName = "Livraison de " + colis.Livraison.NomEmetteur + " à " + colis.Livraison.NomCollecteur;

            Nom = colis.Nom;
            Type = colis.Type;
            Reference = colis.Reference.ToString();

            SaveColisCommand = new Command(SaveColis);
        }

        void SaveColis()
        {

            Realm context = Realm.GetInstance();

            var colis = context.Find<Colis>(_colisId);

            context.Write(() =>
            {

                colis.Type = Type;
                colis.Nom = Nom;
                colis.Reference = Int32.Parse(Reference);

                context.Add<Colis>(colis, update: true);
            });

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}