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

    using MiKuVer2.Model;

    public class GeschaeftspartnerService : IGeschaeftspartnerService
    {
        public GeschaeftspartnerService()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        /// <summary>
        /// Gets or sets GeschaeftspartnerRepository.
        /// </summary>
        [Import(typeof(IGeschaeftspertnerRepository))]
        public IGeschaeftspertnerRepository GeschaeftspartnerRepository { get; set; }

        /// <summary>
        /// Gibt alle direkten Geschaeftsparner zurueck
        /// </summary>
        /// <returns>Liste aller direkten Geschaeftspartner</returns>
        public List<Geschaeftspartner> GetDirekteGeschaeftspartner()
        {
            return this.GeschaeftspartnerRepository.GetDirekteGeschaeftspartner();
        }

        /// <summary>
        /// Gibt alle Geschaeftspartner zurueck
        /// </summary>
        /// <returns>Liste aller Geschaeftspartner</returns>
        public List<Geschaeftspartner> GetAlleGeschaeftspartner()
        {
            return this.GeschaeftspartnerRepository.GetAlleGeschaeftspartner();
        }

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="id">Die Id des Geschaeftspartners</param>
        /// <returns>Einen Geschaeftspartner</returns>
        public Geschaeftspartner GetGeschaeftspartner(int id)
        {
            return this.GeschaeftspartnerRepository.GetGeschaeftspartner(id);
        }

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="name">Der Name des Geschaeftspartners</param>
        /// <returns> Einen Geschaeftspartner</returns>
        public Geschaeftspartner GetGeschaeftspartner(string name)
        {
            return this.GeschaeftspartnerRepository.GetGeschaeftspartner(name);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Geschaeftspartner 
        /// gespeichert wurde
        /// </summary>
        /// <param name="neuerGeschaeftspartner">Der zu speichernde Geschaefts-
        /// partner</param>
        /// <returns>true oder false</returns>
        public bool GeschaeftspartnerSpeichern(Geschaeftspartner neuerGeschaeftspartner)
        {
            return this.GeschaeftspartnerRepository.GeschaeftspartnerSpeichern(neuerGeschaeftspartner);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der vorhande Geschaeftspartner
        /// aktualisiert wurde
        /// </summary>
        /// <param name="geschaeftspartner">Der vorhande und zu aktualisierende 
        /// Geschaeftspartner</param>
        /// <returns>true oder false</returns>
        public bool GeschaeftspartnerAktualisieren(Geschaeftspartner geschaeftspartner)
        {
            return this.GeschaeftspartnerRepository.GeschaeftspartnerAktualisieren(geschaeftspartner);
        }
    }
}
