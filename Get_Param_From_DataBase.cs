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
    public static class Get_Param_From_DataBase
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static string UNP_Org_Update_Delete;
        public static string Full_Name_Org_Update_Delete;
        public static string Short_Name_Org_Update_Delete;

        public static void void_Get_Param_From_DataBase()
        {

            


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand Select_For_Apdate = new SqlCommand("Select_For_Apdate", sqlConnection);
                Select_For_Apdate.CommandType = CommandType.StoredProcedure;



                





                SqlDataReader reader_Select_For_Apdate = null;
                reader_Select_For_Apdate = Select_For_Apdate.ExecuteReader();

                while (reader_Select_For_Apdate.Read())
                {
                    string UNP_Org1 = Convert.ToString(reader_Select_For_Apdate[UNP_Org_Update_Delete]);
                    string Full_Name_Org = Convert.ToString(reader_Select_For_Apdate[Full_Name_Org_Update_Delete]);
                    string Short_Name_Org = Convert.ToString(reader_Select_For_Apdate[Short_Name_Org_Update_Delete]);



                }



               
                 

















                sqlConnection.Close();
            }
        }
    }
}
