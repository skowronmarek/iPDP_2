using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace iPDP.Models
{
    public class IPDP
    {
        public string Producer_ID = "XXX";
        public string Producer_Name = "XXX";
        public string Producer_Skr = "XXX";
        public string Producer_Adres = "XXX";
        public string Producer_Logo = "XXX";
        public string Producer_WWW = "XXX";
        public string Producer_Mail = "XXX";
        public string Producer_Tel = "XXX";

        public XmlDocument Xml_iPDP = new XmlDocument();
        public XmlNode myNode;
        public IPDP() // constructor
        {
            Xml_iPDP.Load("wwwroot/iPDP.xml");
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode("PRODUCER");
            Producer_ID = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Nazwa");
            Producer_Name = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Nazwa_Skr");
            Producer_Skr = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Adres");
            Producer_Adres = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Logo");
            Producer_Logo = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("WWW");
            Producer_WWW = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Mail");
            Producer_Mail = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Tel");
            Producer_Tel = myNode.InnerText;            
        }

    }
}
