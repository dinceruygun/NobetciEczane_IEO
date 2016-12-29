using NobetciEczane_IEO.CHZDataEntity;
using NobetciEczane_IEO.XMLDataParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NobetciEczane_IEO
{
    public class NCZEczane
    {
        IEOService.nobetWebServiceSoapClient client;

        public NCZEczane()
        {
            client = new IEOService.nobetWebServiceSoapClient();

            var customBinding = new CustomBinding(client.Endpoint.Binding);
            var transportElement = customBinding.Elements.Find<HttpTransportBindingElement>();
            transportElement.KeepAliveEnabled = true;

            client.Endpoint.Binding = customBinding;
            client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 25, 0);

        }

        public NCZNobetciEczaneCollection GetNobetciEczane(DateTime startDate, DateTime endDate, NCZIlce ilce)
        {
            

            if (client.State != CommunicationState.Closed)
            {
                client.Abort();
                client.Close();
                client = null;
            }


            client = new IEOService.nobetWebServiceSoapClient();


            var result = client.getNobet(
                NCZParameters.Parameters["userName"],
                NCZParameters.Parameters["password"],
                startDate.Date.ToString("yyyy-MM-dd"),
                endDate.AddDays(1).Date.ToString("yyyy-MM-dd"),
                ilce != null ? ilce.id : int.Parse(NCZParameters.Parameters["id"]));


            var parser = new NCZXMLDataParser();
            var retcollection = parser.Parse(result);

            retcollection.StartDate = startDate;
            retcollection.EndDate = endDate;


            return retcollection;
        }

        internal NCZIlce GetIlce(string name)
        {

            if (client.State != CommunicationState.Closed)
            {
                client.Abort();
                client.Close();
                client = null;
            }


            client = new IEOService.nobetWebServiceSoapClient();

            var result = client.getIlceler(NCZParameters.Parameters["userName"], NCZParameters.Parameters["password"]);

            var parser = new NCZXMLDataParser();
            var ilceler = parser.ParseIlceler(result);




            return ilceler != null ? ilceler.Find(i => i.ad == name) : null;
        }
    }
}
