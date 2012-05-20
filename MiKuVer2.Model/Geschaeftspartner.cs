using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Model
{
    /// <summary>
    /// Die Geschaeftspartnerdaten
    /// </summary>
    public class Geschaeftspartner : Person
    {
        /// <summary>
        /// Der Vorgesetzte des jeweiligen Geschaeftspartners
        /// </summary>
        public Geschaeftspartner Vorgesetzter { get; set; }

        /// <summary>
        /// Die untergeordneten Geschaeftspartner des jeweiligen Geschaefts-
        /// pertners
        /// </summary>
        public List<Geschaeftspartner> Partner { get; set; }

        /// <summary>
        /// Das Eintrittsdatum des Geschaeftspartners in das Unternehmen
        /// </summary>
        public DateTime Eintrittsdatum { get; set; }
    }
}
