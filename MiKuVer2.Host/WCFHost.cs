using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MiKuVer2.Host
{
    using System.ServiceModel;

    using MiKuVer2.Services;

    partial class WCFHost : ServiceBase
    {
        private List<ServiceHost> services = new List<ServiceHost>();

        public WCFHost()
        {
            InitializeComponent();
            this.services.Add(new ServiceHost(typeof(IGeschaeftspartnerService)));
        }

        protected override void OnStart(string[] args)
        {
            this.Starten();
        }

        protected override void OnStop()
        {
            this.Stoppen();
        }

        internal void Starten()
        {
            if (this.services.Count == 0)
            {
                throw new ArgumentNullException("Es wurden keine Services gewählt die gestartet werden sollen");
            }

            foreach (ServiceHost service in this.services)
            {
                if (service.State == CommunicationState.Opened)
                {
                    service.Close();
                }
                this.EventLog.WriteEntry("es wird versucht " + service.Description.Name + "zu starten.");
                service.Open();
                if (service.State == CommunicationState.Opened)
                {
                    Console.WriteLine(
                        "{0} is listening on {1} for requests",
                        service.Description.Name,
                        service.BaseAddresses[0].AbsoluteUri);
                    Console.WriteLine();
                }
                else
                {
                    this.EventLog.WriteEntry(string.Format("Der Service: {0} wurde leider nicht gestartet", service.Description.Name));
                }
            }
        }

        internal void Stoppen()
        {
            foreach (ServiceHost service in this.services)
            {
                service.Close();
                if (service.State == CommunicationState.Closed)
                {
                    this.EventLog.WriteEntry(string.Format("Der Service: {0} wurde erfolgreich beendet", service.Description.Name));
                }
                else
                {
                    this.EventLog.WriteEntry(string.Format("Der Service: {0} wurde nicht beendet", service.Description.Name));
                }
            }

            this.services.Clear();
        }
    }
}
