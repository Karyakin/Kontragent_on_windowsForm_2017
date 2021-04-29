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
   public class Risc_Level
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
       

       public static int Get_Country_Risk(string Country)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
            
                SqlCommand Risk_Country_ORG = new SqlCommand("Risk_Country_ORG", sqlConnection);  //выборка степени риска для страны для помещения его в ProgressBar
                Risk_Country_ORG.CommandType = CommandType.StoredProcedure;
                Risk_Country_ORG.Parameters.AddWithValue("Name_Country", Country);
                int Country_Risk_OUT = Convert.ToInt32(Risk_Country_ORG.ExecuteScalar());
               
                sqlConnection.Close();
                return Country_Risk_OUT;
            }
        }


        public static int Get_Section_Risk(string Section)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand Risk_Section_ORG = new SqlCommand("Risk_Section_ORG", sqlConnection);  //выборка степени риска для секции для помещения его в ProgressBar
                Risk_Section_ORG.CommandType = CommandType.StoredProcedure;
                Risk_Section_ORG.Parameters.AddWithValue("Name_Section", Section);
                int Risk_Section_OUT = Convert.ToInt32(Risk_Section_ORG.ExecuteScalar());

                sqlConnection.Close();
                return Risk_Section_OUT;
            }
        }


        public static  void All_Check_Risk()
        {
            ORG org = new ORG();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                               
                SqlCommand All_Check_Risk = new SqlCommand("All_Check_Risk", sqlConnection);
                All_Check_Risk.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = All_Check_Risk.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ORG.Ownership_Org = Convert.ToInt32(sqlDataReader["Ownership_Org"]);
                    ORG.Tax_Debt = Convert.ToInt32(sqlDataReader["Tax_Debt"]);
                    ORG.Debts_Enforcement_Documents = Convert.ToInt32(sqlDataReader["Debts_Enforcement_Documents"]);
                    ORG.False_Business = Convert.ToInt32(sqlDataReader["False_Business"]);
                    ORG.Special_Risc = Convert.ToInt32(sqlDataReader["Special_Risc"]);
                    ORG.Execute_Proc = Convert.ToInt32(sqlDataReader["Execute_Proc"]);
                    ORG.Bankruptcy_Proc = Convert.ToInt32(sqlDataReader["Bankruptcy_Proc"]);
                    ORG.Liquidation_Proc = Convert.ToInt32(sqlDataReader["Liquidation_Proc"]);
                    ORG.Resident = Convert.ToInt32(sqlDataReader["Resident"]);
                    ORG.Broker_Client = Convert.ToInt32(sqlDataReader["Broker_Client"]);
                    ORG.Trading_experience = Convert.ToInt32(sqlDataReader["Trading_experience"]);
                    ORG.Manufacturer = Convert.ToInt32(sqlDataReader["Manufacturer"]);
                    ORG.Exchenge_Trading_Disorders = Convert.ToInt32(sqlDataReader["Exchenge_Trading_Disorders"]);
                    ORG.Negativ_Data = Convert.ToInt32(sqlDataReader["Negativ_Data"]);
                    ORG.Reputation = Convert.ToInt32(sqlDataReader["Reputation"]);
                    ORG.Prev_Liquidated = Convert.ToInt32(sqlDataReader["Prev_Liquidated"]);
                    ORG.Prev_Bankruptcy = Convert.ToInt32(sqlDataReader["Prev_Bankruptcy"]);
                    ORG.Prev_State_Debt = Convert.ToInt32(sqlDataReader["Prev_State_Debt"]);
                    ORG.Prev_Tax_Debt = Convert.ToInt32(sqlDataReader["Prev_Tax_Debt"]);
                    ORG.Prev_Execute_Proc = Convert.ToInt32(sqlDataReader["Prev_Execute_Proc"]);
                }
                               
                sqlConnection.Close();
            }
           
        }
    }
}
