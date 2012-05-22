using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MiKuVer2.Model
{
    [DataContract(IsReference = true)]
    public class Terminart
    {
        /// <summary>
        /// Die Id der Terminart
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Der Name der Terminart
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
