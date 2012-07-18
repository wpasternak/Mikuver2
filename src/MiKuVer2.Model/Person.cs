using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace MiKuVer2.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Die Personendaten des Kunden oder der Geschaeftspartner
    /// </summary>
    [DataContract(IsReference = true)]
    public class Person : Kontakt
    { 

        /// <summary>
        /// Der Vorname der Person
        /// </summary>
        [DataMember]
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Ungültiger Vorname")]
        [RegularExpression(@"^[A-Z][a-z]*", ErrorMessage = "Bitte Vorname überprüfen")]
        public string Vorname { get; set; }

        /// <summary>
        /// Der Nachname der Person
        /// </summary>
        [DataMember]
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Ungültiger Nachname")]
        [RegularExpression(@"^[A-Z][a-zA-z\s]*", ErrorMessage = "Bitte Nachname überprüfen")]
        public string Nachname { get; set; }

        /// <summary>
        /// Der Geburtstag der Person
        /// </summary>
        [DataMember]
        [DataType(DataType.Date, ErrorMessage = "Ungültiges Geburtsdatum")]
        [RegularExpression(@"^([0-9]{2}).([0-9]{2}).([0-9]{4})", ErrorMessage = "Bitte Geburstdatum (TT.MM.JJJJ) überprüfen")]
        public DateTime Geburtstag { get; set; }

        /// <summary>
        /// Das Geschlecht der Person
        /// </summary>
        [DataMember]
        public bool Geschlecht { get; set; }

        [DataMember]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Ungültige Mobilnummer")]
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Bitte Mobilnummer überprüfen")]
        public string MobilNr { get; set; }
    }
}
