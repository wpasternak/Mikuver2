using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MiKuVer2.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Kundendaten der Kunden
    /// </summary>
    [DataContract(IsReference = true)]
    public class Kunde : Person
    {
        /// <summary>
        /// Der Zeitpunkt seit dem die Person, Kunde Geworden ist
        /// </summary>
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime KundeSeit { get; set; }

        /// <summary>
        /// Hier sieht man ob der Kunde nur Interesset oder vollständiger
        /// Kunde ist
        /// </summary>
        [DataMember]
        public bool BereitsKunde { get; set; }

        /// <summary>
        /// Das Unternehmen in dem der Kunde arbeitet
        /// </summary>
        [DataMember]
        public Unternehmen Unternehmen { get; set; }

        /// <summary>
        /// Ein Kunde der einen anderen Kunden empfohlen hat
        /// </summary>
        [DataMember]
        public Kunde EmpfohlenVon { get; set; }

        [DataMember]
        public string KundenNummer { get; set; }


    }
}
