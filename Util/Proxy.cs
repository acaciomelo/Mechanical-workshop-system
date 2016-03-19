using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MechTech.Util
{
    public class Proxy
    {
        public Proxy(string servico)
        {
            // Proxy Authenticate
            WebRequest.DefaultWebProxy = new WebProxy("192.168.0.3", 8080);
            WebRequest.DefaultWebProxy.Credentials = new NetworkCredential("", "");

            this.Binding = new WSHttpBinding(SecurityMode.None);
            this.Binding.MaxReceivedMessageSize = 1000000;

            // ATENÇÃO: quando for usar servidor remoto, colocar a propriedade UseDefaultWebProxy como true.
            this.Binding.UseDefaultWebProxy = false;

            //this.EndPoint = new EndpointAddress(new Uri("http://127.0.0.1:50001/" + servico));
            //this.EndPoint = new EndpointAddress(new Uri("http://192.168.0.5:50001/" + servico));
            this.EndPoint = new EndpointAddress(new Uri("http://201.91.63.57:50001/" + servico)); // MECHTECH
        }

        public EndpointAddress EndPoint { get; set; }
        public WSHttpBinding Binding { get; set; }
        public ClientCredentials Credencial { get; set; }
    }
}