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
    public interface IKundenService
    {
        IKundenRepository KundenRepository { get; set; }

        /// <summary>
        /// Gibt alle eigenen Kunden zurueck
        /// </summary>
        /// <returns>Liste aller eigenen Kunden</returns>
        [OperationContract]
        List<Kunde> GetDirekteKunden();

        /// <summary>
        /// Gibt alle Kunden von allen Geschaeftspaertnern zurueck
        /// </summary>
        /// <returns>List aller Kunden</returns>
        [OperationContract]
        List<Kunde> GetAlleKunden();

        /// <summary>
        /// Gibt alle direkten Kunden eines anderen Geschaeftspartners
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Liste direkter Kunden eines Geschaeftspartners</returns>
        [OperationContract]
        List<Kunde> GetDirekteKundenVonGeschaeftspartner(int id);

        /// <summary>
        /// Gibt alle Kunden, eines Geschaeftspartners und aller seiner Geschaeftspartner, zurueck
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Liste aller direkten und indirekten Kunden eines Geschaeftspartners</returns>
        [OperationContract]
        List<Kunde> GetKundenVonGeschaeftspartner(int id);

        /// <summary>
        /// Gibt einen Kunden zurueck
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Einen Kunden</returns>
        [OperationContract(Name = "GetKundenById")]
        Kunde GetKunde(int id);

        /// <summary>
        /// Gibt einen Kunden zurueck
        /// </summary>
        /// <param name="name">Der Name des Kunden</param>
        /// <returns>Einen Kunden</returns>
        [OperationContract(Name = "GetKundeByName")]
        Kunde GetKunde(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Kunde gespeichert wurde
        /// </summary>
        /// <param name="neuerKunde">Der zu speichernde Kunde</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool KundeSpeichern(Kunde neuerKunde,int geschaeftspartnerId);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Kunde aktualisiert wurde
        /// </summary>
        /// <param name="kunden">der vorhandene und zu aktualisierende Kunde</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool KundenAktualisieren(Kunde kunden);
    }
}
