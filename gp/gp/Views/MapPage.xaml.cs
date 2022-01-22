using gp.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace gp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        // supply the public ListOfCustomerDetails with the retrieved list of details

        private string _Adresse1, _Adresse2;
        List<string> adr = new List<string>();

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

        public MapPage(string Adresse1, string Adresse2)
        {
            InitializeComponent();

            ListOfLivreurDetails = _getRealmInstance.All<Livreur>().ToList();

            foreach (Livreur l in ListOfLivreurDetails)
            {
                adr.Add(l.LivreurAdresse);
            }

            _Adresse1 = Adresse1;
            _Adresse2 = Adresse2;

            Pin p = new Pin()
            {

                Position = new Position(33.593861, -7.629472),
                Type = PinType.Place
            };
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(p.Position, Distance.FromKilometers(8)));

        }

        private void MyMap_MapClicked(object sender, MapClickedEventArgs e)
        {

        }

        private async void col(object sender, EventArgs e)
        {

            Geocoder g = new Geocoder();
            IEnumerable<Position> res = await g.GetPositionsForAddressAsync(_Adresse1);

            foreach (Position pos in res)
            {
                try
                {
                    Pin p = new Pin()
                    {
                        Label = "Collection",
                        Position = pos,
                        Address = _Adresse1,
                        Type = PinType.Place
                    };
                    MyMap.Pins.Add(p);
                }
                catch (Exception ex)
                { /*DisplayAlert("error", ex.ToString(), "cancel");*/ }
            }

        }
        private async void liv(object sender, EventArgs e)
        {

            Geocoder g = new Geocoder();
            IEnumerable<Position> res = await g.GetPositionsForAddressAsync(_Adresse2);

            foreach (Position pos in res)
            {
                try
                {
                    Pin p = new Pin()
                    {
                        Label = "Livraison",
                        Position = pos,
                        Address = _Adresse2,
                        Type = PinType.Place
                    };
                    MyMap.Pins.Add(p);
                }
                catch (Exception ex)
                { /*DisplayAlert("error", ex.ToString(), "cancel");*/ }
            }

        }

        private async void traj(object sender, EventArgs e)
        {
            Geocoder g = new Geocoder();
            IEnumerable<Position> col = await g.GetPositionsForAddressAsync(_Adresse1);
            IEnumerable<Position> liv = await g.GetPositionsForAddressAsync(_Adresse2);
            IEnumerable<Position> l = await g.GetPositionsForAddressAsync("63 Rue Moha Ou Hammou, casablanca, maro"); 
            Position p1 = col.FirstOrDefault();
            Position p2 = liv.FirstOrDefault();
            Position p3 = l.FirstOrDefault();
            Polyline po = new Polyline()
            {
                StrokeColor = Color.Red,
                StrokeWidth = 12,
                Geopath = { p1, p2, p3 }
            };

            MyMap.MapElements.Add(po);


        }

        private async void lv(object sender, EventArgs e)
        {

            Geocoder g = new Geocoder();
            IEnumerable<Position> col = await g.GetPositionsForAddressAsync(_Adresse1);
            IEnumerable<Position> liv = await g.GetPositionsForAddressAsync(_Adresse2);
            Position p1 = col.FirstOrDefault();
            Position p2 = liv.FirstOrDefault();

            Polygon polg = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#1BA1E2"),
                FillColor = Color.FromHex("#881BA1E2"),
                Geopath = { p1, p2 }
            };

            foreach (string a in adr)
            {
                IEnumerable<Position> res = await g.GetPositionsForAddressAsync(a);
                Position po = res.FirstOrDefault();

                Pin p = new Pin()
                {
                    Label = "Livreur",
                    Position = po,
                    Address = a,
                    Type = PinType.Place
                };
                MyMap.Pins.Add(p);
                polg.Geopath.Add(po);

            }
            MyMap.MapElements.Add(polg);
        }
    }
}