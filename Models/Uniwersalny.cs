using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace iPDP.Models
{
    public class Uniwersalny : TStdZadSzukPomp
    {
        //Dane do wyszukiwania
        public int NrPompy { get; set; } = 1;
        public double Interfejs_Qw { get; set; } = 10.0;
        public double Interfejs_Hw { get; set; } = 10.0;
        public double Interfejs_Hg { get; set; } = 9.0;
        public double Interfejs_d { get; set; } = 54;
        public double Interfejs_L { get; set; } = 29;
        public double Interfejs_Dh { get; set; } = 1.01;
        public double Interfejs_Ph { get; set; } = 0.27;
        /// <summary>
        /// ?????
        /// </summary>
        public string Interfejs_QwUnit { get; set; } = "'m3h'";

        // Dane do tablicy synoptycznej 
        public double U_odleglosc { get; set; } = 25;
        public double U_lustro { get; set; } = 2.00;
        public double U_wysokosc { get; set; } = 8.00;

        // Zdublowane parametry modelu do komunikacji ze strona
        public double Qw_model { get; set; } = 10.0;
        public double Hw_model { get; set; } = 10.0;
        public double Hg_model { get; set; } = 9.0;

        public Uniwersalny() // constructor
        {
                       
            //Dobor();
            Kl_Zastosowania = "ogol";
            Kl_Zasilania = "'3x400'";
        }

    }
}