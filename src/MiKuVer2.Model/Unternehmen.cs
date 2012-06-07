using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MiKuVer2.Model
{
    /// <summary>
    /// Die Unternehmensdaten der Klasse Unternehmen
    /// </summary>
    [DataContract(IsReference = true)]
    public class Unternehmen : Kontakt
    {
        /// <summary>
        /// Der Name des Unternehmens
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Der Ansprechpartner des Unternehmens
        /// </summary>
        [DataMember]
        public string Ansprechpartner { get; set; }

        /// <summary>
        /// Die Webseite des Unternehmens
        /// </summary>
        [DataMember]
        public string Webseite { get; set; }

        /// <summary>
        /// Alle Mitarbeiter des Unternehmens, welche Kunden sind
        /// </summary>
        [DataMember]
        public List<Kunde> Angestellte { get; set; }
    }
}
