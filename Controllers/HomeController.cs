using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using iPDP.Models;

namespace iPDP.Controllers
{
    public class HomeController : Controller
    {
        public static Uniwersalny ZadUniwersalny = new Uniwersalny();
        //private static Uniwersalny ZadUniwersalny = new Uniwersalny(); //Ten tez dziala
        //private static TStdZadFilterPomp ZadUniFilter = new TStdZadFilterPomp();
        public ActionResult Index()
        {
            // Ustawienia otwarcia
            ViewBag.Producer_Skr = ZadUniwersalny.Producer_Skr;
            ViewBag.Producer_Mail = ZadUniwersalny.Producer_Mail;
            if (ZadUniwersalny != null)
            {
                ZadUniwersalny = null;
                ZadUniwersalny = new Uniwersalny();
            }
            ZadUniwersalny.LiczbaPomp = 0;  //"kasowanie listy"
            return View(ZadUniwersalny);
        }

        // ZERO kafelek
        public ActionResult ViewTreeKatalog()
        {
            ViewBag.Producer_Skr = ZadUniwersalny.Producer_Skr;
            ViewBag.Producer_Mail = ZadUniwersalny.Producer_Mail;


            DrzewoPomp drzewo = new DrzewoPomp();  // przygotowanie drzewa
            ViewBag.Json = drzewo.DajDrzewo();     // przygotowanie drzewa
            ZadUniwersalny.doborNaPunkt.Kafelek = "Tree";
            return View(ZadUniwersalny);
        }

        [HttpPost]
        public ActionResult ViewTreeKatalog(string Sciezka)
        {
            DrzewoPomp drzewo = new DrzewoPomp();  // przygotowanie drzewa
            ViewBag.Json = drzewo.DajDrzewo();     // przygotowanie drzewa
            ZadUniwersalny.doborNaPunkt.Sciezka = Sciezka;
            ZadUniwersalny.doborNaPunkt.Ustaw_ID();
            ZadUniwersalny.doborNaPunkt.Kafelek = "Tree";
            ZadUniwersalny.FilterList_ID();

            return View(ZadUniwersalny);
        }

        // pierwszy kafelek
        public ActionResult ViewDobor()
        {
            // Ustawienia otwarcia
            ZadUniwersalny.doborNaPunkt.Kafelek = "Dobor";

            return View(ZadUniwersalny);
        }

        // pierwszy kafelek
        [HttpPost]
        public ActionResult ViewDobor(string Qw_model, string Hw_model, string Kl_Zastosowania,
                                        string interfejs_Qw, string Interfejs_QwUnit)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            // 1. Ustawianie interfejsu
            ZadUniwersalny.Interfejs_Qw = Double.Parse(interfejs_Qw);    // Qw w jednostkach interfejsu do przekazania
            ZadUniwersalny.Interfejs_QwUnit = Interfejs_QwUnit;          // Jednostki interfejsu np. "m3/h"
            ZadUniwersalny.Interfejs_Hw = Double.Parse(Hw_model);        // Hw - wymagana

            // 2. Ustawianie modelu (tylko jeden poziom)
            ZadUniwersalny.Qw_model = Double.Parse(Qw_model);       // Qw_model
            ZadUniwersalny.Hw_model = Double.Parse(Hw_model);
            ZadUniwersalny.Kl_Zastosowania = Kl_Zastosowania;

            // 3. Przekazane do obliczen w DOBORU NA PUNKT
            ZadUniwersalny.doborNaPunkt.CharUkladu.Qw = Double.Parse(Qw_model);       // Qw_model
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hw = Double.Parse(Hw_model);       // Hw modelu
                                                                                      // Nie ma Hg, przyjęto Hg = Hw/2
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hg = ZadUniwersalny.doborNaPunkt.CharUkladu.Hw / 2;       // Hg modelu
            ZadUniwersalny.doborNaPunkt.Kl_Zastosown = Kl_Zastosowania;
            // 4. Ustawienie wyswietlania KartyKatalogowej 
            ZadUniwersalny.doborNaPunkt.Kafelek = "Dobor";                          // ustawianie kafalka do powrotu  

            ZadUniwersalny.Dobor();
            return View(ZadUniwersalny);
        }

        // drugi kafelek
        public ActionResult ViewProsty()
        {
            ZadUniwersalny.doborNaPunkt.Kafelek = "Prosty";
            return View(ZadUniwersalny);
        }
        // drugi kafelek
        [HttpPost]
        public ActionResult ViewProsty(string Qw_model, string Hw_model, string Hg_model, string Kl_Zastosowania,
                                        string interfejs_Qw, string Interfejs_QwUnit, string Interfejs_d, string Interfejs_L,
                                        string Interfejs_Dh, string Interfejs_Ph)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            // 1. Ustawianie interfejsu
            ZadUniwersalny.Interfejs_Qw = Double.Parse(interfejs_Qw);    // Qw w jednostkach interfejsu do przekazania
            ZadUniwersalny.Interfejs_QwUnit = Interfejs_QwUnit;          // Jednostki interfejsu np. "m3/h"
            ZadUniwersalny.Interfejs_d = Double.Parse(Interfejs_d);      // d - srednica w [mm]
            ZadUniwersalny.Interfejs_L = Double.Parse(Interfejs_L);      // L - dlugosc rurociagu w [m]
            ZadUniwersalny.Interfejs_Dh = Double.Parse(Interfejs_Dh);    // Dh - straty rurociagu w [m]
            ZadUniwersalny.Interfejs_Hg = Double.Parse(Hg_model);        // Hg - wysokosc geometryczna [m]
            ZadUniwersalny.Interfejs_Hw = Double.Parse(Hw_model);        // Hw - wymagana
            ZadUniwersalny.Interfejs_Ph = Double.Parse(Interfejs_Ph);    // Ph - moc hydrauliczna

            // 2. Ustawianie modelu (html @model przyjmuje tylko jeden poziom)
            ZadUniwersalny.Qw_model = Double.Parse(Qw_model);       // Qw_model
            ZadUniwersalny.Hw_model = Double.Parse(Hw_model);
            ZadUniwersalny.Hg_model = Double.Parse(Hg_model);
            ZadUniwersalny.Kl_Zastosowania = Kl_Zastosowania;

            // 3. Przekazane do obliczen w DOBORU NA PUNKT
            ZadUniwersalny.doborNaPunkt.CharUkladu.Qw = Double.Parse(Qw_model);       // Qw_model
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hg = Double.Parse(Hg_model);       // Hg modelu
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hw = Double.Parse(Hw_model);       // Hw modelu
            ZadUniwersalny.doborNaPunkt.Kl_Zastosown = Kl_Zastosowania;
            // 4. Ustawienie wyswietlania KartyKatalogowej 
            ZadUniwersalny.doborNaPunkt.Kafelek = "Prosty";                          // ustawianie kafalka do powrotu  

            ZadUniwersalny.Dobor();
            return View(ZadUniwersalny);
        }


        public ActionResult ViewUniwersalny()
        {
            ZadUniwersalny.LiczbaPomp = 0;

            // Ustawienia otwarcia
            ZadUniwersalny.Interfejs_Qw = 10;
            ZadUniwersalny.Interfejs_Hw = 10;
            ZadUniwersalny.Interfejs_Hg = 6;
            ZadUniwersalny.U_odleglosc = 25;
            ZadUniwersalny.U_lustro = 2;
            ZadUniwersalny.U_wysokosc = 8;

            return View(ZadUniwersalny);
        }

        [HttpPost]
        public ActionResult ViewUniwersalny(string U_Qw, string U_Hw, string U_Hg)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            ZadUniwersalny.doborNaPunkt.CharUkladu.Qw = Double.Parse(U_Qw);
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hw = Double.Parse(U_Hw);
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hg = Double.Parse(U_Hg);

            ZadUniwersalny.Interfejs_Qw = ZadUniwersalny.doborNaPunkt.CharUkladu.Qw;
            ZadUniwersalny.Interfejs_Hw = ZadUniwersalny.doborNaPunkt.CharUkladu.Hw;
            ZadUniwersalny.Interfejs_Hg = ZadUniwersalny.doborNaPunkt.CharUkladu.Hg;

            ZadUniwersalny.Dobor();
            return View(ZadUniwersalny);
        }

        // trzeci kafelek
        public ActionResult ViewPrzepompownia()
        {
            ZadUniwersalny.LiczbaPomp = 0;

            // Ustawienia otwarcia
            ZadUniwersalny.Interfejs_Qw = 10;
            ZadUniwersalny.Interfejs_Hw = 10;
            ZadUniwersalny.Interfejs_Hg = 6;
            ZadUniwersalny.U_odleglosc = 25;
            ZadUniwersalny.U_lustro = -2;
            ZadUniwersalny.U_wysokosc = 4;

            return View(ZadUniwersalny);
        }

        [HttpPost]
        public ActionResult ViewPrzepompownia(string U_Qw, string U_Hw, string U_Hg)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            ZadUniwersalny.doborNaPunkt.CharUkladu.Qw = Double.Parse(U_Qw);
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hw = Double.Parse(U_Hw);
            ZadUniwersalny.doborNaPunkt.CharUkladu.Hg = Double.Parse(U_Hg);

            ZadUniwersalny.Interfejs_Qw = ZadUniwersalny.doborNaPunkt.CharUkladu.Qw;
            ZadUniwersalny.Interfejs_Hw = ZadUniwersalny.doborNaPunkt.CharUkladu.Hw;
            ZadUniwersalny.Interfejs_Hg = ZadUniwersalny.doborNaPunkt.CharUkladu.Hg;

            ZadUniwersalny.Dobor();
            return View(ZadUniwersalny);
        }

        public ActionResult ViewKartaKatalogowa(int tNr)
        {
            ZadUniwersalny.NrPompy = tNr;
            ZadUniwersalny.doborNaPunkt.CharUkladu.Qmax = ZadUniwersalny.doborNaPunkt.listaPompZBazy.fLista[ZadUniwersalny.NrPompy].CharPompy.H_Qmax;

            ViewBag.Kafelek = ZadUniwersalny.doborNaPunkt.Kafelek;
            if (ZadUniwersalny.doborNaPunkt.Filtruj)
            {
                ViewBag.Filter = "true";
            }
            else
            {
                ViewBag.Filter = "false";
            }

            return View(ZadUniwersalny);
        }

        public ActionResult About()
        {
            return View(ZadUniwersalny);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    }
}
