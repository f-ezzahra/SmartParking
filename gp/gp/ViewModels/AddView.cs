using gp.Models;
using Realms;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace gp.ViewModels
{

    public class AddView : BaseViewModel
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

        private string _livraisonId;
        private Realm context;

        public AddView(string livraisonId)
        {

            _livraisonId = livraisonId;
            context = Realm.GetInstance();

            var livraison = context.All<Reserver>().Where(t => t.LivraisonId == livraisonId).FirstOrDefault();

            LivraisonName = "Livraison de " + livraison.NomEmetteur + " à " + livraison.NomCollecteur;

            SaveColisCommand = new Command(SaveColis);
        }

        void SaveColis()
        {

            var livraison = context.All<Reserver>().Where(t => t.LivraisonId == _livraisonId).FirstOrDefault();

            context.Write(() =>
            {

                context.Add<Atu>(new Atu()
                {
                    Reference = Int32.Parse(Reference),
                    Nom = Nom,
                    Type = Type,
                    Livraison = livraison
                });
            });

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}