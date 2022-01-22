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
    class LivreurViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Livreur> _listOfLivreurDetails;

        public List<Livreur> ListOfLivreurDetails
        {
            get { return _listOfLivreurDetails; }
            set
            {
                _listOfLivreurDetails = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        Realm _getRealmInstance = Realm.GetInstance();

        public LivreurViewModel()
        {
            // supply the public ListOfCustomerDetails with the retrieved list of details
            ListOfLivreurDetails = _getRealmInstance.All<Livreur>().ToList();
        }

        private Livreur _livreurDetails = new Livreur();

        public Livreur LivreurDetails
        {
            get { return _livreurDetails; }
            set
            {
                _livreurDetails = value;
                OnPropertyChanged(); // Add the OnPropertyChanged();
            }
        }

        public Command CreateCommand // for ADD
        {
            get
            {
                return new Command(() =>
                {
                    // for auto increment the id upon adding
                    _livreurDetails.LivreurId = _getRealmInstance.All<Livreur>().Count() + 1;
                    _getRealmInstance.Write(() =>
                    {
                        _getRealmInstance.Add(_livreurDetails); // Add the whole set of details
                    });
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
                    var livreurDetailsUpdate = new Livreur
                    {
                        LivreurId = _livreurDetails.LivreurId,
                        LivreurName = _livreurDetails.LivreurName,
                        LivreurTel = _livreurDetails.LivreurTel,
                        LivreurAdresse = _livreurDetails.LivreurAdresse
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
                    var getAllLivreurDetailsById = _getRealmInstance.All<Livreur>().First(x => x.LivreurId == _livreurDetails.LivreurId);

                    using (var transaction = _getRealmInstance.BeginWrite())
                    {
                        // remove all details
                        _getRealmInstance.Remove(getAllLivreurDetailsById);
                        transaction.Commit();
                    };
                });
            }
        }

        public Command NavToLiv
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new login2());
                });
            }
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
        public Command navcommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new GPS());
                });
            }
        }
        public Command navmaps
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Maps());
                });
            }
        }

        public Command NavToCreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new CreateLivreur());
                });
            }
        }

        public Command NavToUpdateDeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new UpdateOrDeleteLivreur());
                });
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
    }
}

