using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model.Interfaces
{
    interface IGeschaeftspertnerRepository
    {
        /// <summary>
        /// Gibt alle direkten Geschaeftsparner zurueck
        /// </summary>
        /// <returns>Liste aller direkten Geschaeftspartner</returns>
        List<Geschaeftspartner> GetDirekteGeschaeftspartner();

        /// <summary>
        /// Gibt alle Geschaeftspartner zurueck
        /// </summary>
        /// <returns>Liste aller Geschaeftspartner</returns>
        List<Geschaeftspartner> GetAlleGeschaeftspartner();

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="id">Die Id des Geschaeftspartners</param>
        /// <returns>Einen Geschaeftspartner</returns>
        Geschaeftspartner GetGeschaeftspartner(int id);

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="name">Der Name des Geschaeftspartners</param>
        /// <returns> Einen Geschaeftspartner</returns>
        Geschaeftspartner GetGeschaeftspartner(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Geschaeftspartner 
        /// gespeichert wurde
        /// </summary>
        /// <param name="neuerGeschaeftspartner">Der zu speichernde Geschaefts-
        /// partner</param>
        /// <returns>true oder false</returns>
        bool GeschaeftspartnerSpeichern(Geschaeftspartner neuerGeschaeftspartner);

        /// <summary>
        /// Gibt einen Wert zurueck ob der vorhande Geschaeftspartner
        /// aktualisiert wurde
        /// </summary>
        /// <param name="geschaeftspartner">Der vorhande und zu aktualisierende 
        /// Geschaeftspartner</param>
        /// <returns>true oder false</returns>
        bool GeschaeftspartnerAktualisieren(Geschaeftspartner geschaeftspartner);
    }
}
