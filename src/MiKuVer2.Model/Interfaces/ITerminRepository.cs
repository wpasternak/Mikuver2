using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model
{
    public interface ITerminRepository
    {
        /// <summary>
        /// Gibt einen Termin zurueck 
        /// </summary>
        /// <param name="id">Die Id des Termines</param>
        /// <returns>Einen Termin</returns>
        Termin GetTermin(int id);

        /// <summary>
        /// Gibt einen Termin zurueck
        /// </summary>
        /// <param name="name">Der Name des Termines</param>
        /// <returns>Einen Termin</returns>
        Termin GetTermin(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin Gespeichert wurde
        /// </summary>
        /// <param name="neueTermin">Der zu speichernde Termin</param>
        /// <returns>true oder false</returns>
        bool TerminSpeichern(Termin neueTermin);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin aktualisiert wurde
        /// </summary>
        /// <param name="Termin">Der vorhandene und zu aktualisierende Termin</param>
        /// <returns>true oder false</returns>
        bool TerminAktualisieren(Termin termin);

        /// <summary>
        /// Gibt einen Wert zurueck ob der Termin geloescht wurde
        /// </summary>
        /// <param name="id">Die Id des Termines</param>
        /// <returns>true oder false</returns>
        bool TerminLoeschen(int id);
    }
}
