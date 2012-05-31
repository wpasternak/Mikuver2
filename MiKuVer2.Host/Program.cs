using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MiKuVer2.Host
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
             bool debug = args.Contains("debug");

#if DEBUG
            debug = true;
#endif

            if (debug)
            {
                try
                {
                    Console.WriteLine("WCF-Dienste starten...");
                    var service = new WCFHost();
                    service.Starten();
                    Console.WriteLine();
                    Console.WriteLine("WCF Services are running an waiting for request ...");

                    //while (true)
                    //{
                    //    Console.WriteLine("To stop the Services just hit enter !! ...");

                    //    ConsoleKey key = Console.ReadKey().Key;
                    //    if (key == ConsoleKey.K)
                    //    {
                    //        if (service.Konfigurieren())
                    //        {
                    //            service.Stoppen();
                    //            service.Starten();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        break;
                    //    }
                    //}

                    Console.ReadKey();

                    Console.WriteLine("Dienst wird beendet...");
                    service.Stoppen();
                    Console.WriteLine("WCF-Dienst bendet...");
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
                
            }
            else
            {
                var servicesToRun = new ServiceBase[] { new WCFHost() };

                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
