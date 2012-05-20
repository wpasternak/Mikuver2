using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model
{
    /// <summary>
    /// Die Personendaten des Kunden oder der Geschaeftspartner
    /// </summary>
    public class Person : Kontakt
    {
        /// <summary>
        /// Der Vorname der Person
        /// </summary>
        public string Vorname { get; set; }

        /// <summary>
        /// Der Nachname der Person
        /// </summary>
        public string Nachname { get; set; }

        /// <summary>
        /// Der Geburtstag der Person
        /// </summary>
        public DateTime Geburtstag { get; set; }

        /// <summary>
        /// Das Geschlecht der Person
        /// </summary>
        public bool Geschlecht { get; set; }
    }
}
