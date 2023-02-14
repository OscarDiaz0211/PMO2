using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace P011P2023
{
    public partial class App : Application
    {
        static Controllers.DBEquipo dbequipos;
        public static Controllers.DBEquipo DbEquipo
        {
            get
            {
                if(dbequipos == null)
                {
                    var PathApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var DBName = Models.Configuraciones.DBName;
                    var PathFull = Path.Combine(PathApp, DBName);


                    dbequipos = new Controllers.DBEquipo(PathFull);
                }
                return dbequipos;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
