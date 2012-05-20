using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model
{
    /// <summary>
    /// Die Unternehmensdaten der Klasse Unternehmen
    /// </summary>
    public class Unternehmen : Kontakt
    {
        /// <summary>
        /// Der Name des Unternehmens
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Der Ansprechpartner des Unternehmens
        /// </summary>
        public string Ansprechpartner { get; set; }

        /// <summary>
        /// Die Webseite des Unternehmens
        /// </summary>
        public string Webseite { get; set; }

        /// <summary>
        /// Alle Mitarbeiter des Unternehmens, welche Kunden sind
        /// </summary>
        public List<Kunde> Angestellte { get; set; }
    }
}
