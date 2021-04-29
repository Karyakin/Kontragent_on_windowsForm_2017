using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp3
{
    public partial class Registration : Form
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public Registration()
        {
            InitializeComponent();
        }


        private async void Button1_Добавить_польз_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                Registration registration = new Registration();


                SqlCommand command_INSERT = new SqlCommand("ADD_User", sqlConnection);
                command_INSERT.CommandType = CommandType.StoredProcedure;

                SqlCommand check_login = new SqlCommand("check_login", sqlConnection);
                check_login.CommandType = CommandType.StoredProcedure;
                check_login.Parameters.AddWithValue("Login_User", textBox1.Text);
                await sqlConnection.OpenAsync();


                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    if (Convert.ToInt32(await check_login.ExecuteScalarAsync()) != 1)
                    {
                        command_INSERT.Parameters.AddWithValue("@Login_User", textBox1.Text);

                        if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            command_INSERT.Parameters.AddWithValue("@Department", textBox2.Text);
                            label7.Visible = false;

                            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
                            {
                                if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
                                {
                                    if (textBox3.Text == textBox4.Text)
                                    {
                                        command_INSERT.Parameters.AddWithValue("@Password_User", textBox4.Text);
                                        label8.Visible = false;
                                        label9.Visible = false;

                                        command_INSERT.Parameters.AddWithValue("@Hint", textBox5.Text);
                                        command_INSERT.ExecuteNonQuery();
                                        MessageBox.Show("Пользователь успешно зарегистрирован!", "Приятной работы", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Пароли не совпадают!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //this.Close();
                                        //registration.Show();
                                    }
                                }
                                else
                                {

                                    MessageBox.Show("Пароли не совпадают!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //this.Close();
                                    //registration.Show();
                                }
                            }
                            else
                            {
                                label8.Visible = true;
                                MessageBox.Show("Придумайте пароль!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //this.Close();
                               // registration.Show();
                            }
                        }
                        else
                        {
                            label7.Visible = true;
                            label7.Text = "Укажите подразделение!";
                            //this.Close();
                            //registration.Show();
                        }                  
                    }
                    else
                    {
                        label6.Visible = true;
                        MessageBox.Show("Пользователь с такой фамилией уже зарегистрирован", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        //this.Hide();
                        //registration.Show();
                    }
                }
                else
                {   label10.Visible = true;
                    MessageBox.Show("Заполните фамилию", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     //               this.Close();
                   // registration.Show();
                }
                  
            }
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            if (label6.Visible && label7.Visible && label8.Visible && label9.Visible)
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;


        }

        
    }
}
