using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Topshelf;

namespace WebScanDriver.Service
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<Service>(s =>
                {
                    s.ConstructUsing(() => new Service()); // how to build the service
                    s.WhenStarted(service => service.Start()); // what to do when service starts
                    s.WhenStopped(service => service.Stop());  // what to do when service stops
                });

                x.RunAsLocalSystem(); // service account (can also be RunAsNetworkService, etc.)

                x.SetDescription("An Small Application to work with Scanner devices in Web Environment");
                
                x.SetDisplayName("Web Scanner Driver");
                
                x.SetServiceName("Web Scanner Driver");
            });
        }
    }
}

