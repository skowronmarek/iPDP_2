using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iPDP.Models
{
    public class Ustawienia
    {
        public const string sciezkaDoVebio = "Server=mssql.webio.pl,2401;Database=skowron1_ipdp_dev;User Id=skowron1_ipdp_dev;Password=6N.tmdP#S!`QS`F.|,Uh";
        // PolaczDoVebio = new SqlConnection("Server=mssql.webio.pl,2401;Database=skowron1_ipdp_dev;User Id=skowron1_ipdp_dev;Password=6N.tmdP#S!`QS`F.|,Uh");

        public const string baza = "[skowron1_ipdp_dev].[TBS]";

        // L F P
        public const string tabele_LFP = "[skowron1_ipdp_dev].[skowron1_ipdp_dev].[A_LFP],[skowron1_ipdp_dev].[TBS].[LFP_Import_H]";
        public const string tabela_LFP_A = "[skowron1_ipdp_dev].[skowron1_ipdp_dev].[A_LFP]";
        public const string tabela_LFP_H = "[skowron1_ipdp_dev].[TBS].[LFP_Import_H]";

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

        //public const string tabela_MEP_A = baza + ".[MEPRO_A_01]";
        //public const string tabela_MEP_H = baza + ".[MEPRO_H_01]";
        //public const string tabela_MEP_G = baza + ".[MEPRO_G_01]";
        //public const string tabela_MEP_M = baza + ".[MEPRO_M_01]";
        //public const string tabela_MEP_T = baza + ".[MEPRO_T_01]";

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
