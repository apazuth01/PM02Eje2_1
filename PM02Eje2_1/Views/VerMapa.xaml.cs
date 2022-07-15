using PM02Eje2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM02Eje2_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerMapa : ContentPage
    {
        Countries PaisSeleccionado;
      
        public VerMapa(Countries country)
        {
            PaisSeleccionado = country;
            InitializeComponent();
            loadConfiguration();
        }
        private void loadConfiguration()
        {

            var pin = new Pin()
            {
                Type = PinType.SavedPin,
                Position = new Position(PaisSeleccionado.latlng[0], PaisSeleccionado.latlng[1]),
                Label = PaisSeleccionado.NameCountry.official,
                Address = "Capital: " + PaisSeleccionado.capital


            };

            mapa.Pins.Add(pin);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(PaisSeleccionado.latlng[0], PaisSeleccionado.latlng[1]), Distance.FromKilometers(41)));
        }
    }
}