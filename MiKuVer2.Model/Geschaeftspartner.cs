using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace MiKuVer2.Model
{
    /// <summary>
    /// Die Geschaeftspartnerdaten
    /// </summary>
    [DataContract(IsReference = true)]
    public class Geschaeftspartner : Person
    {
        /// <summary>
        /// Der Vorgesetzte des jeweiligen Geschaeftspartners
        /// </summary>
        [DataMember]
        public Geschaeftspartner Vorgesetzter { get; set; }

        /// <summary>
        /// Die untergeordneten Geschaeftspartner des jeweiligen Geschaefts-
        /// pertners
        /// </summary>
        [DataMember]
        public List<Geschaeftspartner> Partner { get; set; }

        /// <summary>
        /// Das Eintrittsdatum des Geschaeftspartners in das Unternehmen
        /// </summary>
        [DataMember]
        public DateTime Eintrittsdatum { get; set; }
    }
}
