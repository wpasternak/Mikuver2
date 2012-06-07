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
    public interface IAufgabeService
    {
        IAufgabeRepository AufgabeRepository { get; set; }

        /// <summary>
        /// Gibt eine Aufgabe zurueck 
        /// </summary>
        /// <param name="id">Die Id der Aufgabe</param>
        /// <returns>Eine Aufgabe</returns>
        [OperationContract(Name = "GetAufgabeById")]
        Aufgabe GetAufgabe(int id);

        /// <summary>
        /// Gibt eine Aufgabe zurueck
        /// </summary>
        /// <param name="name">Der Name der Aufgabe</param>
        /// <returns>Eine Aufgabe</returns>
        [OperationContract(Name = "GetAufgabeByName")]
        Aufgabe GetAufgabe(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob die Aufgabe Gespeichert wurde
        /// </summary>
        /// <param name="neueAufgabe">Die zu speichernde Aufgabe</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool AufgabeSpeichern(Aufgabe neueAufgabe);

        /// <summary>
        /// Gibt einen Wert zurueck ob die Aufgabe aktualisiert wurde
        /// </summary>
        /// <param name="aufgabe">Die vorhandene und zu aktualisierende Aufgabe</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool AufgabeAktualisieren(Aufgabe aufgabe);

        /// <summary>
        /// Gibt einen Wert zurueck ob die Aufgabe geloescht wurde
        /// </summary>
        /// <param name="id">Die Id der Aufgabe</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool AufgabeLoeschen(int id);
    }
}
