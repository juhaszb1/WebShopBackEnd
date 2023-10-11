using Google.Protobuf.WellKnownTypes;
using Server.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;
using System.Web.UI.WebControls;

namespace Server.IServices
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        string GetSalt_CS(string LoginNev);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/GetSalt")]

        string GetSalt_Web(string LoginNev);

        [OperationContract]
        FelhasznaloKezeloDTO Login_CS(Server.Models.Login login);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Login")]

        FelhasznaloKezeloDTO Login_Web(Server.Models.Login login);
    }
}
