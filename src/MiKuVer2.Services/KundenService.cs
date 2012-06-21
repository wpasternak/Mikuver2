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

    public class KundenService : IKundenService
    {
        public KundenService()
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
        /// Gets or sets KundenRepository.
        /// </summary>
        [Import(typeof(IKundenRepository))]
        public IKundenRepository KundenRepository { get; set; }

        /// <summary>
        /// Gibt alle eigenen Kunden zurueck
        /// </summary>
        /// <returns>Liste aller eigenen Kunden</returns>
        public List<Kunde> GetDirekteKunden()
        {
            return this.KundenRepository.GetDirekteKunden();
        }
        
        /// <summary>
        /// Gibt alle Kunden von allen Geschaeftspaertnern zurueck
        /// </summary>
        /// <returns>List aller Kunden</returns>
        public List<Kunde>  GetAlleKunden()
        {
 	        return this.KundenRepository.GetAlleKunden();
        }

        /// <summary>
        /// Gibt alle direkten Kunden eines anderen Geschaeftspartners
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Liste direkter Kunden eines Geschaeftspartners</returns>
        public List<Kunde>  GetDirekteKundenVonGeschaeftspartner(int id)
        {
 	        return this.KundenRepository.GetDirekteKundenVonGeschaeftspartner(id);
        }

        /// <summary>
        /// Gibt alle Kunden, eines Geschaeftspartners und aller seiner Geschaeftspartner, zurueck
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Liste aller direkten und indirekten Kunden eines Geschaeftspartners</returns>
        public List<Kunde>  GetKundenVonGeschaeftspartner(int id)
        {
 	        return this.KundenRepository.GetKundenVonGeschaeftspartner(id);
        }

        /// <summary>
        /// Gibt einen Kunden zurueck
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Einen Kunden</returns>
        public Kunde  GetKunde(int id)
        {
 	        return this.KundenRepository.GetKunde(id);
        }

        /// <summary>
        /// Gibt einen Kunden zurueck
        /// </summary>
        /// <param name="name">Der Name des Kunden</param>
        /// <returns>Einen Kunden</returns>
        public Kunde  GetKunde(string name)
        {
 	        return this.KundenRepository.GetKunde(name);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Kunde gespeichert wurde
        /// </summary>
        /// <param name="neuerKunde">Der zu speichernde Kunde</param>
        /// <returns>true oder false</returns
        public bool  KundeSpeichern(Kunde neuerKunde, int geschaeftspartnerId)
        {
 	        return this.KundenRepository.KundeSpeichern(neuerKunde,geschaeftspartnerId);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Kunde aktualisiert wurde
        /// </summary>
        /// <param name="kunden">der vorhandene und zu aktualisierende Kunde</param>
        /// <returns>true oder false</returns>
        public bool  KundenAktualisieren(Kunde kunden)
        {
 	        return this.KundenRepository.KundenAktualisieren(kunden);
        }
    }
}
