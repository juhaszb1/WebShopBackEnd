using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace Server.Models
{
    [DataContract]
    public class Jogosultsag : Record
    {
        [DataMember]
        public byte Szint { get; set; }

        [DataMember]
        public string Nev { get; set; }

        [OperationContract]

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Szint: {Szint}\n" +
                $"Név: {Nev}\n";
        }
    }
}