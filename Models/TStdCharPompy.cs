using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Web;

namespace iPDP.Models
{
    /************************************************************/
    /* Standardowa charakterystyka pompy na punktach i splainie */
    /* - obliczanie wsp. splajnow                               */
    /* - funkcje czytajace wartosci z charakterystyk            */
    /************************************************************/
    public class TStdCharPompy
    {
        // Tylko SZ Na stale 20 punktow
        public int n_pt;
        // punkty
        public double[] TabQ = new double[20];           // wydajnosci z bazy
        public double[] TabH = new double[20];           // wysokoci z bazy
        public double[] TabP = new double[20];           // moce z bazy
        public double[] TabNPSH = new double[20];        // NPSH z bazy

        // Wsplczynniki
        public double[] H0 = new double[20];
        public double[] H1 = new double[20];
        public double[] H2 = new double[20];
        public double[] H3 = new double[20];

        public double[] P0 = new double[20];
        public double[] P1 = new double[20];
        public double[] P2 = new double[20];
        public double[] P3 = new double[20];

        public double[] NPSH0 = new double[20];
        public double[] NPSH1 = new double[20];
        public double[] NPSH2 = new double[20];
        public double[] NPSH3 = new double[20];

        public double H_Qmin;
        public double H_Qmax;

        public double P(double AQ)                         // funkcja zwraca MOC dla zadanej wydajnosci
        {
            if (n_pt == 0)
            {
                return 0;
            }
            else
            {
                return SplineValue(n_pt, AQ, TabQ, P0, P1, P2, P3);
            }
        }
        public double Eta(double AQ, double AH, double AP)  // sprawnosc do wyswietlania
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            return AQ / 3600 * AH * 1000 * 10 / (AP * 1000) * 100;
        }
        public double H(Double Q)                         // zwraca H - pompy
        {
            if (n_pt == 0)
            {
                return 0;
            }
            else
            {
                return SplineValue(n_pt, Q, TabQ, H0, H1, H2, H3);
            }
        }


        public double SplineValue(int N, Double X, double[] AX, double[] A0, double[] A1, double[] A2, double[] A3)
        {
            int i;
            int min;
            int max;

            min = 1;
            max = N;
            while (min < (max - 1))
            {
                i = min + (max - min) / 2;  //delphi i := min + ((max-min) div 2);
                if (AX[i] > X)
                {
                    max = i;
                }
                else
                {
                    min = i;
                }
            }
            i = min;
            return ((A3[i] * X + A2[i]) * X + A1[i]) * X + A0[i];
        }

        public TStdCharPompy()          //Constructor
        {
            n_pt = 20;                  // Zestaw do testow, ograniczenie do 20 punktow

            TabQ = new double[n_pt];
            TabH = new double[n_pt];
            TabP = new double[n_pt];
            H_Qmax = 0;
            H_Qmin = 0;

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


            TabQ[0] = -1;                // Zestaw do testow
            TabQ[1] = 20;
            TabQ[2] = 40;
            TabQ[3] = 60;
            TabQ[4] = 80;
            //TabQ[5] = 100;
            //TabQ[6] = 120;

            TabH[0] = -1;
            TabH[1] = 49;
            TabH[2] = 47;
            TabH[3] = 44;
            TabH[4] = 40;
            //TabH[5] = 35;
            //TabH[6] = 29;

            TabP[0] = -1;
            TabP[1] = 25;
            TabP[2] = 29;
            TabP[3] = 32;
            TabP[4] = 34;
            //TabP[5] = 35;
            //TabP[6] = 34;            
        }

        public void ObliczWsp()
        {
            // Tymczasowe tablice do przekazywania pochodnych
            double[] d1 = new double[20];     // pochodne 1-go stopnia
            double[] d2 = new double[20];     // pochodne 2-go stopnia

            Spline(n_pt, TabQ, TabH, d1, d2);
            PolySpline(n_pt, TabQ, TabH, d1, d2, H0, H1, H2, H3);

            Spline(n_pt, TabQ, TabP, d1, d2);
            PolySpline(n_pt, TabQ, TabP, d1, d2, P0, P1, P2, P3);

            Spline(n_pt, TabQ, TabNPSH, d1, d2);
            PolySpline(n_pt, TabQ, TabNPSH, d1, d2, NPSH0, NPSH1, NPSH2, NPSH3);
        }

        public void Spline(int N, double[] Xtab, double[] Ytab, double[] D1y, double[] D2y)  // zwraca pochodne w punktach
        {
            double[] del_x = new double[20];
            double[] x = new double[20];
            double[] a = new double[20];
            double[] b = new double[20];
            double[] c = new double[20];
            double[] f = new double[20];
            double[] g = new double[20];
            double[] w = new double[20];
            double[] sb = new double[20];

            for (int i = 2; i < N + 1; i++)                            //Delphi for (int i = 2; i < N; i++)
            {
                del_x[i] = Xtab[i] - Xtab[i - 1];
            }

            for (int i = 2; i < N; i++)                         //Delphi for (int i = 2; i < N - 1; i++)
            {
                a[i] = del_x[i] / 6;
                b[i] = (del_x[i] + del_x[i + 1]) / 3;
                c[i] = del_x[i + 1] / 6;
                f[i] = (Ytab[i + 1] - Ytab[i]) / del_x[i + 1] - (Ytab[i] - Ytab[i - 1]) / del_x[i];
            }

            a[N] = -0.5;
            b[1] = 1;
            b[N] = 1;
            c[1] = -0.5;
            c[N] = 0;
            f[1] = 0;
            f[N] = 0;
            w[1] = b[1];
            sb[1] = c[1] / w[1];
            g[1] = 0;

            for (int i = 2; i < N + 1; i++)
            {
                w[i] = b[i] - a[i] * sb[i - 1];
                sb[i] = c[i] / w[i];
                g[i] = (f[i] - a[i] * g[i - 1]) / w[i];
            }

            D2y[N] = g[N];
            for (int k = N - 1; k > 0; k--)                        //for (int k = N - 1; k > 1; k--)
            {
                D2y[k] = g[k] - sb[k] * D2y[k + 1];     // 2ga pochadna 
            }

            D1y[1] = -del_x[2] / 6 * (2 * D2y[1] + D2y[2]) + (Ytab[2] - Ytab[1]) / del_x[2];
            for (int i = 2; i < N + 1; i++)
            {
                D1y[i] = del_x[i] / 6 * (2 * D2y[i] + D2y[i - 1]) + (Ytab[i] - Ytab[i - 1]) / del_x[i];  // 1sza pochadna
            }
        }

        public void PolySpline(int N, double[] Xw, double[] Yw, double[] D1yw, double[] D2yw, double[] A0w, double[] A1w, double[] A2w, double[] A3w)  // zwraca wspolczynniki krzywych 3-go stopnia
        {
            double dx;
            double dx2;
            double dx3;
            double xip;
            double xi1p;

            for (int i = 1; i < N; i++)                   //for (int i = 1; i < N - 1; i++)
            {
                xip = Xw[i];
                xi1p = Xw[i + 1];
                dx = xip - xi1p;

                xip = xip * Xw[i];
                xi1p = xi1p * Xw[i + 1];
                dx2 = xip - xi1p;                // dx2 = (Xw[i]) ^ 2 - (Xw[i + 1]) ^ 2 

                xip = xip * Xw[i];
                xi1p = xi1p * Xw[i + 1];
                dx3 = xip - xi1p;                // dx3 = (Xw[i]) ^ 3 - (Xw[i + 1]) ^ 3 

                A3w[i] = (D2yw[i] - D2yw[i + 1]) / (dx * 6);
                A2w[i] = (D1yw[i] - D1yw[i + 1] - 3 * A3w[i] * dx2) / (2 * dx);
                A1w[i] = (Yw[i] - Yw[i + 1] - A2w[i] * dx2 - A3w[i] * dx3) / dx;
                A0w[i] = Yw[i] - A1w[i] * Xw[i] - A2w[i] * Math.Pow(Xw[i], 2) - A3w[i] * Math.Pow(Xw[i], 2) * Xw[i];
            }


        }
    }

}






