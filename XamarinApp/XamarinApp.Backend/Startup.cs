﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XamarinApp.Backend.Startup))]
namespace XamarinApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
