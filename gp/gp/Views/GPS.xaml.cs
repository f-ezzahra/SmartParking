using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GPS : ContentPage
    {
        public GPS()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    /*var label1 = new Label { Text = "", FontSize = 20 };
                    label1.Text = location.Latitude.ToString();
                    var label2 = new Label { Text = "", FontSize = 20 };
                    label2.Text = location.Longitude.ToString(); */




                    la.Text = location.Latitude.ToString();
                    lo.Text = location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}