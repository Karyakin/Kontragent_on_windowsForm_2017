using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class SQL_ADD_Parametrs
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public /*static*/ void ADD_ORG_Parametrs(ORG parametrs)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command_ADD_Organization_Pers = new SqlCommand("ADD_Organization_Pers", sqlConnection); //Проца на заполнение таблицы Организации и Собственников
                command_ADD_Organization_Pers.CommandType = CommandType.StoredProcedure;

                command_ADD_Organization_Pers.Parameters.AddWithValue("UNP_Org", ORG.UNP_Org);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Short_Name_Org", ORG.Short_Name_Org);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Full_Name_Org", ORG.Full_Name_Org);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Create_date_Org", ORG.Create_date_Org);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Country", ORG.Countyr_Org);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Name_Section", ORG.Name_Section);

                //Параметры для чекбоксов организации
                command_ADD_Organization_Pers.Parameters.AddWithValue("Ownership_Org", ORG.Ownership_Org);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Tax_Debt", ORG.Tax_Debt);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Debts_Enforcement_Documents", ORG.Debts_Enforcement_Documents);
                command_ADD_Organization_Pers.Parameters.AddWithValue("False_Business", ORG.False_Business);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Special_Risc", ORG.Special_Risc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Execute_Proc", ORG.Execute_Proc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Bankruptcy_Proc", ORG.Bankruptcy_Proc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Liquidation_Proc", ORG.Liquidation_Proc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Resident", ORG.Resident);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Broker_Client", ORG.Broker_Client);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Broker_Client", ORG.Prev_Broker_Client);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Trading_experience", ORG.Trading_experience);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Trader", ORG.Trader);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Manufacturer", ORG.Manufacturer);
                command_ADD_Organization_Pers.Parameters.AddWithValue("First_Accred", ORG.First_Accred);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Second_Accred", ORG.Second_Accred);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Exchenge_Trading_Disorders", ORG.Exchenge_Trading_Disorders);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Negativ_Data", ORG.Negativ_Data);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Negativ_Data_Pers", ORG.Negativ_Data_Pers);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Reputation", ORG.Reputation);

                //Описание организации и мнения
                command_ADD_Organization_Pers.Parameters.AddWithValue("Description_Org", ORG.Description_ORG);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Broker_Opinion", ORG.Broker_Opinion);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Section_Head_Opinion", ORG.Section_Head_Opinion);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Auditor_Opinion", ORG.Auditor_Opinion);

                //Описание руководителей и их залетов
                command_ADD_Organization_Pers.Parameters.AddWithValue("Country_Pers", ORG.Country_Pers);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Owner_Name", ORG.Owner_Name);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Head_Name", ORG.Head_Name);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Liquidated", ORG.Prev_Liquidated);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Bankruptcy", ORG.Prev_Bankruptcy);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_State_Debt", ORG.Prev_State_Debt);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Tax_Debt", ORG.Prev_Tax_Debt);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Prev_Execute_Proc", ORG.Prev_Execute_Proc);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Description_Pers", ORG.Description_Pers);
                command_ADD_Organization_Pers.Parameters.AddWithValue("Login_User", ORG.Login_User);

                command_ADD_Organization_Pers.Parameters.AddWithValue("Forced_Deposite", ORG.Forced_Deposite);

                command_ADD_Organization_Pers.ExecuteNonQuery();

            }
        }

        public void Find_For_Update_ORG(ORG parametrs)
        {
            ORG oRG = new ORG();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("Select_For_Apdate", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("UNP_Org", ORG.UNP_Org);
                command.Parameters.AddWithValue("Short_Name_Org", ORG.Short_Name_Org);
                command.Parameters.AddWithValue("Full_Name_Org", ORG.Full_Name_Org);
                command.ExecuteNonQuery();

                SqlDataReader reader_For_Update = null;
                reader_For_Update = command.ExecuteReader();

                while (reader_For_Update.Read())
                {
                    ORG.UNP_Org = Convert.ToString(reader_For_Update["UNP_Org"]);
                    ORG.Short_Name_Org = Convert.ToString(reader_For_Update["Short_Name_Org"]);
                    ORG.Full_Name_Org = Convert.ToString(reader_For_Update["Full_Name_Org"]);
                    ORG.Create_date_Org = Convert.ToDateTime(reader_For_Update["Create_date_Org"]);
                    ORG.Countyr_Org = Convert.ToString(reader_For_Update["Name_Country"]);
                    ORG.Name_Section = Convert.ToString(reader_For_Update["Name_Section"]);

                    ORG.Ownership_Org = Convert.ToInt32(reader_For_Update["Ownership_Org"]);
                    ORG.Tax_Debt = Convert.ToInt32(reader_For_Update["Tax_Debt"]);

                    ORG.Debts_Enforcement_Documents = Convert.ToInt32(reader_For_Update["Debts_Enforcement_Documents"]);
                    ORG.False_Business = Convert.ToInt32(reader_For_Update["False_Business"]);
                    ORG.Special_Risc = Convert.ToInt32(reader_For_Update["Special_Risc"]);
                    ORG.Execute_Proc = Convert.ToInt32(reader_For_Update["Execute_Proc"]);
                    ORG.Bankruptcy_Proc = Convert.ToInt32(reader_For_Update["Bankruptcy_Proc"]);
                    ORG.Liquidation_Proc = Convert.ToInt32(reader_For_Update["Liquidation_Proc"]);
                    ORG.Resident = Convert.ToInt32(reader_For_Update["Resident"]);
                    ORG.Broker_Client = Convert.ToInt32(reader_For_Update["Broker_Client"]);
                    ORG.Prev_Broker_Client = Convert.ToInt32(reader_For_Update["Prev_Broker_Client"]);
                    ORG.Trading_experience = Convert.ToInt32(reader_For_Update["Trading_experience"]);
                    ORG.Trader = Convert.ToInt32(reader_For_Update["Trader"]);

                    ORG.Manufacturer = Convert.ToInt32(reader_For_Update["Manufacturer"]);
                    ORG.First_Accred = Convert.ToInt32(reader_For_Update["First_Accred"]);
                    ORG.Second_Accred = Convert.ToInt32(reader_For_Update["Second_Accred"]);
                    ORG.Exchenge_Trading_Disorders = Convert.ToInt32(reader_For_Update["Exchenge_Trading_Disorders"]);
                    ORG.Negativ_Data = Convert.ToInt32(reader_For_Update["Negativ_Data"]);
                    ORG.Negativ_Data_Pers = Convert.ToInt32(reader_For_Update["Negativ_Data_Pers"]);
                    ORG.Reputation = Convert.ToInt32(reader_For_Update["Reputation"]);

                    ORG.Prev_Liquidated = Convert.ToInt32(reader_For_Update["Prev_Liquidated"]);
                    ORG.Prev_Bankruptcy = Convert.ToInt32(reader_For_Update["Prev_Bankruptcy"]);
                    ORG.Prev_State_Debt = Convert.ToInt32(reader_For_Update["Prev_State_Debt"]);
                    ORG.Prev_Tax_Debt = Convert.ToInt32(reader_For_Update["Prev_Tax_Debt"]);
                    ORG.Prev_Execute_Proc = Convert.ToInt32(reader_For_Update["Prev_Execute_Proc"]);
                    ORG.Description_ORG = Convert.ToString(reader_For_Update["Description_Org"]);

                    ORG.Broker_Opinion = Convert.ToString(reader_For_Update["Broker_Opinion"]);
                    ORG.Section_Head_Opinion = Convert.ToString(reader_For_Update["Section_Head_Opinion"]);
                    ORG.Auditor_Opinion = Convert.ToString(reader_For_Update["Auditor_Opinion"]);

                    ORG.Country_Pers = Convert.ToString(reader_For_Update["Country_Pers"]);
                    ORG.Owner_Name = Convert.ToString(reader_For_Update["Owner_Name"]);
                    ORG.Head_Name = Convert.ToString(reader_For_Update["Head_Name"]);
                    ORG.Description_Pers = Convert.ToString(reader_For_Update["Description_Pers"]);



                    if (Convert.ToString(reader_For_Update["Рекомендуемый вид задатка"]) == Convert.ToString(reader_For_Update["Вид задатка"]))
                    {
                        ORG.Forced_Deposite_Small = 0;
                        ORG.Forced_Deposite_Large = 0;
                    }

                    if (Convert.ToString(reader_For_Update["Рекомендуемый вид задатка"]) != Convert.ToString(reader_For_Update["Вид задатка"]))
                    {
                        if (oRG.Sbor_Sdelka <= (Convert.ToInt32(reader_For_Update["Степень риска"])))
                        {
                            ORG.Forced_Deposite_Small = 1;
                        }

                        if (oRG.Sbor_Sdelka >= (Convert.ToInt32(reader_For_Update["Степень риска"])))
                        {
                            ORG.Forced_Deposite_Large = 1;
                        }
                       
                    }






                    ORG.Risc_Level = Convert.ToInt32(reader_For_Update["Степень риска"]);

                }
            }
        }

        public void Update_ORG(ORG parametrs)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand update = new SqlCommand("Update_Cascade", sqlConnection);
                update.CommandType = CommandType.StoredProcedure;


                if (ORG.UNP_Org_New == null)
                {
                    update.Parameters.AddWithValue("UNP_Org", ORG.UNP_Org);
                }
                else
                {
                    update.Parameters.AddWithValue("UNP_Org", ORG.UNP_Org);
                    update.Parameters.AddWithValue("UNP_Org_New", ORG.UNP_Org_New);
                }


                if (ORG.Short_Name_Org_New == null)
                {
                    update.Parameters.AddWithValue("Short_Name_Org", ORG.Short_Name_Org);
                }
                else 
                {
                    update.Parameters.AddWithValue("Short_Name_Org_New", ORG.Short_Name_Org_New);
                }

                if (ORG.Full_Name_Org_New == null)
                {
                    update.Parameters.AddWithValue("Full_Name_Org", ORG.Full_Name_Org);
                }
                else
                {
                    update.Parameters.AddWithValue("Full_Name_Org_New", ORG.Full_Name_Org_New);
                }
              






                update.Parameters.AddWithValue("Create_date_Org", ORG.Create_date_Org);
                update.Parameters.AddWithValue("Country", ORG.Countyr_Org);
                update.Parameters.AddWithValue("Name_Section", ORG.Name_Section);

                //Параметры для чекбоксов организации
                update.Parameters.AddWithValue("Ownership_Org", ORG.Ownership_Org);
                update.Parameters.AddWithValue("Tax_Debt", ORG.Tax_Debt);
                update.Parameters.AddWithValue("Debts_Enforcement_Documents", ORG.Debts_Enforcement_Documents);
                update.Parameters.AddWithValue("False_Business", ORG.False_Business);
                update.Parameters.AddWithValue("Special_Risc", ORG.Special_Risc);
                update.Parameters.AddWithValue("Execute_Proc", ORG.Execute_Proc);
                update.Parameters.AddWithValue("Bankruptcy_Proc", ORG.Bankruptcy_Proc);
                update.Parameters.AddWithValue("Liquidation_Proc", ORG.Liquidation_Proc);
                update.Parameters.AddWithValue("Resident", ORG.Resident);
                update.Parameters.AddWithValue("Broker_Client", ORG.Broker_Client);
                update.Parameters.AddWithValue("Prev_Broker_Client", ORG.Prev_Broker_Client);
                update.Parameters.AddWithValue("Trading_experience", ORG.Trading_experience);
                update.Parameters.AddWithValue("Trader", ORG.Trader);
                update.Parameters.AddWithValue("Manufacturer", ORG.Manufacturer);
                update.Parameters.AddWithValue("First_Accred", ORG.First_Accred);
                update.Parameters.AddWithValue("Second_Accred", ORG.Second_Accred);
                update.Parameters.AddWithValue("Exchenge_Trading_Disorders", ORG.Exchenge_Trading_Disorders);
                update.Parameters.AddWithValue("Negativ_Data", ORG.Negativ_Data);
                update.Parameters.AddWithValue("Negativ_Data_Pers", ORG.Negativ_Data_Pers);
                update.Parameters.AddWithValue("Reputation", ORG.Reputation);

                //Описание организации и мнения
                update.Parameters.AddWithValue("Description_Org", ORG.Description_ORG);
                update.Parameters.AddWithValue("Broker_Opinion", ORG.Broker_Opinion);
                update.Parameters.AddWithValue("Section_Head_Opinion", ORG.Section_Head_Opinion);
                update.Parameters.AddWithValue("Auditor_Opinion", ORG.Auditor_Opinion);

                //Описание руководителей и их залетов
                update.Parameters.AddWithValue("Country_Pers", ORG.Country_Pers);
                update.Parameters.AddWithValue("Owner_Name", ORG.Owner_Name);
                update.Parameters.AddWithValue("Head_Name", ORG.Head_Name);
                update.Parameters.AddWithValue("Prev_Liquidated", ORG.Prev_Liquidated);
                update.Parameters.AddWithValue("Prev_Bankruptcy", ORG.Prev_Bankruptcy);
                update.Parameters.AddWithValue("Prev_State_Debt", ORG.Prev_State_Debt);
                update.Parameters.AddWithValue("Prev_Tax_Debt", ORG.Prev_Tax_Debt);
                update.Parameters.AddWithValue("Prev_Execute_Proc", ORG.Prev_Execute_Proc);
                update.Parameters.AddWithValue("Description_Pers", ORG.Description_Pers);
                update.Parameters.AddWithValue("Login_User", ORG.Login_User);






                if (ORG.Forced_Deposite_Small == 1 && ORG.Forced_Deposite_Large == 0)
                {
                    update.Parameters.AddWithValue("Forced_Deposite", ORG.Forced_Deposite_Small);
                }
               

                if (ORG.Forced_Deposite_Large == 1 && ORG.Forced_Deposite_Small == 0)
                {
                    update.Parameters.AddWithValue("Forced_Deposite", ORG.Forced_Deposite_Large);
                }





                if (ORG.Forced_Deposite_Large == 0 && ORG.Forced_Deposite_Small == 0)
                {
                    update.Parameters.AddWithValue("Forced_Deposite", 0);
                }


                if (ORG.Forced_Deposite_Large == 1 && ORG.Forced_Deposite_Small == 1)
                {
                    update.Parameters.AddWithValue("Forced_Deposite", 0);
                }



                //  update.Parameters.AddWithValue("Forced_Deposite", ORG.Forced_Deposite);





                update.ExecuteNonQuery();
            }
        }
    }
}
