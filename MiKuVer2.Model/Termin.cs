using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model
{
    /// <summary>
    /// Termindaten
    /// </summary>
    class Termin
    {
        /// <summary>
        /// Der Titel des Termins
        /// </summary>
        public string Titel { get; set; }

        /// <summary>
        /// Die Beschreibung des Termins
        /// </summary>
        public string Beschreibung { get; set; }

        /// <summary>
        /// Das Datum an dem der Termin erstellt wurde
        /// </summary>
        public DateTime ErstelltAm { get; set; }

        /// <summary>
        /// Der Beginn des Termins
        /// </summary>
        public DateTime Von { get; set; }

        /// <summary>
        /// Das Ende des Termins
        /// </summary>
        public DateTime Bis { get; set; }

        /// <summary>
        /// Ganztagsereignis oer nicht?!
        /// </summary>
        public bool Ganztagsereignis { get; set; }

        /// <summary>
        /// Die zusaetzlich zu benachrichtigenden Geschaeftspartner
        /// </summary>
        public List<Geschaeftspartner> BenachrichtigungAn { get; set; }

        /// <summary>
        /// Terminart
        /// </summary>
        public Terminart Terminart { get; set; }
    }
}
