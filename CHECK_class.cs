using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp3
{
    class CHECK_class
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public bool Check_UNP(string UNP)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand Check_UNP = new SqlCommand("Check_UNP ", sqlConnection);
                Check_UNP.CommandType = CommandType.StoredProcedure;
                Check_UNP.Parameters.AddWithValue("UNP_Org", UNP);

                if (Convert.ToInt32(Check_UNP.ExecuteScalar()) == 1)
                {
                    sqlConnection.Close();
                    return false;
                }
                else
                {
                    sqlConnection.Close();
                    return true;
                }
            }
        }
        public bool Check_Short_Name_Org(string Short_Name_Org)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand Check_Short_Name_Org = new SqlCommand("Check_Short_Name_Org ", sqlConnection);// Проца на проверку дубликат краткого наименов
                Check_Short_Name_Org.CommandType = CommandType.StoredProcedure;
                Check_Short_Name_Org.Parameters.AddWithValue("Short_Name_Org", Short_Name_Org);

                if (Convert.ToInt32(Check_Short_Name_Org.ExecuteScalar()) == 1)
                {
                    sqlConnection.Close();
                    return false;
                }
                else
                {
                    sqlConnection.Close();
                    return true;
                }
            }
        }

        public bool Check_Full_Name_Org(string Full_Name_Org)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand Check_Full_Name_Org = new SqlCommand("Check_Full_Name_Org", sqlConnection); // Проца на проверку дубликат полного наименов
                Check_Full_Name_Org.CommandType = CommandType.StoredProcedure;
                Check_Full_Name_Org.Parameters.AddWithValue("Full_Name_Org", Full_Name_Org);

                if (Convert.ToInt32(Check_Full_Name_Org.ExecuteScalar()) == 1)
                {
                    sqlConnection.Close();
                    return false;
                }
                else
                {
                    sqlConnection.Close();
                    return true;
                }
            }
        }

        public bool Check_Create_date_Org(string Create_date_Org)
        {

            DateTime date;
            string value = Create_date_Org;
            if (DateTime.TryParseExact(value, "dd/MM/yyyy", null, DateTimeStyles.None, out date))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Check_Country(string Country)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                if (Country == "(не выбрано)" )
                {
                    sqlConnection.Close();
                    return false;
                }
                else
                {
                    sqlConnection.Close();
                    return true;
                }
            }
        }

        public bool Check_Section(string Section)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                if (Section == "(не выбрано)")
                {
                    sqlConnection.Close();
                    return false;
                }
                else
                {
                    sqlConnection.Close();
                    return true;
                }
            }
        }

        public bool Check_Country_Pers(string Country)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                if (Country == "(не выбрано)")
                {
                    sqlConnection.Close();
                    return false;
                }
                else
                {
                    sqlConnection.Close();
                    return true;
                }
            }
        }





    }
}
