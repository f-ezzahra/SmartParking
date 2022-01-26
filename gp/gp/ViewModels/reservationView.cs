using gp.Models;
using gp.Views;
using Realms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace gp.ViewModels 
{
    class reservationView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<Reserver> _listOfLivreurDetails;

        public List<Reserver> ListOfLivreurDetails
        {
            get { return _listOfLivreurDetails; }
            set
            {
                _listOfLivreurDetails = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        Realm _getRealmInstance = Realm.GetInstance();
        public reservationView()
        {
            // supply the public ListOfCustomerDetails with the retrieved list of details
            ListOfLivreurDetails = _getRealmInstance.All<Reserver>().ToList();
        }

        private Reserver _livreurDetails = new Reserver();
        private string livraisonId;

        public Reserver LivreurDetails
        {
            get { return _livreurDetails; }
            set
            {
                _livreurDetails = value;
                OnPropertyChanged(); // Add the OnPropertyChanged();
            }
        }
        public Command NavToListreservation
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new LivraisonsListPage());
                });
            }
        }
        public Command NavToUpdatereservation
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new EditLivraisonPage(livraisonId));
                });
            }
        }
        public Command NavTodeletereservation
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new LivraisonsListPage());
                });
            }
        }
        public Command UpdateCommand // For UPDATE
        {
            get
            {
                return new Command(() =>
                {
                    // instantiate to supply the new set of details
                    var livreurDetailsUpdate = new Reserver
                    {
                        LivraisonId = _livreurDetails.LivraisonId,
                        NomEmetteur = _livreurDetails.NomEmetteur,
                        CINEmetteur = _livreurDetails.CINEmetteur,
                        Tel = _livreurDetails.Tel,
                        Adresse1 = _livreurDetails.Adresse1
                    };

                    _getRealmInstance.Write(() =>
                    {
                        // when there's id match, the details will be replaced except by primary key
                        _getRealmInstance.Add(livreurDetailsUpdate, update: true);
                    });
                });
            }
        }
        public Command RemoveCommand
        {
            get
            {
                return new Command(() =>
                {
                    // get the details with specific id
                    var getAllLivreurDetailsById = _getRealmInstance.All<Reserver>().First(x => x.LivraisonId == _livreurDetails.LivraisonId);

                    using (var transaction = _getRealmInstance.BeginWrite())
                    {
                        // remove all details
                        _getRealmInstance.Remove(getAllLivreurDetailsById);
                        transaction.Commit();
                    };
                });
            }
        }
    }
}
