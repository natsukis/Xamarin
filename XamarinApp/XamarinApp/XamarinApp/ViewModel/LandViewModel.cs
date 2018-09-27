using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Models;

namespace XamarinApp.ViewModel
{
   public class LandViewModel
    {
        #region Properties
        public Land Land { get; set; }
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
        }
        #endregion
    }
}
