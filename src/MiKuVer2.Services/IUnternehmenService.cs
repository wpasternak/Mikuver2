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
    public interface IUnternehmenService
    {
        IUnternehmenRepository UnternehmenRepository { get; set; }

        /// <summary>
        /// Gibt ein Unternehmen zurueck
        /// </summary>
        /// <param name="id">Die Id des Unternehmens</param>
        /// <returns>Ein Unternehmen</returns>
        [OperationContract(Name = "GetUnternehmenById")]
        Unternehmen GetUnternehmen(int id);

        /// <summary>
        /// Gibt ein Unternehmen zurueck
        /// </summary>
        /// <param name="name">Der Name des Unternehmens</param>
        /// <returns>Ein Unternehmen</returns>
        [OperationContract(Name = "GetUnternehmenByName")]
        Unternehmen GetUnternehmen(string name);

        /// <summary>
        /// Gibt einen Wert zurueck ob das Unternehmen gespeichert wurde
        /// </summary>
        /// <param name="neuesUnternehmen">Das zu speichernde Unternehmen</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool UnternehmenSpeichern(Unternehmen neuesUnternehmen);

        /// <summary>
        /// Gibt einen Wert zurueck ob das Unternehmen aktualisiert wurde
        /// </summary>
        /// <param name="unternehmen">Das vorhandene und zu aktualisierende Unternehmen</param>
        /// <returns>true oder false</returns>
        [OperationContract]
        bool UnternehmenAktualisieren(Unternehmen unternehmen);
    }
}
