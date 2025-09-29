using Microsoft.Owin.Hosting;
using System;

namespace WebScanDriver.Service
{
    public class Service
    {
        private IDisposable _webApp;

        public bool Start()
        {
            string baseAddress = "http://localhost:5000/";

            Console.WriteLine("Starting Web API on " + baseAddress);

            _webApp = WebApp.Start<Startup>(url: baseAddress);

            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("Stopping Web API...");
            _webApp?.Dispose();
            return true;
        }
    }
}

