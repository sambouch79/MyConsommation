using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Myconsom.Repositories;
using SQLite;

namespace Myconsom
{
    public partial class App : Application
    {
    
      
        static ReferenceRepository database;

        public static ReferenceRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ReferenceRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Consommation.db3"));
                }
                return database;
            }
        }
        public App()
        {
            Device.SetFlags(new string[] { "AppTheme_Experimental" });
            InitializeComponent();
            //ReferenceRepository = new ReferenceRepository(dbPath);

            MainPage =new  NavigationPage (new MainPage());
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
