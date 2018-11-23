using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp.Views;
using XamarinApp.Helpers;
using XamarinApp.ViewModel;
using XamarinApp.Services;
using XamarinApp.Models;

namespace XamarinApp
{
	public partial class App : Application
	{

        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        #endregion

        #region Constructor
        public App ()
		{
			InitializeComponent();

            if (Settings.IsRemembered == "true")
            {
                var dataService = new DataService();
                var token = dataService.First<TokenResponse>(false);

                if (token != null && token.Expires > DateTime.Now)
                {
                    var user = dataService.First<UserLocal>(false);
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Token = token;
                    mainViewModel.User = user;
                    mainViewModel.Lands = new LandsViewModel();
                    Application.Current.MainPage = new MasterPage();
                }
                else
                {
                    MainPage = new NavigationPage(new Login());
                }
                             
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
           

        }
        #endregion

        #region Methods
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
        #endregion
    }
}
