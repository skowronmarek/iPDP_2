using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace iPDP.Models
{
    /******************************************/
    /* Glowna klasa pompy dziedziczy po Linku */
    /******************************************/
    public class TPompa : TLink   //do sieci, do polaczenia z TPompa   // Do polaczenia z CalssPompa
    {
        // POMPA
        public int Id;             // do sprawdzenia
        public string ProductNo;   // do sprawdzenia
        public double Qn;
        public double Hn;
        public double Pn;
        public double nn; // nominalna prędkosc obrotowa
        public double Qmin;
        public double Qmax;
        // MOTOR                           przeniesc DO OBIEKTU MOTOR
        public string M_Zas;
        public double M_Pzn;
        public double M_Uzn;
        public double M_Izn;
        public double M_COSFzn;
        public int M_LFaz;
        public int M_FREK;
        // GEOMETRIA
        public double G_PARN1;
        public double G_Masa;
        public string G_PDF;
        // TYP
        public string Opis_PDF;
        public string KL_ZAST;
        public string GRUPA;

        public string char_H_Str;   //stringi do wyswietlania charakterystyk
        public string char_P_Str;
        public string char_E_Str;

        public TStdCharPompy CharPompy = new TStdCharPompy();  //Standardowy zapis charakterystyk jako punkty

        double FQr;
        double FHr;
        double FPr;
        double FNPSHr;
        double FETAr;
        double FDobroc;
        public string Nazwa { get; set; }

        public double Qr
        {
            get { return Math.Round(FQr, 2); }
            set { FQr = value; }
        }
        public double Hr
        {
            get { return Math.Round(FHr, 2); }
            set { FHr = value; }
        }

        public double Pr
        {
            get { return Math.Round(FPr, 2); }
            set { FPr = value; }
        }
        public double NPSHr
        {
            get { return FNPSHr; }
            set { FNPSHr = value; }
        }
        public double ETAr
        {
            get { return Math.Round(FETAr, 3); }
            set { FETAr = value; }
        }
        public double ETAr_proc
        {
            get { return Math.Round(FETAr * 100, 1); }
            set { FETAr = value; }
        }


        public double Dobroc
        {
            get { return Math.Round(FDobroc, 4); }
            set { FDobroc = value; }
        }

        public double Daj_Pr()  // Oblicza moc rzeczywista
        {
            return Qr * 3600 * Hr * 1000 * 9.81 / Pr / 1000;
        }

        public double Eta_r_H2O()  // Oblicza sprawnosc w punkcie pracy przy pompowaniu wody
        {
            if (Pr > 0)
            {
                return Qr / 3600 * Hr * 1000 * 9.81 / Pr / 1000;
            }
            else
            {
                return 0;
            }

        }


        public int x = 33;   // Co to jest?
        public int y = 44;

        public TPompa() // constructor
        {
            Qr = 22;


        }

        // Zwraca Qr na podstawie bisekcji
        public bool WorkPoint(TStdCharSel CharSel)
        {
            double min;
            double max;
            double vQ;
            double vH;
            double vHmin;
            double vHmax;

            Qr = 0;
            Hr = 0;
            min = CharPompy.H_Qmin;
            max = CharPompy.H_Qmax;
            vQ = (max + min) / 2;

            vHmin = CharSel.Hu(min) - CharPompy.H(min);
            vHmax = CharSel.Hu(max) - CharPompy.H(max);

            while (((vHmin * vHmax) < 0) & ((max - min) > 0.001))
            {
                vQ = (max + min) / 2;
                vH = CharSel.Hu(vQ) - CharPompy.H(vQ);
                if ((vH * vHmin) > 0)
                {
                    min = vQ;
                    vHmin = vH;
                }
                else
                {
                    max = vQ;
                    vHmax = vH;
                }
            }
            if ((vHmin * vHmax) < 0)
            {
                Qr = vQ;
                Hr = CharSel.Hu(vQ);
                return true;
            }
            else
                return false;

        }

    }
}
