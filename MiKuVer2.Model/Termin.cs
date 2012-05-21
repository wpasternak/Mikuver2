using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MiKuVer2.Model
{
    /// <summary>
    /// Termindaten
    /// </summary>
    [DataContract(IsReference = true)]
    class Termin
    {
        /// <summary>
        /// Der Titel des Termins
        /// </summary>
        [DataMember]
        public string Titel { get; set; }

        /// <summary>
        /// Die Beschreibung des Termins
        /// </summary>
        [DataMember]
        public string Beschreibung { get; set; }

        /// <summary>
        /// Das Datum an dem der Termin erstellt wurde
        /// </summary>
        [DataMember]
        public DateTime ErstelltAm { get; set; }

        /// <summary>
        /// Der Beginn des Termins
        /// </summary>
        [DataMember]
        public DateTime Von { get; set; }

        /// <summary>
        /// Das Ende des Termins
        /// </summary>
        [DataMember]
        public DateTime Bis { get; set; }

        /// <summary>
        /// Ganztagsereignis oder nicht?!
        /// </summary>
        [DataMember]
        public bool Ganztagsereignis { get; set; }

        /// <summary>
        /// Die zusaetzlich zu benachrichtigenden Geschaeftspartner
        /// </summary>
        [DataMember]
        public List<Geschaeftspartner> BenachrichtigungAn { get; set; }

        /// <summary>
        /// Terminart
        /// </summary>
        [DataMember]
        public Terminart Terminart { get; set; }
    }
}
