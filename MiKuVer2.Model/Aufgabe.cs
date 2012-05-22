using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MiKuVer2.Model
{
    [DataContract(IsReference = true)]
    public class Aufgabe
    {
        /// <summary>
        /// Der Titel der Aufgabe
        /// </summary>
        [DataMember]
        public string Titel { get; set; }

        /// <summary>
        /// Die Beschreibung der Aufgabe
        /// </summary>
        [DataMember]
        public string Beschreibung { get; set; }

        /// <summary>
        /// Der Beginn der Aufgabe
        /// </summary>
        [DataMember]
        public DateTime ErstelltAm { get; set; }

        /// <summary>
        /// Der Status der Aufgabe
        /// </summary>
        [DataMember]
        public Status Status { get; set; }

        /// <summary>
        /// Das Ende der Aufgabe
        /// </summary>
        [DataMember]
        public DateTime FaelligAm { get; set; }

        /// <summary>
        /// Der Geschaeftspartner der die Aufgabe erstellt hat
        /// </summary>
        [DataMember]
        public Geschaeftspartner ErstelltVon { get; set; }

        /// <summary>
        /// Die Geschaeftspartner die mitbeteiligt
        /// </summary>
        [DataMember]
        public List<Geschaeftspartner> Bearbeiter { get; set; }

        /// <summary>
        /// Die Kategorie der Aufgabe
        /// </summary>
        [DataMember]
        public Kategorie Kategorie { get; set; }
    }
}
