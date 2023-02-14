using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using P011P2023;
using Xamarin.Forms.Shapes;

namespace P011P2023
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnsegunda_Clicked(object sender, EventArgs e)
        {
            var estudiante = new Models.Estudiantes
            {
                nombres = nombre.Text,
                apellidos = apellido.Text,
                telefono = telefono.Text
            };

            var pagina = new Views.Page_Two();
            pagina.BindingContext= estudiante;
            await Navigation.PushAsync(pagina);
        }
    }
}
