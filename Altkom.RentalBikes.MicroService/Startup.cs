using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Altkom.RentalBikes.MicroService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            using (var config = new HttpConfiguration())
            {
                WebApiConfig.Register(config);

                appBuilder.UseWebApi(config);
            }

        }
    }
}