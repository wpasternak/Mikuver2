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
        [DataType(DataType.Date, ErrorMessage = "Ungültiges Datum")]
        [RegularExpression(@"^([0-9]{2}).([0-9]{2}).([0-9]{4})", ErrorMessage = "Bitte Datum (TT.MM.JJJJ) überprüfen")]
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
        [DataType(DataType.Text, ErrorMessage = "Ungültige Kundennummer")]
        [RegularExpression(@"^[0-9]{1,45}", ErrorMessage = "Bitte Kundennummer überprüfen")]
        public string KundenNummer { get; set; }


    }
}
