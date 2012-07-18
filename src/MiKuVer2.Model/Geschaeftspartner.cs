using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace MiKuVer2.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Die Geschaeftspartnerdaten
    /// </summary>
    [DataContract(IsReference = true)]
    public class Geschaeftspartner : Person
    {
        private List<Geschaeftspartner> partner;

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
        public List<Geschaeftspartner> Partner
        {
            get
            {
                return this.partner ?? (this.partner = new List<Geschaeftspartner>());
            }
            set
            {
                this.partner = value;
            }
        }

        /// <summary>
        /// Das Eintrittsdatum des Geschaeftspartners in das Unternehmen
        /// </summary>
        [DataMember]
        [DataType(DataType.Date, ErrorMessage = "Ungültiges Eintrittsdatum")]
        [RegularExpression(@"^([0-9]{2}).([0-9]{2}).([0-9]{4})", ErrorMessage = "Bitte Eintrittsdatum (TT.MM.JJJJ) überprüfen")]
        public DateTime Eintrittsdatum { get; set; }

        [DataMember]
        [DataType(DataType.Text, ErrorMessage = "Ungültige Personalnummer")]
        [RegularExpression(@"^[0-9]{1,45}", ErrorMessage = "Bitte Personalnummer überprüfen")]
        public string MitarbeiterNummer { get; set; }
    }
}
