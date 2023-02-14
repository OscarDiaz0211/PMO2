using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace P011P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMap : ContentPage
    {
        public PageMap()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var conecetividad = Connectivity.NetworkAccess;

            if(conecetividad== NetworkAccess.Internet)
            {
                var localizacion = await Geolocation.GetLocationAsync();
                if(localizacion != null)
                {
                    Pin ubicacion = new Pin();
                    ubicacion.Label = "Mi Ubicacion";
                    ubicacion.Address = "Mi Direccion";
                    ubicacion.Position = new Position(localizacion.Latitude, localizacion.Longitude);
                    Mapa.Pins.Add(ubicacion);

                    Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localizacion.Latitude, localizacion.Longitude), Distance.FromKilometers(1)));
                }
            }
        }
    }
}