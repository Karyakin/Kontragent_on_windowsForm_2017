using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class ORG
    {
        public static string UNP_Org;
        public static string Short_Name_Org;
        public static string Full_Name_Org;
        public static DateTime Create_date_Org;
        public static string Countyr_Org;
        public static string Name_Section;

        public static string UNP_Org_New;
        public static string Full_Name_Org_New;
        public static string Short_Name_Org_New;

        //For ProgressBar
        public string Risk_Country_ORG;
        public string Risk_Country_Pers;
        public string Risk_Section_ORG;
        public  int Sbor_Sdelka = 10;


        // Risk level for bit checkBox
        public static int Ownership_Org;
        public static int Tax_Debt;
        public static int Debts_Enforcement_Documents;
        public static int False_Business;
        public static int Special_Risc;
        public static int Execute_Proc;
        public static int Bankruptcy_Proc;
        public static int Liquidation_Proc;
        public static int Resident;
        public static int Broker_Client;
        public static int Prev_Broker_Client;
        public static int Trading_experience;
        public static int Trader;
        public static int Manufacturer;
        public static int First_Accred;
        public static int Second_Accred;
        public static int Exchenge_Trading_Disorders;
        public static int Negativ_Data;
        public static int Negativ_Data_Pers;
        public static int Reputation;
        // не вошли те что дальше

        public static int Prev_Liquidated;
        public static int Prev_Bankruptcy;
        public static int Prev_State_Debt;
        public static int Prev_Tax_Debt;
        public static int Prev_Execute_Proc;

        public static int Forced_Deposite;
        public static int Forced_Deposite_Small;
        public static int Forced_Deposite_Large;

        public static int Risc_Level;


        //Discription and Opinion
        public static string Description_ORG;
        public static string Broker_Opinion;
        public static string Section_Head_Opinion;
        public static string Auditor_Opinion;

        // Per_Info
        public static string Country_Pers;
        public static string Owner_Name;
        public static string Head_Name;
        public static string Description_Pers;

        public static string Login_User;
        public static string Department;
        public static DateTime Check_Date = DateTime.Now;
        public static DateTime Update_Data;


        // переменные для выборки из ORACLE_DB
        public static string ORA_FULL_NAME_PERS;
        public static string ORA_FULL_NAME_ORG;
        public static string ORA_NCOUNTRY_ID;
        public static string ORA_PASSPORT_NUMBER;
        public static string ORA_FULL_NAME_COUNTRY;
        public static string ORA_OWNERSHIP_FORM_ID;
        public static string ORA_SHORT_NAME;
        public static DateTime ORA_REG_DATE;
        public static string ORA_FIO_CHIEF;
        public static int ORA_RESIDENT;
        public static string ORA_NREGO_ID;
        

    }
}
