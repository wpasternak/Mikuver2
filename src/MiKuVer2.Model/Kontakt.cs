using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace MiKuVer2.Model
{
    /// <summary>
    /// Die Kontaktdaten eines Unternehmens, einer Person, eines Kunden und 
    /// eines Geschaeftspartners
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class Kontakt
    {
        /// <summary>
        /// Die Id des Kontaktes
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Faxnummer des Kontaktes
        /// </summary>
        [DataMember]
        public string Fax { get; set; }

        /// <summary>
        /// Die Strasse des Kontaktes
        /// </summary>
        [DataMember]
        public string Strasse { get; set; }
        
        /// <summary>
        /// Die Telefonnunmmer des Kontaktes
        /// </summary>
        [DataMember]
        public string Telefon { get; set; }
        
        /// <summary>
        /// Die Hausnummer des Kontaktes
        /// </summary>
        [DataMember]
        public string Hausnummer { get; set; }
        
        /// <summary>
        /// Die PLZ des Kontaktes
        /// </summary>
        [DataMember]
        public string PLZ { get; set; }
        
        /// <summary>
        /// Der Ort des Kontaktes
        /// </summary>
        [DataMember]
        public string Ort { get; set; }
        
        /// <summary>
        /// Die E-Mail des Kontaktes
        /// </summary>
        [DataMember]
        public string EMail { get; set; }
    }
}
