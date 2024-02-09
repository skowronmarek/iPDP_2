using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace iPDP.Models
{
    public class Ustawienia
    {
        public string DoVebio = "XX";
        public const string sciezkaDoVebio = "Server=mssql.webio.pl,2401;Database=skowron1_ipdp_dev;User Id=skowron1_ipdp_dev;Password=6N.tmdP#S!`QS`F.|,Uh";
        // PolaczDoVebio = new SqlConnection("Server=mssql.webio.pl,2401;Database=skowron1_ipdp_dev;User Id=skowron1_ipdp_dev;Password=6N.tmdP#S!`QS`F.|,Uh");

        public const string baza = "[skowron1_ipdp_dev].[TBS]";

        // L F P

        //public const string tabela_LFP_A = "[skowron1_ipdp_dev].[skowron1_ipdp_dev].[A_LFP]";
        public const string tabela_LFP_A = baza + ".[LFP.Import.A]";
        public const string tabela_LFP_H = baza + ".[LFP_Import_H]";
        public const string tabela_LFP_G = baza + ".[LFP.Import.G]";
        public const string tabela_LFP_M = baza + ".[LFP.Import.M]";
        public const string tabela_LFP_T = baza + ".[LFP.Import.T]";

        public const string relacja_LFP_H = tabela_LFP_A + ".[H_ID] = " + tabela_LFP_H + ".[H_ID]";
        public const string relacja_LFP_G = tabela_LFP_A + ".[G_ID] = " + tabela_LFP_G + ".[G_ID]";
        public const string relacja_LFP_M = tabela_LFP_A + ".[M_ID] = " + tabela_LFP_M + ".[M_ID]";
        public const string relacja_LFP_T = tabela_LFP_A + ".[TYP_ID] = " + tabela_LFP_T + ".[TYP_ID]";

        public const string tabele_LFP = tabela_LFP_A + "," + tabela_LFP_H + "," + tabela_LFP_G + "," + tabela_LFP_M + "," + tabela_LFP_T;
        public const string relacje_LFP = relacja_LFP_H + " AND " + relacja_LFP_G + " AND " + relacja_LFP_M + " AND " + relacja_LFP_T;

        // KFP
        public const string tabela_KFP_A = baza + ".[KFP_A]";
        public const string tabela_KFP_H = baza + ".[KFP_H]";
        public const string tabela_KFP_G = baza + ".[KFP_G]";
        public const string tabela_KFP_M = baza + ".[KFP_M]";
        public const string tabela_KFP_T = baza + ".[KFP_T]";

        public const string relacja_KFP_H = tabela_KFP_A + ".[H_ID] = " + tabela_KFP_H + ".[H_ID]";
        public const string relacja_KFP_G = tabela_KFP_A + ".[G_ID] = " + tabela_KFP_G + ".[G_ID]";
        public const string relacja_KFP_M = tabela_KFP_A + ".[M_ID] = " + tabela_KFP_M + ".[M_ID]";
        public const string relacja_KFP_T = tabela_KFP_A + ".[TYP_ID] = " + tabela_KFP_T + ".[TYP_ID]";

        public const string tabele_KFP = tabela_KFP_A + "," + tabela_KFP_H + "," + tabela_KFP_G + "," + tabela_KFP_M + "," + tabela_KFP_T;
        public const string relacje_KFP = relacja_KFP_H + " AND " + relacja_KFP_G + " AND " + relacja_KFP_M + " AND " + relacja_KFP_T;

        // MET
        public const string tabela_MET_A = baza + ".[MET_A]";
        public const string tabela_MET_H = baza + ".[MET_H]";
        public const string tabela_MET_G = baza + ".[MET_G]";
        public const string tabela_MET_M = baza + ".[MET_M]";
        public const string tabela_MET_T = baza + ".[MET_T]";

        public const string relacja_MET_H = tabela_MET_A + ".[H_ID] = " + tabela_MET_H + ".[H_ID]";
        public const string relacja_MET_G = tabela_MET_A + ".[G_ID] = " + tabela_MET_G + ".[G_ID]";
        public const string relacja_MET_M = tabela_MET_A + ".[M_ID] = " + tabela_MET_M + ".[M_ID]";
        public const string relacja_MET_T = tabela_MET_A + ".[TYP_ID] = " + tabela_MET_T + ".[TYP_ID]";

        public const string tabele_MET = tabela_MET_A + "," + tabela_MET_H + "," + tabela_MET_G + "," + tabela_MET_M + "," + tabela_MET_T;
        public const string relacje_MET = relacja_MET_H + " AND " + relacja_MET_G + " AND " + relacja_MET_M + " AND " + relacja_MET_T;


        // D A M B A T
        public const string tabela_DAM_A = baza + ".[DAM_A]";
        public const string tabela_DAM_H = baza + ".[DAM_H]";
        public const string tabela_DAM_G = baza + ".[DAM_G]";
        public const string tabela_DAM_M = baza + ".[DAM_M]";
        public const string tabela_DAM_T = baza + ".[DAM_T]";

        public const string relacja_DAM_H = tabela_DAM_A + ".[H_ID] = " + tabela_DAM_H + ".[H_ID]";
        public const string relacja_DAM_G = tabela_DAM_A + ".[G_ID] = " + tabela_DAM_G + ".[G_ID]";
        public const string relacja_DAM_M = tabela_DAM_A + ".[M_ID] = " + tabela_DAM_M + ".[M_ID]";
        public const string relacja_DAM_T = tabela_DAM_A + ".[TYP_ID] = " + tabela_DAM_T + ".[TYP_ID]";

        public const string tabele_DAM = tabela_DAM_A + "," + tabela_DAM_H + "," + tabela_DAM_G + "," + tabela_DAM_M + "," + tabela_DAM_T;
        public const string relacje_DAM = relacja_DAM_H + " AND " + relacja_DAM_G + " AND " + relacja_DAM_M + " AND " + relacja_DAM_T;

        //M E P R O Z E T
        //public const color RGB A = 42 106 182 255

        public const string TabeleFabryki = "[skowron1_ipdp_dev].[skowron1_ipdp_dev].[FABRYKI]";
        public const string TabeleTypyLFP = "[skowron1_ipdp_dev].[skowron1_ipdp_dev].[A_LFP]";
                
        public const string tabela_MEP_A = baza + ".[MEPRO_A_02]";
        public const string tabela_MEP_H = baza + ".[MEPRO_H_02]";
        public const string tabela_MEP_G = baza + ".[MEPRO_G_02]";
        public const string tabela_MEP_M = baza + ".[MEPRO_M_02]";
        public const string tabela_MEP_T = baza + ".[MEPRO_T_02]";

        public const string relacja_MEP_H = tabela_MEP_A + ".[H_ID] = " + tabela_MEP_H + ".[H_ID]";
        public const string relacja_MEP_G = tabela_MEP_A + ".[G_ID] = " + tabela_MEP_G + ".[G_ID]";
        public const string relacja_MEP_M = tabela_MEP_A + ".[M_ID] = " + tabela_MEP_M + ".[M_ID]";
        public const string relacja_MEP_T = tabela_MEP_A + ".[TYP_ID] = " + tabela_MEP_T + ".[TYP_ID]";

        public const string tabele_MEP = tabela_MEP_A + "," + tabela_MEP_H + "," + tabela_MEP_G + "," + tabela_MEP_M + "," + tabela_MEP_T;
        public const string relacje_MEP = relacja_MEP_H + " AND " + relacja_MEP_G + " AND " + relacja_MEP_M + " AND " + relacja_MEP_T;

    }
}
