using System;
using Test2.Data;
using Test2.Services;
using Test2.Views;
using Xamarin.Forms;

namespace Test2
{
	public partial class App : Application
	{
        static ItemDatabase database;

        public App ()
		{
			InitializeComponent();


            MainPage = new MainPage();
        }

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("SQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
