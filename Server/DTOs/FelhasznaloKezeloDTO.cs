using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Server.DTOs
{
    [DataContract]
    public class FelhasznaloKezeloDTO
    {
        [DataMember]
        public string Uid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public byte Jog { get; set; }
    }
}