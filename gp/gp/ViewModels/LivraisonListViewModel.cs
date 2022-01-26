using gp.Models;
using gp.Views;
using Realms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace gp.ViewModels
{

    public class LivraisonListViewModel : BaseViewModel
    {

        private ObservableCollection<Reserver> allLivraisons;
        public ObservableCollection<Reserver> AllLivraisons
        {
            get { return allLivraisons; }
            set
            {
                allLivraisons = value;
            }
        }

        public ICommand AddLivraisonCommand { get; private set; }

        public LivraisonListViewModel()
        {

            Realm context = Realm.GetInstance();

            AllLivraisons = new ObservableCollection<Reserver>(context.All<Reserver>());

            AddLivraisonCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddLivraisonPage()));
        }
    }
}