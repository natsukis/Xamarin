using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Views;

namespace XamarinApp.ViewModel
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands

        public ICommand NavigateCommand {
            get {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            if(this.PageName == "Login")
            {
                Application.Current.MainPage = new Login();
            }
        }
        #endregion
    }
}
