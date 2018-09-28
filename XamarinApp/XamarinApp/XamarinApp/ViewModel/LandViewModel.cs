using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XamarinApp.Models;

namespace XamarinApp.ViewModel
{
   public class LandViewModel:BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        #endregion

        #region Properties
        public Land Land { get; set; }

        public ObservableCollection<Border> Borders {
            get
            { return this.borders; }
             set { this.SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get
            { return this.currencies; }
            set { this.SetValue(ref this.currencies, value); }
        }
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
        }
        #endregion

        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.
                            Where(l => l.Alpha3Code == border)
                            .FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name
                    });
                }
            }
        }
        #endregion
    }
}
