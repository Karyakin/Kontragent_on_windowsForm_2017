using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp3
{
    public partial class Autorization : Form

    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        // private SqlConnection SqlConnection = null;
        
        public Autorization()
        {
            InitializeComponent();
            label28.Visible = false;
            label1.Visible = false;
        }

        private void Button2_Выход_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Регистрация_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private async void Button3_Вход_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand check_log_pass = new SqlCommand("check_log_pass", sqlConnection);
                SqlCommand check_login = new SqlCommand("check_login", sqlConnection);
                check_login.Parameters.AddWithValue("Login_User", textBox_Login.Text);
                check_log_pass.Parameters.AddWithValue("Login_User", textBox_Login.Text);
                check_log_pass.Parameters.AddWithValue("Password_User", textBox2.Text);

                check_log_pass.CommandType = CommandType.StoredProcedure;
                check_login.CommandType = CommandType.StoredProcedure;


                if (!string.IsNullOrEmpty(textBox_Login.Text) && !string.IsNullOrWhiteSpace(textBox_Login.Text))
                {
                    label3.Visible = true;
                    label28.Visible = false;

                    if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        label1.Visible = false;


                        if (Convert.ToInt32(await check_login.ExecuteScalarAsync()) == 1)
                        {
                            if (Convert.ToInt32(await check_log_pass.ExecuteScalarAsync()) == 1)
                            {
                                MessageBox.Show($"Господин {textBox_Login.Text}, добро пожаловать в ИС Контрагент!");
                                ORG.Login_User = textBox_Login.Text;


                                using (SqlConnection sqlConnection1 = new SqlConnection(connectionString))
                                {
                                    sqlConnection1.Open();
                                    SqlCommand Giv_Depatment_For_Lable = new SqlCommand($"SELECT Users.Department FROM Users Where Login_User = '{textBox_Login.Text}' ", sqlConnection1);
                                    ORG.Department = Giv_Depatment_For_Lable.ExecuteScalar().ToString();
                                    sqlConnection1.Close();
                                }
                                Main_Form general_Form = new Main_Form();

                                this.Hide();
                                general_Form.ShowDialog();
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show($"У господина {textBox_Login.Text}а другой пароль!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с такой фамилией не зарегистрирован", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        label1.Visible = true;
                        return;
                    }
                }
                else
                {
                    label3.Visible = false;
                    label28.Visible = true;
                    return;
                }
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
            textBox2.PasswordChar = '*';
            
        }
    }
}



