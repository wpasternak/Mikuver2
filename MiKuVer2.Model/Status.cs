using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MiKuVer2.Model
{
    [DataContract(IsReference = true)]
    class Status
    {
        /// <summary>
        /// Die Id des Statuses
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Der Name des Statuses
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
