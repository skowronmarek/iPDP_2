using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Drawing;



namespace iPDP.Models
{   
    public enum TLinkTyp
    {
        tpBrak,
        tpPipe, //rura
        tpPump,  //pompa
        tpValve,
        tpChlodnica,   // do sprawdzenia czu zastosować globalnie
        tpTermoElem,   // do sprawdzenia czu zastosować globalnie

        tpCV//,           // pipe with check valve, rura z zaworem zwrotnym
        // tPRV,          // pressure reducing valve, zawór redukcyjny
        // tPSV,          // pressure sustaining valve, zawór stalego cisnienia
        // tPBV,          // pressure breaker valve, zawor różnicowy
        // tFCV,          // flow control valve, zawór przeplywu granicznego
        // tTCV,          // throttle control valve, zawór dlawiący
        // tGPV           //  general purpose valve, zawór uniwersalny
    }

    public enum TLinkStatus
    {
        sDummy,      // szkielet bez danych
        sOpen,       // otwarty
        sClosed,     // zamkniety
        sActive,     // aktywny np. zawor   
        sNotActive,  // nie aktywny=wylaczony np maszyna        
        sCV          // zawor zwrotny
    }
    
    public class TLink
    {
        public string ID;
        public string Nazwa;
        public TLinkTyp Typ;
        public TLinkStatus Status;

        public TLink()
        {
            ID = "Brak";
            Typ = TLinkTyp.tpBrak;
            Status = TLinkStatus.sDummy;

            ///Bitmap
        }
    }
}

