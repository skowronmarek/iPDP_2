using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;



namespace iPDP.Models
{
    public class Tzast
        {
            public string Skr { get; set; }
            public string Opis { get; set; }
            //public int LiPomp { get; set; }
        }
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
        public string Producer_DBpath = "XXX";
        public string Producer_RysPre = "XXX";
        public string Producer_OpisPre = "XXX";

        public IList<Tzast> ListaZast = new List<Tzast>();
        
        public XmlDocument Xml_iPDP = new XmlDocument();
        public XmlNode myNode;
        public XmlNode zasNode;  // do czytania zastosowań
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
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("DBpath");
            Producer_DBpath = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Opisy");
            Producer_OpisPre = myNode.InnerText;
            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Rysunki");
            Producer_RysPre  = myNode.InnerText;

            myNode = Xml_iPDP.SelectSingleNode("IPDP_CONFIG").SelectSingleNode(Producer_ID).SelectSingleNode("Zastosowania");
            if (myNode.HasChildNodes) 
                {
                    foreach (XmlNode odczNode in myNode.ChildNodes) 
                    {
                        Tzast Zastosowanie = new Tzast();
                        zasNode = odczNode.SelectSingleNode("skr");
                        Zastosowanie.Skr = zasNode.InnerText;
                        zasNode = odczNode.SelectSingleNode("opis");
                        Zastosowanie.Opis = zasNode.InnerText;
                        ListaZast.Add(Zastosowanie);                
                    }
                    
                }
        }

    }
}
