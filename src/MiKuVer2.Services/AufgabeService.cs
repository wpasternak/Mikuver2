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

    public class AufgabeService : IAufgabeService
    {
        public AufgabeService()
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
        /// Gets or sets AufgabeRepository.
        /// </summary>
        [Import(typeof(IAufgabeRepository))]
        public IAufgabeRepository AufgabeRepository { get; set; }

        /// <summary>
        /// Gibt eine Aufgabe zurueck 
        /// </summary>
        /// <param name="id">Die Id der Aufgabe</param>
        /// <returns>Eine Aufgabe</returns>
        public Aufgabe GetAufgabe(int id)
        {
            return this.AufgabeRepository.GetAufgabe(id);
        }

        /// <summary>
        /// Gibt eine Aufgabe zurueck
        /// </summary>
        /// <param name="name">Der Name der Aufgabe</param>
        /// <returns>Eine Aufgabe</returns>
        public Aufgabe GetAufgabe(string name)
        {
            return this.AufgabeRepository.GetAufgabe(name);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob die Aufgabe Gespeichert wurde
        /// </summary>
        /// <param name="neueAufgabe">Die zu speichernde Aufgabe</param>
        /// <returns>true oder false</returns>
        public bool AufgabeSpeichern(Aufgabe neueAufgabe)
        {
            return this.AufgabeRepository.AufgabeSpeichern(neueAufgabe);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob die Aufgabe aktualisiert wurde
        /// </summary>
        /// <param name="aufgabe">Die vorhandene und zu aktualisierende Aufgabe</param>
        /// <returns>true oder false</returns>
        public bool AufgabeAktualisieren(Aufgabe aufgabe)
        {
            return this.AufgabeRepository.AufgabeAktualisieren(aufgabe);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob die Aufgabe geloescht wurde
        /// </summary>
        /// <param name="id">Die Id der Aufgabe</param>
        /// <returns>true oder false</returns>
        public bool AufgabeLoeschen(int id)
        {
            return this.AufgabeRepository.AufgabeLoeschen(id);
        }
    }
}
