using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XamarinApp.Helpers
{
    public static class Settings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        const string isRemembered = "IsRemembered";

        static readonly string stringDefault = string.Empty;


        public static string IsRemembered
        {
            get
            {
                return AppSettings.GetValueOrDefault(isRemembered, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(isRemembered, value);
            }
        }


        //const string isRemembered = "IsRemembered";
        //static readonly string stringDefault = string.Empty;

        //public static string IsRemembered
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(isRemembered, stringDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(isRemembered, value);
        //    }
        //}
    }
}
