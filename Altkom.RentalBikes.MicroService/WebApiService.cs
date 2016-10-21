using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.MicroService
{
    public class WebApiService
    {
        private IDisposable _webapp;

        public void Start()
        {
            string address = "http://localhost:5001";

            _webapp = WebApp.Start<Startup>(address);
        }

        public void Stop()
        {
            _webapp.Dispose();
        }
    }
}
