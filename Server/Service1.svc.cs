using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Server.DTOs;
using Server.Models;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static Dictionary<string, Felhasznalo> BejelentkezettFelhasznalok = new Dictionary<string, Felhasznalo>();
        public static Dictionary<string, Jogosultsag> BejelentkezettJogosultsagok = new Dictionary<string, Jogosultsag>();

        public List<Felhasznalo> FelhasznaloLista_CS()
        {
            List<Felhasznalo> lista = new List<Felhasznalo>();
            DataBaseManager.ISQL felhasznaloController = new Controllers.FelhasznalokController();
            List<Record> records = felhasznaloController.Select();
            foreach (Record record in records)
            {
                lista.Add(record as Felhasznalo);
            }
            return lista;
        }

        public List<Jogosultsag> JogosultsagLista_CS()
        {
            List<Jogosultsag> lista = new List<Jogosultsag>();
            DataBaseManager.ISQL jogosultsagController = new Controllers.FelhasznalokController();
            List<Record> records = jogosultsagController.Select();
            foreach (Record record in records)
            {
                lista.Add(record as Jogosultsag);
            }
            return lista;
        }

        public List<Felhasznalo> FelhasznaloLista_Web()
        {
            return FelhasznaloLista_CS();
        }

        public List<Jogosultsag> JogosultsagLista_Web()
        {
            return JogosultsagLista_CS();
        }

        public string FelhasznaloHozzaAd_CS(Felhasznalo felhasznalo)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Insert(felhasznalo);
        }

        public string FelhasznaloHozzaAd_Web(Felhasznalo felhasznalo)
        {
            return FelhasznaloHozzaAd_CS(felhasznalo);
        }

        public string JogosultsagHozzaAd_CS(Jogosultsag jogosultsag)
        {
            Controllers.JogosultsagokController jogosultsagokController = new Controllers.JogosultsagokController();
            return jogosultsagokController.Insert(jogosultsag);
        }

        public string JogosultsagHozzaAd_Web(Jogosultsag jogosultsag)
        {
            return JogosultsagHozzaAd_CS(jogosultsag);
        }

        public string FelhasznaloModosit_CS(Felhasznalo felhasznalo)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Update(felhasznalo);
        }

        public string FelhasznaloModosit_Web(Felhasznalo felhasznalo)
        {
            return FelhasznaloModosit_CS(felhasznalo);
        }

        public string JogosultsagModosit_CS(Jogosultsag jogosultsag)
        {
            Controllers.JogosultsagokController jogosultsagokController = new Controllers.JogosultsagokController();
            return jogosultsagokController.Update(jogosultsag);
        }

        public string JogosultsagModosit_Web(Jogosultsag jogosultsag)
        {
            return JogosultsagModosit_CS(jogosultsag);
        }

        public string FelhasznaloTorles_CS(int id)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Delete(id);
        }

        public string FelhasznaloTorles_Web(int id)
        {
            return FelhasznaloTorles_CS(id);
        }

        public string JogosultsagTorles_CS(int id)
        {
            Controllers.JogosultsagokController jogosultsagokController = new Controllers.JogosultsagokController();
            return jogosultsagokController.Delete(id);
        }

        public string JogosultsagTorles_Web(int id)
        {
            return JogosultsagTorles_CS(id);
        }

        public List<FelhasznaloEmailKuldes> FelhasznaloEmailCimek_CS()
        {
            List<FelhasznaloEmailKuldes> lista = new List<FelhasznaloEmailKuldes>();
            DataBaseManager.ISQL felhasznaloController = new Controllers.FelhasznalokController();
            List<Record> records = felhasznaloController.Select();
            foreach (Record record in records)
            {
                FelhasznaloEmailKuldes egyRecord = new FelhasznaloEmailKuldes();
                egyRecord.Email = (record as Felhasznalo).Email;
                egyRecord.Nev = (record as Felhasznalo).Nev;
                lista.Add(egyRecord);
            }
            return lista;
        }

        public List<FelhasznaloEmailKuldes> FelhasznaloEmailCimek_Web()
        {
            return FelhasznaloEmailCimek_CS();
        }

        public string GetSalt_CS(string LoginNev)
        {
            Controllers.LoginController loginController = new Controllers.LoginController();
            return loginController.GetSalt(LoginNev);
        }

        public string GetSalt_Web(string LoginNev)
        {
            return GetSalt_CS(LoginNev);
        }

        public string Login_CS(Login login)
        {
            Controllers.LoginController loginController = new Controllers.LoginController();
            return loginController.Login(login);
        }

        public string Login_Web(Login login)
        {
            return Login_CS(login);
        }
    }
}
