using System;
using System.Diagnostics;
using UsingApi.Services;
using UsingApi.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsingApi
{
    public partial class App : Application
    {
        private static LocalDataBaseContext database;

        public static LocalDataBaseContext Database
        {
            get
            {
                if (database == null)
                {
                    try
                    {
                        database = new LocalDataBaseContext(DependencyService.Get<IFileHelper>().GetLocalFilePath("database.db3"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);

            MainPage = new NavigationPage(new MainViewPage());
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
