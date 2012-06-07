using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model
{
    public interface IUnternehmenRepository
    {
        /// <summary>
        /// Gibt ein Unternehmen zurueck
        /// </summary>
        /// <param name="id">Die Id des Unternehmens</param>
        /// <returns>Ein Unternehmen</returns>
        Unternehmen GetUnternehmen(int id);

        /// <summary>
        /// Gibt ein Unternehmen zurueck
        /// </summary>
        /// <param name="name">Der Name des Unternehmens</param>
        /// <returns>Ein Unternehmen</returns>
        Unternehmen GetUnternehmen(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob das Unternehmen gespeichert wurde
        /// </summary>
        /// <param name="neuesUnternehmen">Das zu speichernde Unternehmen</param>
        /// <returns>true oder false</returns>
        bool UnternehmenSpeichern(Unternehmen neuesUnternehmen);

        /// <summary>
        /// Gibt einen Wert zurueck ob das Unternehmen aktualisiert wurde
        /// </summary>
        /// <param name="unternehmen">Das vorhandene und zu aktualisierende Unternehmen</param>
        /// <returns>true oder false</returns>
        bool UnternehmenAktualisieren(Unternehmen unternehmen);
    }
}
