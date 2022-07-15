using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using PM02Eje2_1.Controller;
using PM02Eje2_1.Models;
using Xamarin.Forms.Xaml;

namespace PM02Eje2_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        RestApi PaisesRestapi;
        List<Countries> ListaPaises;

        public MainPage()
        {
            InitializeComponent();
            PaisesRestapi = new RestApi();
            ListaPaises = new List<Countries>();
        }

      

        private async void ComboRegiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            var region = ComboRegiones.SelectedItem as string;

            var internetAccess = Connectivity.NetworkAccess;
            if (internetAccess == NetworkAccess.Internet)
            {
                ListaPaises = await PaisesRestapi.GetCountries(region);
                ListaPaisesRest.ItemsSource = ListaPaises;
            }
            else
            {
                await DisplayAlert("Error", "La Aplicacion no tiene acceso a Internet! Revise su acceso", "OK");
            }
        }


        private async void ListaPaisesRest_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var country = (Countries) e.Item;
            VerMapa pageDetailCountry = new VerMapa(country);
            pageDetailCountry.BindingContext = country;
            await Navigation.PushAsync(pageDetailCountry);
        }
    }
}
