using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Altkom.RentalBikes.MicroService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Micro Service");

            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<WebApiService>(sc =>
                {
                    sc.ConstructUsing(() => new WebApiService());
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());                    
                });

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.EnableShutdown();

                hostConfigurator.SetServiceName("AltkomMicroService");
                hostConfigurator.SetDisplayName("Altkom micro service");
                hostConfigurator.SetDescription("My micro service");

                hostConfigurator.StartAutomatically();

            });

            

            Console.WriteLine("Press any key to exit.");

           // Console.ReadKey();


        }
    }
}
