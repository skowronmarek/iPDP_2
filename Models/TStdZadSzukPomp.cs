using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Web;
using System.Data.SqlClient;


namespace iPDP.Models
{
 
    public class TStdZadSzukPomp: IPDP
    {
 
        public TStdDoborNaPunkt doborNaPunkt = new TStdDoborNaPunkt();

        public string Kl_Zastosowania { get; set; } = "ogol";
        public string Kl_Zasilania { get; set; } = "'3x400'";

        public TPompa WybranaPompa = new TPompa();
        public int LiczbaPomp = 0;
        public double Qr { get; set; }

        public double W_Efi = 0.3;
        public double W_DQr = 0.3;
        public double W_DQn = 0.3;

        public double K_DQr = 0;
        public double K_DQn = 0;

        public double D_Efi = 0.5; // dobroc 
        public double D_DQr = 0.5;

        public void Dobor()
        {
            doborNaPunkt.DoborNaPunkt();          // wyszukuje pompy w bazie bez oceny
            doborNaPunkt.CharUkladu.Aktualizuj(); // przelicza charakterystyke ukladu 

            LiczDobroc();                 // dopisuje wartosci dobroci do listy
            //ListaZnalPompTmp  = doborNaPunkt.listaPompZBazy;
            SortWgDobroc();               // tworzy posortowana liste 10 pomp
            LiczbaPomp = doborNaPunkt.LiczbaZnalPomp;
            if (LiczbaPomp > 10)
            {
                LiczbaPomp = 10;
            };

        }

        public void FilterList_ID()
        {
            doborNaPunkt.Filtruj = true;
            doborNaPunkt.DoborNaPunkt();                // wyszukuje pompy w bazie bez oceny
            doborNaPunkt.CharUkladu.char_Hu_Str = "[]"; // blokuje charakterystyke ukladu 
            doborNaPunkt.CharUkladu.Qw_Str = "[]";      // blokiouje punkt nominalny
            doborNaPunkt.CharUkladu.pw_Str = "[]";      // blokiouje punkt nominalny

            LiczbaPomp = doborNaPunkt.LiczbaZnalPomp;
        }

        public void LiczDobroc()
        {
            foreach (TPompa pompa in doborNaPunkt.listaPompZBazy.fLista)
            {
                pompa.CharPompy.ObliczWsp();
                pompa.WorkPoint(doborNaPunkt.CharUkladu);
                pompa.Pr = pompa.CharPompy.P(pompa.Qr);
                pompa.ETAr = pompa.Eta_r_H2O();

                K_DQr = 1 - Math.Abs((doborNaPunkt.CharUkladu.Qw - pompa.Qr) / doborNaPunkt.CharUkladu.Qw) - Math.Abs((doborNaPunkt.CharUkladu.Hw - pompa.Hr) / doborNaPunkt.CharUkladu.Hw);

                D_DQr = W_DQr * K_DQr;
                D_Efi = W_Efi * pompa.ETAr;
                pompa.Dobroc = D_DQr + D_Efi;
            }
        }

        public void SortWgDobroc()    // sorowanie babelkowe - mozna przyspieszyc przez odcinanie najmniejszych
        {
            int i = 0;
            int j = 0;
            TPompa tmpPompa = new TPompa();

            while (j < doborNaPunkt.LiczbaZnalPomp)
            {
                while (i < doborNaPunkt.LiczbaZnalPomp - 1)
                {
                    if (doborNaPunkt.listaPompZBazy.fLista[i].Dobroc < doborNaPunkt.listaPompZBazy.fLista[i + 1].Dobroc)
                    {
                        tmpPompa = doborNaPunkt.listaPompZBazy.fLista[i];
                        doborNaPunkt.listaPompZBazy.fLista[i] = doborNaPunkt.listaPompZBazy.fLista[i + 1];
                        doborNaPunkt.listaPompZBazy.fLista[i + 1] = tmpPompa;
                    }
                    i++;
                }
                i = 0;
                j++;
            }

        }
        public string DajZastosowanie()    // sorowanie babelkowe - mozna przyspieszyc przez odcinanie najmniejszych
        {
            string Zast = "";

            switch (Kl_Zastosowania)
            {
                case "scie":
                    Zast = "Ścieki";
                    break;
                case "przem":
                    Zast = "Przemysłowe";
                    break;
                case "sam":
                    Zast = "Samozasysające";
                    break;
                default:
                    Zast = "Ogólne";
                    break;
            };
            return Zast;
        }

    }
}