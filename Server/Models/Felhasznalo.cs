using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace Server.Models
{
    [DataContract]
    public class Felhasznalo : Record
    {
        [DataMember]
        public string LoginNev { get; set; }

        [DataMember]
        public string HASH { get; set; }

        [DataMember]
        public string SALT { get; set; }

        [DataMember]
        public string Nev { get; set; }

        [DataMember]
        public byte Jog { get; set; }

        [DataMember]
        public bool Aktiv { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string ProfilKep { get; set; }

        [OperationContract]

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Login név: {LoginNev}\n" +
                $"HASH: {HASH}\n" +
                $"SALT: {SALT}\n" +
                $"Név: {Nev}\n" +
                $"Jog: {Jog}\n" +
                $"Aktív: {(Aktiv ? "Igen" : "Nem")}\n" +
                $"Email: {Email}\n" +
                $"Profilkép útvonala: {ProfilKep}";
        }
    }
}