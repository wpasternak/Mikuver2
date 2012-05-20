using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace MiKuVer2.Model
{
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
        public string Vorname { get; set; }

        /// <summary>
        /// Der Nachname der Person
        /// </summary>
        [DataMember]
        public string Nachname { get; set; }

        /// <summary>
        /// Der Geburtstag der Person
        /// </summary>
        [DataMember]
        public DateTime Geburtstag { get; set; }

        /// <summary>
        /// Das Geschlecht der Person
        /// </summary>
        [DataMember]
        public bool Geschlecht { get; set; }
    }
}
