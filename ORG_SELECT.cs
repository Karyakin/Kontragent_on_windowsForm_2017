using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
     public class ORG_SELECT
     {
        public static string UNP_Org;
        public static string Short_Name_Org;
        public static string Full_Name_Org;
       // public static DateTime Create_date_Org; //= Convert.ToDateTime("12.12.2012");
        public static  DateTime Create_date_Org_START;
        public static  DateTime Create_date_Org_FINAL;
        public static string Countyr_Org;
        public static string Name_Section;

        public static DateTime Check_date_START;
        public static DateTime Create_date_FINAL;


        public static DateTime dateTimePicker_Check_date_START;
        public static DateTime dateTimePicker_Create_date_FINAL;




        //For ProgressBar
        public static string Risk_Country_ORG;
        public static string Risk_Country_Pers;
        public static string Risk_Section_ORG;
        public static int Sbor_Sdelka = 10;


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
        public static int Prev_Liquidated;
        public static int Prev_Bankruptcy;
        public static int Prev_State_Debt;
        public static int Prev_Tax_Debt;
        public static int Prev_Execute_Proc;

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

        public static string Login_User = "Карякин";
        public static string Department = "УИБ";
        public static DateTime Check_Date = DateTime.Now;


        public static string Risc_Level_Less;
        public static string Risc_Level_More;


    }
}
