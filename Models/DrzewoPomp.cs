using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;

namespace iPDP.Models
{
    public class DrzewoPomp
    {
        public class Identyfilator
        {
            public string ID1 { get; set; }
            public string ID2 { get; set; }
            public string ID3 { get; set; }
        }

        public SqlConnection PolaczDoVebio;

        public string Pola;
        public string commandText;
        public SqlDataReader reader;

        public List<Identyfilator> ListaID = new List<Identyfilator>();
        public List<TreeViewNode> fLista = new List<TreeViewNode>();

        public IEnumerable<TreeViewNode> Lista
        {
            get
            {
                return fLista;
            }
        }

        public void Add(TreeViewNode wezel)
        {
            fLista.Add(wezel);
        }

        public DrzewoPomp()  //Konstruktor
        {
            Czytaj_A();

        }

        public void Czytaj_A()
        {
            PolaczDoVebio = new SqlConnection(Ustawienia.sciezkaDoVebio);
            PolaczDoVebio.Open();

            Pola = "NAZWA,ID1,ID2,ID3";
            //commandText = $"SELECT {Pola} FROM {Ustawienia.TabeleTypyLFP}";
            commandText = $"SELECT {Pola} FROM {Ustawienia.tabela_MEP_A}";

            SqlCommand sqlCommand = new SqlCommand(commandText, PolaczDoVebio);
            reader = sqlCommand.ExecuteReader();

            CzytajID();             // Robi liste unikatowych ID1+ID2+ID3
            CzytajNody();
        }

        public void CzytajNody()  // dodawanie wezlow
        {
            foreach (Identyfilator IDs in ListaID)
            {
                bool jestID1 = false;
                if (IDs.ID1 != "")
                {
                    TreeViewNode tmpNode = new TreeViewNode();
                    tmpNode.text = IDs.ID1;
                    tmpNode.parent = "";
                    jestID1 = false;
                    foreach (TreeViewNode node in fLista)
                    {
                        if ((tmpNode.text == node.text) && (tmpNode.parent == ""))
                        {
                            jestID1 = true;
                        }
                    }
                    if (!jestID1)
                    {
                        fLista.Add(tmpNode);
                    }
                }
            }

            foreach (TreeViewNode node in fLista) // lista wezlow
            {
                foreach (Identyfilator IDs in ListaID) // lista ident
                {
                    if ((node.text == IDs.ID1) && (IDs.ID2 != ""))
                    {
                        bool jestID2 = false;
                        foreach (TreeViewNode node_1 in node.ChildList)
                            if (node_1.text == IDs.ID2)
                            {
                                jestID2 = true;
                            }
                        if (!jestID2)
                        {
                            TreeViewNode tmpNode2 = new TreeViewNode();
                            tmpNode2.text = IDs.ID2;
                            node.ChildList.Add(tmpNode2);
                        }
                    }
                }
            }

            foreach (TreeViewNode node in fLista) // lista wezlow   III POZIOM
            {
                foreach (TreeViewNode node_1 in node.ChildList)
                {
                    foreach (Identyfilator IDs in ListaID) // lista ident
                    {
                        if ((node.text == IDs.ID1) && (node_1.text == IDs.ID2) && (IDs.ID3 != ""))
                        {
                            bool jestID3 = false;
                            foreach (TreeViewNode node_2 in node_1.ChildList)
                                if (node_2.text == IDs.ID3)
                                {
                                    jestID3 = true;
                                }
                            if (!jestID3)
                            {
                                TreeViewNode tmpNode3 = new TreeViewNode();
                                tmpNode3.text = IDs.ID3;
                                node_1.ChildList.Add(tmpNode3);
                            }
                        }
                    }
                }
            }

        }


        public void CzytajID()  // dodawanie wezlow
        {
            ListaID.Clear();
            while (reader.Read())
            {
                bool jestTyp = false;
                Identyfilator tmpID = new Identyfilator();
                tmpID.ID1 = Convert.ToString(reader["ID1"]);
                if (tmpID.ID1 != "")
                {
                    tmpID.ID2 = Convert.ToString(reader["ID2"]);
                    if (tmpID.ID2 == "")
                    {
                        tmpID.ID3 = "";
                    }
                    else
                    {
                        tmpID.ID3 = Convert.ToString(reader["ID3"]);
                    }


                    foreach (Identyfilator IDrow in ListaID)
                    {
                        if ((IDrow.ID1 == tmpID.ID1) && (IDrow.ID2 == tmpID.ID2) && (IDrow.ID3 == tmpID.ID3))
                        {
                            jestTyp = true;
                        }
                    }
                    if (!jestTyp)
                    {
                        ListaID.Add(tmpID);
                    }
                }
            }
        }

        public string DajDrzewo() // Robi drzewoStr na podstawie Listy wezlow
        {
            string drzewoStr = "[";  // Element ZEROWY
            Boolean pierwszy_1 = true;
            foreach (TreeViewNode node_1 in fLista)
            {
                if (pierwszy_1)
                {
                    drzewoStr = drzewoStr + "{'text':'" + node_1.text + "'"; // pierwszy element nie pusty
                    pierwszy_1 = false;
                }
                else
                {
                    drzewoStr = drzewoStr + ",{'text':'" + node_1.text + "'";
                }

                if (node_1.ChildList.Count > 0)
                {
                    drzewoStr = drzewoStr + ",'children':[";
                    Boolean pierwszy_2 = true;
                    foreach (TreeViewNode node_2 in node_1.ChildList)
                    {
                        if (pierwszy_2)
                        {
                            drzewoStr = drzewoStr + "{'text':'" + node_2.text + "'"; // pierwszy element nie pusty
                            pierwszy_2 = false;

                        }
                        else
                        {
                            drzewoStr = drzewoStr + ",{'text':'" + node_2.text + "'"; // pierwszy element nie pusty
                        }

                        if (node_2.ChildList.Count > 0)
                        {
                            drzewoStr = drzewoStr + ",'children':[";
                            Boolean pierwszy_3 = true;
                            foreach (TreeViewNode node_3 in node_2.ChildList)
                            {
                                if (pierwszy_3)
                                {
                                    drzewoStr = drzewoStr + "{'text':'" + node_3.text + "'}"; // pierwszy element nie pusty
                                    pierwszy_3 = false;
                                }
                                else
                                {
                                    drzewoStr = drzewoStr + ",{'text':'" + node_3.text + "'}"; // pierwszy element nie pusty
                                }
                            }
                            drzewoStr = drzewoStr + "]}";
                        }
                        else
                        {
                            drzewoStr = drzewoStr + "}";
                        }

                    }
                    //drzewoStr = drzewoStr + "";
                    drzewoStr = drzewoStr + "]}";
                }
                else
                {
                    drzewoStr = drzewoStr + "}";
                }
            }

            drzewoStr = drzewoStr + "]";



            return drzewoStr;
        }
    }
}
