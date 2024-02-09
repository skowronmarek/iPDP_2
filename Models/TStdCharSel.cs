using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web;
using System.Runtime.Serialization;
//using System.EnterpriseServices;

namespace iPDP.Models
{
    /****************************************************/
    /* STANDARDOWA, paraboliczna charakterystyka ukladu */
    /****************************************************/
    public class TStdCharSel
    {
        public double Qw { get; set; } = 10; // [m] parametry wymagane
        public double Hw { get; set; } = 10; // [m]
        public double Hg { get; set; } = 5;  // [m]
        public double Qmax { get; set; } = 1;      // max charakterytki ukladu
        public double QminTol { get; set; } = 0.5; // Tolerancja punktu nominalnego 
        public double QmaxTol { get; set; } = 1.5;
        public double HminTol { get; set; } = 0.5;
        public double HmaxTol { get; set; } = 1.5;
        public string Qw_Str { get; set; } ="";
        public string Hw_Str { get; set; } = "";
        public string char_Hu_Str { get; set; } = "";
        public string pw_Str { get; set; } = "";     // punkt wymagany

        public int n_ptu;                           // Punkty do wyswietlania charakterystyki ukladu
        public double[] TabQw;
        public double[] TabHw;

        public string[] TabQwStr; // dane do wykresu
        public string[] TabHwStr;
            



        public double R                            // Rezystancja rurociagu
        {
            get
            {
                return (Hw - Hg) / Math.Pow(Qw, 2);
            }
        }

        public double Hu(double Q)                 // Wysokosc cisnienia ukladu
        {
            return Hg + R * Math.Pow(Q, 2);
        }


        public TStdCharSel()                       // Construktor
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();  // Ustawiwnia kropki
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            n_ptu = 10;

            TabQw = new double[n_ptu];
            TabHw = new double[n_ptu];

            TabQwStr = new string[n_ptu];
            TabHwStr = new string[n_ptu];


            Aktualizuj();

        }

        public void Aktualizuj()              // Przelicza standardowa charakterystyke ukladu    
        {
            
            
            char_Hu_Str = "[";
            //TabQw[0] = Math.Round(Qmax / 10 * 0, 2);
            //TabQw[0] = Math.Round(Qw * 1.5 / 10 * 0, 2);
            TabQw[0] = Math.Round(Qw * 1.3 / 10 * 0, 2);
            //TabQw[0] = Math.Round(Qmax * 1.3 / 10 * 0, 2);
            TabQwStr[0] = Convert.ToString(TabQw[0]);

            TabHw[0] = Math.Round(Hg + R * Math.Pow(TabQw[0], 2), 2);
            TabHwStr[0] = Convert.ToString(TabHw[0]);

            char_Hu_Str = char_Hu_Str + "{ x: " + Convert.ToString(TabQw[0]) + ", y:" + Convert.ToString(TabHw[0]) + "}";

            for (int i = 1; i < 10; i++)
            {
                //TabQw[i] = Math.Round( Qw * 1.9 / 10 * i , 2);
                //TabQw[i] = Math.Round(Qw * 1.5 / 10 * i, 2);
                //TabQw[i] = Math.Round(Qmax / 10 * i, 2);
                TabQw[i] = Math.Round(Qw * 1.3 / 10 * i, 2);
                TabQwStr[i] = Convert.ToString(TabQw[i]);
                
                TabHw[i] = Math.Round( Hg + R * Math.Pow(TabQw[i], 2) , 2);
                TabHwStr[i] = Convert.ToString(TabHw[i]);

                char_Hu_Str = char_Hu_Str + ",{ x: " + Convert.ToString(TabQw[i]) + ", y:" + Convert.ToString(TabHw[i]) + "}";
            }
            char_Hu_Str = char_Hu_Str + "]";

            pw_Str = "[{ x:" + Convert.ToString(Qw)+",y:" + Convert.ToString(Hw) + "}]";
                       
        }

    }
}
