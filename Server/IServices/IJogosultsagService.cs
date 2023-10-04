using Google.Protobuf.WellKnownTypes;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;

namespace Server.IServices
{
    [ServiceContract]
    public interface IJogosultsagService
    {
        [OperationContract]

        List<Jogosultsag> JogosultsagLista_CS();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/JogosultsagLista/")]

        List<Jogosultsag> JogosultsagLista_Web();

        [OperationContract]
        string JogosultsagHozzaAd_CS(Jogosultsag jogosultsag);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/JogosultsagHozzaAd/")]

        string JogosultsagHozzaAd_Web(Jogosultsag jogosultsag);

        [OperationContract]
        string JogosultsagModosit_CS(Jogosultsag jogosultsag);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/JogosultsagModosit/")]

        string JogosultsagModosit_Web(Jogosultsag jogosultsag);

        [OperationContract]
        string JogosultsagTorles_CS(int id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/JogosultsagTorles?id={id}")]

        string JogosultsagTorles_Web(int id);
    }
}
