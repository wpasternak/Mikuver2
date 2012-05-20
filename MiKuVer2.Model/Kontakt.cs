using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model
{
    /// <summary>
    /// Die Kontaktdaten eines Unternehmens und/oder einer Person
    /// </summary>
    public abstract class Kontakt
    {
        /// <summary>
        /// Die Id des Kontaktes
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Faxnummer des Kontaktes
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Die Strasse des Kontaktes
        /// </summary>
        public string Strasse { get; set; }
        
        /// <summary>
        /// Die Telefonnunmmer des Kontaktes
        /// </summary>
        public string Telefon { get; set; }
        
        /// <summary>
        /// Die Hausnummer des Kontaktes
        /// </summary>
        public string Hausnummer { get; set; }
        
        /// <summary>
        /// Die PLZ des Kontaktes
        /// </summary>
        public string PLZ { get; set; }
        
        /// <summary>
        /// Der Ort des Kontaktes
        /// </summary>
        public string Ort { get; set; }
        
        /// <summary>
        /// Die E-Mail des Kontaktes
        /// </summary>
        public string EMail { get; set; }
    }
}
