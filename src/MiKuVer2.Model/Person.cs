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
        [RegularExpression(@"^[A-Z][a-zA-z\s]*")]
        public string Vorname { get; set; }

        /// <summary>
        /// Der Nachname der Person
        /// </summary>
        [DataMember]
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-z\s]*")]
        public string Nachname { get; set; }

        /// <summary>
        /// Der Geburtstag der Person
        /// </summary>
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime Geburtstag { get; set; }

        /// <summary>
        /// Das Geschlecht der Person
        /// </summary>
        [DataMember]
        public bool Geschlecht { get; set; }
    }
}
