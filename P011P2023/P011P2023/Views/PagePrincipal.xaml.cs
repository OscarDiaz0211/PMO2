using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P011P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void listaequipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var elemento = e.CurrentSelection.FirstOrDefault() as Models.Equipos;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listaequipos.ItemsSource = await App.DbEquipo.ListaEquipos();
        }

        private async void toolagrega_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new Views.PageEquipos());

        }

        private async void toolupdate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEquipos());
        }

        private async void toolmaps_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageMap());
        }
    }
}