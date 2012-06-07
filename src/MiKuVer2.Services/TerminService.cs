using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiKuVer2.Services
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics;

    using MiKuVer2.Model;

    public class TerminService : ITerminService
    {
        public TerminService()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            try
            {
                container.ComposeParts(this);
            }
            catch (ChangeRejectedException exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Gets or sets TerminRepository.
        /// </summary>
        [Import(typeof(ITerminRepository))]
        public ITerminRepository TerminRepository { get; set; }

        /// <summary>
        /// Gibt einen Termin zurueck 
        /// </summary>
        /// <param name="id">Die Id des Termines</param>
        /// <returns>Einen Termin</returns>
        public Termin GetTermin(int id)
        {
            return this.TerminRepository.GetTermin(id);
        }

        /// <summary>
        /// Gibt einen Termin zurueck
        /// </summary>
        /// <param name="name">Der Name des Termines</param>
        /// <returns>Einen Termin</returns>
        public Termin GetTermin(string name)
        {
            return this.TerminRepository.GetTermin(name);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin Gespeichert wurde
        /// </summary>
        /// <param name="neueTermin">Der zu speichernde Termin</param>
        /// <returns>true oder false</returns>
        public bool TerminSpeichern(Termin neueTermin)
        {
            return this.TerminRepository.TerminSpeichern(neueTermin);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin aktualisiert wurde
        /// </summary>
        /// <param name="Termin">Der vorhandene und zu aktualisierende Termin</param>
        /// <returns>true oder false</returns>
        public bool TerminAktualisieren(Termin termin)
        {
            return this.TerminRepository.TerminAktualisieren(termin);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin geloescht wurde
        /// </summary>
        /// <param name="id">Die Id des Termines</param>
        /// <returns>true oder false</returns>
        public bool TerminLoeschen(int id)
        {
            return this.TerminRepository.TerminLoeschen(id);
        }
    }
}
