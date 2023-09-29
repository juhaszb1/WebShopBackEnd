using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class MyServiceAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {

            HttpResponseMessageProperty prop = new HttpResponseMessageProperty();
            prop.Headers.Add("Access-Control-Allow-Origin", "*");
            operationContext.OutgoingMessageProperties.Add(HttpResponseMessageProperty.Name, prop);

            return true;
        }
    }
}
