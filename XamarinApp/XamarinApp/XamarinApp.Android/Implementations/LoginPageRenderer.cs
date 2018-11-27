﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


[assembly: Xamarin.Forms.ExportRenderer(
    typeof(XamarinApp.Views.LoginFacebookPage),
    typeof(XamarinApp.Droid.Implementations.LoginPageRenderer))]

namespace XamarinApp.Droid.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Android.App;
    using XamarinApp.Models;
    using XamarinApp.Services;
    using Xamarin.Auth;
    using Xamarin.Forms.Platform.Android;

    public class LoginPageRenderer : PageRenderer
    {
        public LoginPageRenderer(Context context) : base(context)
        {
            var activity = Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "300726754109462",
                scope: "email",
                authorizeUrl: new Uri("https://www.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var profile = await GetFacebookProfileAsync(accessToken);
                    await App.NavigateToProfile(profile);
                }
                else
                {
                    App.HideLoginView();
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }

        private async Task<FacebookResponse> GetFacebookProfileAsync(string accessToken)
        {
            //var requestUrl = "https://graph.facebook.com/v2.8/me/?fields=name,picture.width(999),cover," +
            //    "age_range,devices,email,gender,is_verified,birthday,languages,work,website,religion," +
            //    "location,locale,link,first_name,last_name,hometown&access_token=" + accessToken;
            var apiService = new ApiService();
            return await apiService.GetFacebook(accessToken);
        }
    }
}