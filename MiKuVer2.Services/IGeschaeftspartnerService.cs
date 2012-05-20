using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using MiKuVer2.Model;

namespace MiKuVer2.Services
{
    [ServiceContract]
    public interface IGeschaeftspartnerService
    {
        IGeschaeftspertnerRepository GeschaeftspartnerRepository { get; set; }

        /// <summary>
        /// Gibt alle direkten Geschaeftsparner zurueck
        /// </summary>
        /// <returns>Liste aller direkten Geschaeftspartner</returns>
        [OperationContract]
        List<Geschaeftspartner> GetDirekteGeschaeftspartner();

        /// <summary>
        /// Gibt alle Geschaeftspartner zurueck
        /// </summary>
        /// <returns>Liste aller Geschaeftspartner</returns>
        [OperationContract]
        List<Geschaeftspartner> GetAlleGeschaeftspartner();

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="id">Die Id des Geschaeftspartners</param>
        /// <returns>Einen Geschaeftspartner</returns>
        [OperationContract(Name = "GetGeschaeftsprtnerById")]
        Geschaeftspartner GetGeschaeftspartner(int id);

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="name">Der Name des Geschaeftspartners</param>
        /// <returns> Einen Geschaeftspartner</returns>
        [OperationContract(Name = "GetGeschaeftsprtnerByName")]
        Geschaeftspartner GetGeschaeftspartner(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Geschaeftspartner 
        /// gespeichert wurde
        /// </summary>
        /// <param name="neuerGeschaeftspartner">Der zu speichernde Geschaefts-
        /// partner</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool GeschaeftspartnerSpeichern(Geschaeftspartner neuerGeschaeftspartner);

        /// <summary>
        /// Gibt einen Wert zurueck ob der vorhande Geschaeftspartner
        /// aktualisiert wurde
        /// </summary>
        /// <param name="geschaeftspartner">Der vorhande und zu aktualisierende 
        /// Geschaeftspartner</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool GeschaeftspartnerAktualisieren(Geschaeftspartner geschaeftspartner);

    }
}
