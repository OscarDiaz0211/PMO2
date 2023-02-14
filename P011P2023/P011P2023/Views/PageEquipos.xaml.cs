using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.IO;

namespace P011P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEquipos : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public PageEquipos()
        {
            InitializeComponent();
        }

        private String traeImagenToBase64()
        {
            if (photo != null)
            { using (MemoryStream memory = new MemoryStream())
                { Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();
                    string Base64String = Convert.ToBase64String(fotobyte);
                    return Base64String;
                }
            }
            return null;
        }


        private byte[] traeImagenTobytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory); 
                    byte[] fotobyte = memory.ToArray();

                    return fotobyte;
                }
            }
            return null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var equi = new Models.Equipos
            {
                Nombre = nombre.Text,
                Fundacion = Fundacion.Date,
                Correo = correo.Text,
                //Logo = String.Empty,
                Categoria = Categoria.SelectedItem.ToString(),
                Logo = traeImagenTobytes()
            };

             if(await App.DbEquipo.StoreEquipo(equi )> 0)
            {
                await DisplayAlert("Aviso", "Equipo Ingresado", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Equipo no Ingresado", "Ok");
            }

        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions 
            { 
                Directory = "AppEquipos", 
                Name = "Foto.jpg", 
                SaveToAlbum = true 
            }); 

            if (photo != null) 
            { 
                Foto.Source = ImageSource.FromStream(() => 
                {
                    return photo.GetStream(); 
                }); 
            }

        }
    }

    
}