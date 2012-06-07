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
    public interface ITerminService
    {
        ITerminRepository TerminRepository { get; set; }

        /// <summary>
        /// Gibt einen Termin zurueck 
        /// </summary>
        /// <param name="id">Die Id des Termines</param>
        /// <returns>Einen Termin</returns>
        [OperationContract(Name = "GetTerminById")]
        Termin GetTermin(int id);

        /// <summary>
        /// Gibt einen Termin zurueck
        /// </summary>
        /// <param name="name">Der Name des Termines</param>
        /// <returns>Einen Termin</returns>
        [OperationContract(Name = "GetTerminByName")]
        Termin GetTermin(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin Gespeichert wurde
        /// </summary>
        /// <param name="neueTermin">Der zu speichernde Termin</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool TerminSpeichern(Termin neueTermin);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin aktualisiert wurde
        /// </summary>
        /// <param name="Termin">Der vorhandene und zu aktualisierende Termin</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool TerminAktualisieren(Termin termin);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin geloescht wurde
        /// </summary>
        /// <param name="id">Die Id des Termines</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool TerminLoeschen(int id);
    }
}
