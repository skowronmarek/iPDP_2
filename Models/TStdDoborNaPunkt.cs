using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;


namespace iPDP.Models
{
    //---------------------------------------------//
    //   GLOWNA PROCEDURA SZUKANIA POMP W BAZIE    //
    //---------------------------------------------//
    public class TStdDoborNaPunkt
    {
        public string QminQn; // granice dla Qn
        public string QmaxQn;
        public string HminHn; // granice dla Hn
        public string HmaxHn;

        // PARAMETRY WYSZUKIWANIA W BAZIE - ustawiane z zewnatrz
        public Boolean Filtruj = false;
        public string Kafelek = "Tree";
        public string Producent;
        public string Kl_Zastosown;
        public string Kl_Zasilania = "'3~400V 50Hz'";
        public string Ds_min_STR = "'160'";
        public double Ds = 160;
        public TStdCharSel CharUkladu = new TStdCharSel();


        // PARAMETRY ZAPYTANIA DO BAZY
        public string Pola;
        public string Tabele;
        public string Relacje;
        public string Filtry;
        public string Filtr_Aktywna;
        public string Filtr_Zastosowanie;
        public string Filtr_Konstrukcja;
        public string Filtr_Zasilanie;
        public string Filtr_Srednica;
        public string Filtr_Tolerancja_Qn;

        public string ID1;
        public string ID2;
        public string ID3;
        public string Sciezka;
        public int L_ID = 0;  // liczba ID do wyszukiwania


        public string Filtr_ID1;
        public string Filtr_ID2;
        public string Filtr_ID3;

        public SqlConnection PolaczDoVebio;
        public string commandText;
        public SqlDataReader reader;

        // WYNIKI WYSZUKIWANIA
        public int N_PT_Index;
        public TListaPomp listaPompZBazy = new TListaPomp();   //przechowuje listę TPomp
        public int Row;
        public int LiczbaZnalPomp;

        double Eta(double Q, double H, double P, double rho)  // Oblicza sprawnosc
        {
            if (P > 0)
            {
                return Q * H * rho * 9.81 / P;
            }
            else
            {
                return 0;
            }

        }
        double Eta_UI(double Q, double H, double P)  // Oblicza sprawnosc (User Interface - m3/h, kW )
        {
            if (P > 0)
            {
                return Q / 3600 * H * 1000 * 9.81 / (P * 1000);
            }
            else
            {
                return 0;
            }

        }

        public void Ustaw_ID()
        {

            L_ID = 0;
            foreach (char a in Sciezka)  // dorobic zabezpieczenie
            {
                if (a == '/') L_ID++;
            }

            if (Sciezka.Length > 0)
            {
                if (L_ID == 0)
                {
                    ID1 = "'" + Sciezka + "'";
                    ID2 = "";
                    ID3 = "";
                }
                else
                {
                    if (L_ID == 1)
                    {
                        int position = Sciezka.IndexOf("/");
                        ID1 = "'" + Sciezka.Substring(0, position) + "'";
                        Sciezka = Sciezka.Substring(position + 1, Sciezka.Length - position - 1);
                        ID2 = "'" + Sciezka + "'";
                    }
                    else
                    {
                        int position = Sciezka.IndexOf("/");
                        ID1 = "'" + Sciezka.Substring(0, position) + "'";
                        Sciezka = Sciezka.Substring(position + 1, Sciezka.Length - position - 1);
                        position = Sciezka.IndexOf("/");
                        ID2 = "'" + Sciezka.Substring(0, position) + "'";
                        ID3 = "'" + Sciezka.Substring(position + 1, Sciezka.Length - position - 1) + "'";
                    }

                }
            }
            else
            {
                ID1 = "'BrakIndeksu'"; // ma nic nie znalezc
                ID2 = "";
                ID3 = "";
            }


            string str = "hello";
            char input = 'l';
            int counter = 0;
            //method 1
            foreach (char a in str)
            {
                if (a == input) counter++;
            }
            //counter = 2

            //method 2 - linq
            var result = str.Count(x => x == input);
            //result = 2

        }

        public void CzytajRec(TPompa tmpPompa)
        {
            // Parametry pompy
            //tmpPompa.ProductNo = Convert.ToString(reader["ProductNo"]);
            tmpPompa.Nazwa = Convert.ToString(reader["Nazwa"]);
            tmpPompa.Qn = Convert.ToDouble(reader["Qn"]);
            tmpPompa.Hn = Convert.ToDouble(reader["Hn"]);
            tmpPompa.Pn = Convert.ToDouble(reader["Pn"]);
            tmpPompa.nn = Convert.ToDouble(reader["nn"]);
            tmpPompa.Qmin = Convert.ToDouble(reader["Qmin"]);
            tmpPompa.Qmax = Convert.ToDouble(reader["Qmax"]);

            // Parametry silnika
            tmpPompa.M_Zas = Convert.ToString(reader["M_TYP"]);
            tmpPompa.M_Pzn = Convert.ToDouble(reader["M_Pzn"]);
            tmpPompa.M_Uzn = Convert.ToDouble(reader["NAP"]);
            tmpPompa.M_Izn = Convert.ToDouble(reader["PRAD"]);
            tmpPompa.M_COSFzn = Convert.ToDouble(reader["COSF"]);

            //tmpPompa.M_LFaz = Convert.ToInt32(reader["FAZY"]);
            //tmpPompa.M_FREK = Convert.ToInt32(reader["FREK"]);
            // Parametry geometryczne
            tmpPompa.G_PDF = "/PDF/" + Convert.ToString(reader["G_PDF"]);
            tmpPompa.G_Masa = Convert.ToDouble(reader["MASA"]);

            // Parametry TYPU
            tmpPompa.Opis_PDF = "/OPIS/" + Convert.ToString(reader["OPIS_PDF"]);
            tmpPompa.KL_ZAST = Convert.ToString(reader["KL_ZAST"]);
            tmpPompa.GRUPA = Convert.ToString(reader["GRUPA"]);

            // Parametry charakterystyki
            tmpPompa.CharPompy.n_pt = Convert.ToInt32(reader["N_PT"]);
            tmpPompa.CharPompy.H_Qmin = Convert.ToInt32(reader["H_Qmin"]);
            tmpPompa.CharPompy.H_Qmax = Convert.ToInt32(reader["H_Qmax"]);
        }
        public void RobListeZnalezionychPomp()
        {
            double efi;
            int i = 0;
            listaPompZBazy.fLista.Clear();

            //while (reader.Read() & (i < 10) )
            while (reader.Read())                                            //Czytaj wszystkie znalezione rekordy
            {
                TPompa tmpPompa = new TPompa();                              // tworzy pompe
                CzytajRec(tmpPompa);

                N_PT_Index = reader.GetOrdinal("N_PT");                      // Zalozenie! - punkty char maja kolejne indeksy 

                tmpPompa.Nazwa = tmpPompa.Nazwa;
                tmpPompa.char_H_Str = "[";
                tmpPompa.char_P_Str = "[";
                tmpPompa.char_E_Str = "[";

                for (int j = 1; j < tmpPompa.CharPompy.n_pt + 1; j++)                                                                           //for (int j = 1; j < tmpPompa.CharPompy.n_pt; j++)
                {                                                                                                                              // W Pascalu tablice sa od 1
                    // to jest dla decimal
                    tmpPompa.CharPompy.TabQ[j] = Convert.ToDouble(reader.GetDecimal(N_PT_Index + j));                                       //(N_PT_Index + 1 + j));
                    tmpPompa.CharPompy.TabH[j] = Convert.ToDouble(reader.GetDecimal(N_PT_Index + tmpPompa.CharPompy.n_pt + j));             //(N_PT_Index + 1 + tmpPompa.CharPompy.n_pt + j));
                    tmpPompa.CharPompy.TabP[j] = Convert.ToDouble(reader.GetDecimal(N_PT_Index + tmpPompa.CharPompy.n_pt * 2 + j));         //(N_PT_Index + 1 + tmpPompa.CharPompy.n_pt * 2 + j));

                    //tmpPompa.CharPompy.TabQ[j] = Convert.ToDouble(reader.GetFloat(N_PT_Index + j));                                       //(N_PT_Index + 1 + j));
                    //tmpPompa.CharPompy.TabH[j] = Convert.ToDouble(reader.GetFloat(N_PT_Index + tmpPompa.CharPompy.n_pt + j));             //(N_PT_Index + 1 + tmpPompa.CharPompy.n_pt + j));
                    //tmpPompa.CharPompy.TabP[j] = Convert.ToDouble(reader.GetFloat(N_PT_Index + tmpPompa.CharPompy.n_pt * 2 + j));         //(N_PT_Index + 1 + tmpPompa.CharPompy.n_pt * 2 + j));

                    efi = Eta_UI(tmpPompa.CharPompy.TabQ[j], tmpPompa.CharPompy.TabH[j], tmpPompa.CharPompy.TabP[j]) * 100;                      // dodane 100%    
                    if (j > 1)
                    {
                        tmpPompa.char_H_Str = tmpPompa.char_H_Str + ",";
                        tmpPompa.char_P_Str = tmpPompa.char_P_Str + ",";
                        tmpPompa.char_E_Str = tmpPompa.char_E_Str + ",";
                    };
                    tmpPompa.char_H_Str = tmpPompa.char_H_Str + "{ x: " + Convert.ToString(tmpPompa.CharPompy.TabQ[j]) + ", y:" + Convert.ToString(tmpPompa.CharPompy.TabH[j]) + "}";
                    tmpPompa.char_P_Str = tmpPompa.char_P_Str + "{ x: " + Convert.ToString(tmpPompa.CharPompy.TabQ[j]) + ", y:" + Convert.ToString(tmpPompa.CharPompy.TabP[j]) + "}";
                    tmpPompa.char_E_Str = tmpPompa.char_E_Str + "{ x: " + Convert.ToString(tmpPompa.CharPompy.TabQ[j]) + ", y:" + Convert.ToString(efi) + "}";
                }
                tmpPompa.char_H_Str = tmpPompa.char_H_Str + "]";
                tmpPompa.char_P_Str = tmpPompa.char_P_Str + "]";
                tmpPompa.char_E_Str = tmpPompa.char_E_Str + "]";

                // Tu dodc obliczanie wspolczynnikow

                listaPompZBazy.AddPompa(tmpPompa);

                i++;  //get rows
            }

            LiczbaZnalPomp = i;
        }
        public void DoborNaPunkt()
        {
            // customCulture zapisuje ustawienia systemu
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            QminQn = Convert.ToString(CharUkladu.Qw * CharUkladu.QminTol);
            QmaxQn = Convert.ToString(CharUkladu.Qw * CharUkladu.QmaxTol);
            HminHn = Convert.ToString(CharUkladu.Hw * CharUkladu.HminTol);
            HmaxHn = Convert.ToString(CharUkladu.Hw * CharUkladu.HmaxTol);
            Ds_min_STR = Convert.ToString(Ds);

            PolaczDoVebio = new SqlConnection(Ustawienia.sciezkaDoVebio);
            PolaczDoVebio.Open();

            Producent = "MEPRO";

            switch (Producent)
            {
                case "LFP":
                    //Statement
                    break;
                case "MEPRO":
                    {
                        Tabele = Ustawienia.tabele_MEP;
                        Relacje = Ustawienia.relacje_MEP;
                        //Pola = Ustawienia.pola_DAM; czytamy wszystko

                        Filtr_Tolerancja_Qn = $"{Ustawienia.tabela_MEP_A} .[Qn] > {QminQn} AND {Ustawienia.tabela_MEP_A} .[Qn] < {QmaxQn} AND {Ustawienia.tabela_MEP_A} .[Hn] > {HminHn} AND {Ustawienia.tabela_MEP_A} .[Hn] < {HmaxHn} ";
                        Filtr_Srednica = $"{Ustawienia.tabela_MEP_G} .[PARN1] < { Ds_min_STR} ";

                        if (Kl_Zastosown == "ogol")
                        {
                            Filtr_Zastosowanie = "1=1";
                        }
                        else
                        {
                            Kl_Zastosown = "'%/" + Kl_Zastosown + "/%'";
                            Filtr_Zastosowanie = $"{Ustawienia.tabela_MEP_T} .[KL_ZAST] LIKE {Kl_Zastosown} ";
                            //Filtr_Zastosowanie = $"{Ustawienia.tabela_MEP_T} .[KL_ZAST] LIKE '%przem%' ";
                        }
                        //Kl_Zastosown = "'%/pscie/%'";
                        //Kl_Zasilania = "'1~230'";
                        Filtr_Zasilanie = $"{Ustawienia.tabela_MEP_M} .[M_TYP] = {Kl_Zasilania} ";

                        Filtr_ID1 = $"{Ustawienia.tabela_MEP_A} .[ID1] = {ID1}";
                        Filtr_ID2 = $"{Ustawienia.tabela_MEP_A} .[ID2] = {ID2}";
                        Filtr_ID3 = $"{Ustawienia.tabela_MEP_A} .[ID3] = {ID3}";

                        if (Filtruj)
                        {
                            switch (L_ID)
                            {
                                case 0:
                                    Filtry = $"{Filtr_ID1}";
                                    break;
                                case 1:
                                    Filtry = $"{Filtr_ID1} AND {Filtr_ID2}";
                                    break;
                                case 2:
                                    Filtry = $"{Filtr_ID1} AND {Filtr_ID2} AND {Filtr_ID3}";
                                    break;
                            }
                        }
                        else
                        {
                            Filtry = $"{Filtr_Tolerancja_Qn} AND {Filtr_Zastosowanie} ";
                        }
                    };
                    break;
                case "DAM":
                    //Statement
                    break;
                default:
                    //Statement
                    break;
            }

            commandText = $"SELECT * FROM {Tabele} WHERE {Relacje} AND {Filtry}";
            //commandText = $"SELECT * FROM {Tabele} WHERE {Relacje}";
            //commandText = $"SELECT * FROM {Tabele}";

            SqlCommand sqlCommand = new SqlCommand(commandText, PolaczDoVebio);         // Zapytanie do bazy
            reader = sqlCommand.ExecuteReader();

            RobListeZnalezionychPomp();                                                 //Czyta wszystkie znalezione rekordy, robi liste pomp
        }

        public TStdDoborNaPunkt()                                 //Construktor
        {

        }
    }
}
