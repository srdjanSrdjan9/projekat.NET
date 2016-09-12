using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Threading;
using System.Globalization;

[assembly: OwinStartup(typeof(RestAPI.Startup))]

namespace RestAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr-Cyrl");
        }
    }
}
