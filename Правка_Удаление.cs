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
    public partial class Apdate_Delete : Form
    {
        ORG oRG = new ORG();
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public Apdate_Delete()
        {
            InitializeComponent();
            label2.Text = ORG.Login_User;
            label_Department.Text = ORG.Department;

            if (ORG.Login_User == "Карякин" || ORG.Login_User == "Admin")
            {
                button_Update.Enabled = true;
                button_Delete.Enabled = true;
            }
            else
            {
                button_Update.Enabled = false;
                button_Delete.Enabled = false;
            }

            #region тушим lables ошибок при загрузке формы
            Risc_Level.Visible = false;
            label_err_UNP.Visible = false;
            label_err_Short_Name.Visible = false;
            label_err_Full_Name.Visible = false;
            label_Incorrect_Date.Visible = false;
            label_Country_Org_Err.Visible = false;
            label_err_Section.Visible = false;
            label_err_Country_Pers.Visible = false;
            label_err_Owneer_Name.Visible = false;
            label_err_Head_Name.Visible = false;
            label_Not_Two_Depos_Small.Visible = false;
            label_Not_Two_Depos_Largw.Visible = false;
            #endregion
        }

        public Apdate_Delete(string UNP)
        {
            InitializeComponent();
            label2.Text = ORG.Login_User;
            label_Department.Text = ORG.Department;
            textBox_UNP_Update_Delete.Text = ORG.UNP_Org;
            if (ORG.Login_User == "Карякин" || ORG.Login_User == "Admin")
            {
                button_Update.Enabled = true;
                button_Delete.Enabled = true;
            }
            else
            {
                button_Update.Enabled = false;
                button_Delete.Enabled = false;
            }

            #region тушим lables ошибок при загрузке формы
            Risc_Level.Visible = false;
            label_err_UNP.Visible = false;
            label_err_Short_Name.Visible = false;
            label_err_Full_Name.Visible = false;
            label_Incorrect_Date.Visible = false;
            label_Country_Org_Err.Visible = false;
            label_err_Section.Visible = false;
            label_err_Country_Pers.Visible = false;
            label_err_Owneer_Name.Visible = false;
            label_err_Head_Name.Visible = false;
            label_Not_Two_Depos_Small.Visible = false;
            label_Not_Two_Depos_Largw.Visible = false;
            #endregion

            Load += Apdate_Delete_Shown;
        }

        private void Apdate_Delete_Shown(Object sender, EventArgs e)
        {
            button1.PerformClick();
        }


        private void Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox_UNP_Update_Delete.Text) && string.IsNullOrWhiteSpace(textBox_UNP_Update_Delete.Text)) { ORG.UNP_Org = null; }
            else { ORG.UNP_Org = textBox_UNP_Update_Delete.Text; }

            if (string.IsNullOrEmpty(textBox_Short_Name_Org_Update_Delete.Text)) { ORG.Short_Name_Org = null; }
            else { ORG.Short_Name_Org = textBox_Short_Name_Org_Update_Delete.Text; }

            if (string.IsNullOrEmpty(textBox_Full_Name_Org_Update_Delete.Text)) { ORG.Full_Name_Org = null; }
            else { ORG.Full_Name_Org = textBox_Full_Name_Org_Update_Delete.Text; }

            SQL_ADD_Parametrs sQL_Parametrs_Apdate = new SQL_ADD_Parametrs();
            sQL_Parametrs_Apdate.Find_For_Update_ORG(oRG);

            textBox_UNP_Update_Delete.Text = ORG.UNP_Org;
            textBox_Short_Name_Org_Update_Delete.Text = ORG.Short_Name_Org;
            textBox_Full_Name_Org_Update_Delete.Text = ORG.Full_Name_Org;

            maskedTextBox_Create_date_Org.Text = Convert.ToString(ORG.Create_date_Org);
            comboBox_Countyr_Org.Text = ORG.Countyr_Org;
            comboBox_Section.Text = ORG.Name_Section;

            Description_ORG.Text = ORG.Description_ORG;
            comboBox_Countyr_Pers.Text = ORG.Country_Pers;
            Name_Owner.Text = ORG.Owner_Name;

            if (ORG.Ownership_Org == 1) { checkBox_Ownership_Org.Checked = true; } else { checkBox_Ownership_Org.Checked = false; }
            if (ORG.Tax_Debt == 1) { Tax_Debt.Checked = true; } else { Tax_Debt.Checked = false; }
            if (ORG.Debts_Enforcement_Documents == 1) { Debts_Enforcement_Documents.Checked = false; } else { Debts_Enforcement_Documents.Checked = false; }
            if (ORG.Debts_Enforcement_Documents == 1) { Debts_Enforcement_Documents.Checked = true; } else { Debts_Enforcement_Documents.Checked = false; }
            if (ORG.False_Business == 1) { False_Business.Checked = true; } else { False_Business.Checked = false; }
            if (ORG.Special_Risc == 1) { Special_Risc.Checked = true; } else { Special_Risc.Checked = false; }
            if (ORG.Special_Risc == 1) { Special_Risc.Checked = true; } else { Special_Risc.Checked = false; }
            if (ORG.Execute_Proc == 1) { Execute_Proc.Checked = true; } else { Execute_Proc.Checked = false; }
            if (ORG.Bankruptcy_Proc == 1) { Bankruptcy_Proc.Checked = true; } else { Bankruptcy_Proc.Checked = false; }
            if (ORG.Liquidation_Proc == 1) { Liquidation_Proc.Checked = true; } else { Liquidation_Proc.Checked = false; }
            if (ORG.Resident == 1) { Resident.Checked = true; } else { Resident.Checked = false; }
            if (ORG.Broker_Client == 1) { Broker_Client.Checked = true; } else { Broker_Client.Checked = false; }
            if (ORG.Prev_Broker_Client == 1) { Prev_Broker_Client.Checked = true; } else { Prev_Broker_Client.Checked = false; }
            if (ORG.Trading_experience == 1) { Trading_experience.Checked = true; } else { Trading_experience.Checked = false; }
            if (ORG.Trader == 1) { Trader.Checked = true; } else { Trader.Checked = false; }
            if (ORG.Manufacturer == 1) { Manufacturer.Checked = true; } else { Manufacturer.Checked = false; }
            if (ORG.First_Accred == 1) { First_Accred.Checked = true; } else { First_Accred.Checked = false; }
            if (ORG.Second_Accred == 1) { Second_Accred.Checked = true; } else { Second_Accred.Checked = false; }
            if (ORG.Exchenge_Trading_Disorders == 1) { Exchenge_Trading_Disorders.Checked = true; } else { Exchenge_Trading_Disorders.Checked = false; }
            if (ORG.Negativ_Data == 1) { Negativ_Data.Checked = true; } else { Negativ_Data.Checked = false; }
            if (ORG.Negativ_Data_Pers == 1) { Negativ_Data_Pers.Checked = true; } else { Negativ_Data_Pers.Checked = false; }
            if (ORG.Reputation == 1) { Reputation.Checked = true; } else { Reputation.Checked = false; }
            if (ORG.Prev_Liquidated == 1) { Prev_Liquidated.Checked = true; } else { Prev_Liquidated.Checked = false; }
            if (ORG.Prev_Bankruptcy == 1) { Prev_Bankruptcy.Checked = true; } else { Prev_Bankruptcy.Checked = false; }
            if (ORG.Prev_State_Debt == 1) { Prev_State_Debt.Checked = true; } else { Prev_State_Debt.Checked = false; }
            if (ORG.Prev_Tax_Debt == 1) { Prev_Tax_Debt.Checked = true; } else { Prev_Tax_Debt.Checked = false; }
            if (ORG.Prev_Execute_Proc == 1) { Prev_Execute_Proc.Checked = true; } else { Prev_Execute_Proc.Checked = false; }
            if (ORG.Broker_Opinion == "нет") { textBox_BrokerOpinion.Clear(); } else { textBox_BrokerOpinion.Text = ORG.Broker_Opinion; }
            if (ORG.Section_Head_Opinion == "нет") { textBox_Section_Head_Opinion.Clear(); } else { textBox_Section_Head_Opinion.Text = ORG.Section_Head_Opinion; }
            if (ORG.Auditor_Opinion == "нет") { textBox_Auditor_Opinion.Clear(); } else { textBox_Auditor_Opinion.Text = ORG.Auditor_Opinion; }
            if (ORG.Head_Name == "нет") { TextBox_Name_Head.Clear(); } else { TextBox_Name_Head.Text = ORG.Head_Name; }
            if (ORG.Description_Pers == "нет") { Description_Pers.Clear(); } else { Description_Pers.Text = ORG.Description_Pers; }
            if (ORG.Forced_Deposite_Small == 1){checkBox_Forced_Deposite_Small.Checked = true;} else{checkBox_Forced_Deposite_Small.Checked = false;}
            if (ORG.Forced_Deposite_Large == 1){checkBox_Forced_Deposite_Large.Checked = true;} else{checkBox_Forced_Deposite_Large.Checked = false;}

            Risc_Level.Text = Convert.ToString(ORG.Risc_Level);
            Risc_Level.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox_UNP_Update_Delete.Clear();
            textBox_Full_Name_Org_Update_Delete.Clear();
            textBox_Short_Name_Org_Update_Delete.Clear();
            maskedTextBox_Create_date_Org.Clear();
            maskedTextBox_Create_date_Org.Clear();
            comboBox_Countyr_Org.SelectedValue = "(не выбрано)";
            comboBox_Countyr_Pers.SelectedValue = "(не выбрано)";
            comboBox_Section.SelectedValue = "(не выбрано)";
            checkBox_Ownership_Org.Checked = false;
            Tax_Debt.Checked = false;
            Prev_Broker_Client.Checked = false;
            Debts_Enforcement_Documents.Checked = false;
            False_Business.Checked = false;
            Special_Risc.Checked = false;
            Execute_Proc.Checked = false;
            Bankruptcy_Proc.Checked = false;
            Liquidation_Proc.Checked = false;
            Resident.Checked = false;
            Broker_Client.Checked = false;
            Trading_experience.Checked = false;
            Trader.Checked = false;
            First_Accred.Checked = false;
            Second_Accred.Checked = false;
            Manufacturer.Checked = false;
            Exchenge_Trading_Disorders.Checked = false;
            Negativ_Data.Checked = false;
            Reputation.Checked = false;
            Prev_Liquidated.Checked = false;
            Prev_Bankruptcy.Checked = false;
            Prev_Execute_Proc.Checked = false;
            Prev_Tax_Debt.Checked = false;
            Prev_State_Debt.Checked = false;
            Negativ_Data_Pers.Checked = false;
            Name_Owner.Clear();
            TextBox_Name_Head.Clear();
            Description_Pers.Clear();
            Description_ORG.Clear();
            textBox_BrokerOpinion.Clear();
            textBox_Section_Head_Opinion.Clear();
            textBox_Auditor_Opinion.Clear();
            checkBox_Forced_Deposite_Small.Checked = false;
            checkBox_Forced_Deposite_Large.Checked = false;
            Risc_Level.Visible = false;
            label_Not_Two_Depos_Small.Visible = false;
            label_Not_Two_Depos_Largw.Visible = false;
        }

        private void Apdate_Delete_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet8.Section". При необходимости она может быть перемещена или удалена.
            this.sectionTableAdapter.Fill(this.kontragentDataSet8.Section);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet7.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter1.Fill(this.kontragentDataSet7.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet6.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.kontragentDataSet6.Country);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand Delete_ORG_Cascade = new SqlCommand("Delete_ORG_Cascade", sqlConnection); //Проца на удаление КАСКАДНОЕ!!!!!!!
                Delete_ORG_Cascade.CommandType = CommandType.StoredProcedure;

                Delete_ORG_Cascade.Parameters.AddWithValue("UNP_Org", textBox_UNP_Update_Delete.Text);
                Delete_ORG_Cascade.Parameters.AddWithValue("Short_Name_Org", textBox_Short_Name_Org_Update_Delete.Text);
                Delete_ORG_Cascade.Parameters.AddWithValue("Full_Name_Org", textBox_Full_Name_Org_Update_Delete.Text);

                DialogResult dialogResult = MessageBox.Show($"При подтверждении операции данные будут удалены безвозвратно!", "Внимание!!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Delete_ORG_Cascade.ExecuteNonQuery();
                    MessageBox.Show($"Огранизация {textBox_Short_Name_Org_Update_Delete.Text} удалена!!! ");
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label_Not_Two_Depos_Small.Visible = false;
            label_Not_Two_Depos_Largw.Visible = false;
            if (checkBox_Forced_Deposite_Small.Checked && checkBox_Forced_Deposite_Large.Checked)
            {
                MessageBox.Show("Не возможно одновременно применить два вида задатка!!!");
                label_Not_Two_Depos_Small.Visible = true;
                label_Not_Two_Depos_Largw.Visible = true;
                return;
            }

            CHECK_class cHECK_Class = new CHECK_class();

            #region проверка УНП
            //проверка УНП на пустое поле
            if (!string.IsNullOrEmpty(textBox_UNP_Update_Delete.Text) && !string.IsNullOrWhiteSpace(textBox_UNP_Update_Delete.Text))
            {   //Проверка УНП на идентичность
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    if (!cHECK_Class.Check_UNP(textBox_UNP_Update_Delete.Text) == true)
                    {
                        ORG.UNP_Org = textBox_UNP_Update_Delete.Text;
                        label_err_UNP.Visible = false;
                    }
                    if (cHECK_Class.Check_UNP(textBox_UNP_Update_Delete.Text) == true)
                    {
                        ORG.UNP_Org_New = textBox_UNP_Update_Delete.Text;
                        label_err_UNP.Visible = false;
                    }
                }
            }
            else
            {
                label_err_UNP.Visible = true;
                label_UNP.Visible = true;
                return;
            }
            #endregion

            #region Проверка краткого имени
            //Проверка на пустое поле Кр. имени
            if (!string.IsNullOrEmpty(textBox_Short_Name_Org_Update_Delete.Text) && !string.IsNullOrWhiteSpace(textBox_Short_Name_Org_Update_Delete.Text))
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    if (!cHECK_Class.Check_Short_Name_Org(textBox_Short_Name_Org_Update_Delete.Text) == true)
                    {
                        label_err_Short_Name.Visible = false;
                        label_Short_Name.Visible = true;
                        ORG.Short_Name_Org = textBox_Short_Name_Org_Update_Delete.Text;
                    }
                    if (cHECK_Class.Check_Short_Name_Org(textBox_Short_Name_Org_Update_Delete.Text) == true)
                    {
                        label_err_Short_Name.Visible = false;
                        label_Short_Name.Visible = true;
                        ORG.Short_Name_Org_New = textBox_Short_Name_Org_Update_Delete.Text;
                    }
                }
            }
            else
            {
                label_Short_Name.Visible = false;
                label_err_Short_Name.Visible = true;
                return;
            }
            #endregion

            #region проверка полного имени
            //Проверка полного имени на идентичность
            if (!string.IsNullOrEmpty(textBox_Full_Name_Org_Update_Delete.Text) && !string.IsNullOrWhiteSpace(textBox_Full_Name_Org_Update_Delete.Text))
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    if (!cHECK_Class.Check_Full_Name_Org(textBox_UNP_Update_Delete.Text) == true)
                    {
                        label_err_Full_Name.Visible = false;
                        label_Full_Name_Org.Visible = true;
                        ORG.Full_Name_Org = textBox_Full_Name_Org_Update_Delete.Text;
                    }
                    if (cHECK_Class.Check_Full_Name_Org(textBox_UNP_Update_Delete.Text) == true)
                    {
                        label_err_Full_Name.Visible = false;
                        label_Full_Name_Org.Visible = true;
                        ORG.Full_Name_Org_New = textBox_Full_Name_Org_Update_Delete.Text;
                    }
                }
            }
            else
            {
                label_Full_Name_Org.Visible = false;
                label_err_Full_Name.Visible = true;
                return;
            }

            #endregion

            #region Проверка даты
            // Проверка корректности вводимой даты
            if (cHECK_Class.Check_Create_date_Org(maskedTextBox_Create_date_Org.Text) == true)
            {
                label_Incorrect_Date.Visible = false;
                Age_Org_1.Visible = true;

                //DateTime dateTime = DateTime.ParseExact(maskedTextBox_Create_date_Org.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None);
                DateTime dateTime = Convert.ToDateTime(maskedTextBox_Create_date_Org.Text);
                ORG.Create_date_Org = dateTime;
            }
            else
            {
                Age_Org_1.Visible = false;
                label_Incorrect_Date.Visible = true;
                return;
            }
            #endregion

            #region проверка страны
            //Проверка ввода страны
            if (cHECK_Class.Check_Country(comboBox_Countyr_Org.Text) == true)
            {
                label_Country_Org_Err.Visible = false;
                label_Country_Org.Visible = true;
                ORG.Countyr_Org = comboBox_Countyr_Org.Text;
            }
            else
            {
                label_Country_Org.Visible = false;
                label_Country_Org_Err.Visible = true;
                return;
            }
            #endregion

            #region проверка секции
            //Проверка секции
            if (cHECK_Class.Check_Section(comboBox_Section.Text) == true)
            {
                label_err_Section.Visible = false;
                label_Section.Visible = true;
                ORG.Name_Section = comboBox_Section.Text;
            }
            else
            {
                label_Section.Visible = false;
                label_err_Section.Visible = true;
                return;
            }
            #endregion

            #region проверка страны руководителч
            //Проверка страны руководителя
            if (cHECK_Class.Check_Country_Pers(comboBox_Countyr_Pers.Text) == true)
            {
                label_err_Country_Pers.Visible = false;
                label1_Country_Pers.Visible = true;
                ORG.Country_Pers = comboBox_Countyr_Pers.Text;
            }
            else
            {
                label1_Country_Pers.Visible = false;
                label_err_Country_Pers.Visible = true;
                return;
            }
            #endregion

            #region проверка данных собственноика
            //Проверка данных собственника
            if (!string.IsNullOrEmpty(Name_Owner.Text) && !string.IsNullOrWhiteSpace(Name_Owner.Text))
            {
                label_err_Owneer_Name.Visible = false;
                label_Name_Head.Visible = true;
                ORG.Owner_Name = Name_Owner.Text;
            }
            else
            {
                label_Name_Head.Visible = false;
                label_err_Owneer_Name.Visible = true;
                return;
            }
            #endregion

            #region проверка данных руководителя
            // Проверка данных руководителя
            if (!string.IsNullOrEmpty(TextBox_Name_Head.Text) && !string.IsNullOrWhiteSpace(TextBox_Name_Head.Text))
            {
                label_err_Head_Name.Visible = false;
                label_Name_Owner.Visible = true;
                ORG.Head_Name = TextBox_Name_Head.Text;
            }
            else
            {
                label_Name_Owner.Visible = false;
                label_err_Head_Name.Visible = true;
                return;
            }
            #endregion

            #region мнение брокера
            if (string.IsNullOrEmpty(textBox_BrokerOpinion.Text) && string.IsNullOrWhiteSpace(textBox_BrokerOpinion.Text))
            {
                ORG.Broker_Opinion = "нет";
            }
            else
            {
                ORG.Broker_Opinion = textBox_BrokerOpinion.Text;
            }
            #endregion

            #region мнение профильного управления
            if (string.IsNullOrEmpty(textBox_Section_Head_Opinion.Text) && string.IsNullOrWhiteSpace(textBox_Section_Head_Opinion.Text))
            {
                ORG.Section_Head_Opinion = "нет";
            }
            else
            {
                ORG.Section_Head_Opinion = textBox_Section_Head_Opinion.Text;
            }
            #endregion

            #region мнение проверяющего
            if (string.IsNullOrEmpty(textBox_Auditor_Opinion.Text) && string.IsNullOrWhiteSpace(textBox_Auditor_Opinion.Text))
            {
                ORG.Auditor_Opinion = "нет";
            }
            else
            {
                ORG.Auditor_Opinion = textBox_Auditor_Opinion.Text;
            }
            #endregion

            #region описание организации
            if (string.IsNullOrEmpty(Description_ORG.Text) && string.IsNullOrWhiteSpace(Description_ORG.Text))
            {
                ORG.Description_ORG = "нет";
            }
            else
            {
                ORG.Description_ORG = Description_ORG.Text;
            }
            #endregion

            #region описание руководителей
            if (string.IsNullOrEmpty(Description_Pers.Text) && string.IsNullOrWhiteSpace(Description_Pers.Text))
            {
                ORG.Description_Pers = "нет";
            }
            else
            {
                ORG.Description_Pers = Description_Pers.Text;
            }
            #endregion


            if (checkBox_Ownership_Org.Checked) { ORG.Ownership_Org = 1; }
            if (!checkBox_Ownership_Org.Checked) { ORG.Ownership_Org = 0; }

            if (Tax_Debt.Checked) { ORG.Tax_Debt = 1; }
            if (!Tax_Debt.Checked) { ORG.Tax_Debt = 0; }

            if (Debts_Enforcement_Documents.Checked) { ORG.Debts_Enforcement_Documents = 1; }
            if (!Debts_Enforcement_Documents.Checked) { ORG.Debts_Enforcement_Documents = 0; }

            if (False_Business.Checked) { ORG.False_Business = 1; }
            if (!False_Business.Checked) { ORG.False_Business = 0; }

            if (Special_Risc.Checked) { ORG.Special_Risc = 1; }
            if (!Special_Risc.Checked) { ORG.Special_Risc = 0; }

            if (Execute_Proc.Checked) { ORG.Execute_Proc = 1; }
            if (!Execute_Proc.Checked) { ORG.Execute_Proc = 0; }

            if (Bankruptcy_Proc.Checked) { ORG.Bankruptcy_Proc = 1; }
            if (!Bankruptcy_Proc.Checked) { ORG.Bankruptcy_Proc = 0; }

            if (Liquidation_Proc.Checked) { ORG.Liquidation_Proc = 1; }
            if (!Liquidation_Proc.Checked) { ORG.Liquidation_Proc = 0; }

            if (Resident.Checked) { ORG.Resident = 1; }
            if (!Resident.Checked) { ORG.Resident = 0; }

            if (Broker_Client.Checked) { ORG.Broker_Client = 1; }
            if (!Broker_Client.Checked) { ORG.Broker_Client = 0; }

            if (Prev_Broker_Client.Checked) { ORG.Prev_Broker_Client = 1; }
            if (!Prev_Broker_Client.Checked) { ORG.Prev_Broker_Client = 0; }

            if (Trading_experience.Checked) { ORG.Trading_experience = 1; }
            if (!Trading_experience.Checked) { ORG.Trading_experience = 0; }

            if (Trader.Checked) { ORG.Trader = 1; }
            if (!Trader.Checked) { ORG.Trader = 0; }

            if (Manufacturer.Checked) { ORG.Manufacturer = 1; }
            if (!Manufacturer.Checked) { ORG.Manufacturer = 0; }

            if (First_Accred.Checked) { ORG.First_Accred = 1; }
            if (!First_Accred.Checked) { ORG.First_Accred = 0; }

            if (Second_Accred.Checked) { ORG.Second_Accred = 1; }
            if (!Second_Accred.Checked) { ORG.Second_Accred = 0; }

            if (Exchenge_Trading_Disorders.Checked) { ORG.Exchenge_Trading_Disorders = 1; }
            if (!Exchenge_Trading_Disorders.Checked) { ORG.Exchenge_Trading_Disorders = 0; }

            if (Negativ_Data.Checked) { ORG.Negativ_Data = 1; }
            if (!Negativ_Data.Checked) { ORG.Negativ_Data = 0; }

            if (Reputation.Checked) { ORG.Reputation = 1; }
            if (!Reputation.Checked) { ORG.Reputation = 0; }

            if (Prev_Liquidated.Checked) { ORG.Prev_Liquidated = 1; }
            if (!Prev_Liquidated.Checked) { ORG.Prev_Liquidated = 0; }

            if (Prev_Bankruptcy.Checked) { ORG.Prev_Bankruptcy = 1; }
            if (!Prev_Bankruptcy.Checked) { ORG.Prev_Bankruptcy = 0; }

            if (Prev_Execute_Proc.Checked) { ORG.Prev_Execute_Proc = 1; }
            if (!Prev_Execute_Proc.Checked) { ORG.Prev_Execute_Proc = 0; }

            if (Negativ_Data_Pers.Checked) { ORG.Negativ_Data_Pers = 1; }
            if (!Negativ_Data_Pers.Checked) { ORG.Negativ_Data_Pers = 0; }

            if (Prev_Tax_Debt.Checked) { ORG.Prev_Tax_Debt = 1; }
            if (!Prev_Tax_Debt.Checked) { ORG.Prev_Tax_Debt = 0; }

            if (Prev_State_Debt.Checked) { ORG.Prev_State_Debt = 1; }
            if (!Prev_State_Debt.Checked) { ORG.Prev_State_Debt = 0; }

            if (checkBox_Forced_Deposite_Small.Checked) { ORG.Forced_Deposite_Small = 1;} else {ORG.Forced_Deposite_Small = 0;}
            if (checkBox_Forced_Deposite_Large.Checked) { ORG.Forced_Deposite_Large = 1;} else {ORG.Forced_Deposite_Large = 0;}

            SQL_ADD_Parametrs aDD_Parametrs_Update = new SQL_ADD_Parametrs();

            DialogResult dialogResult = MessageBox.Show($"Господин {ORG.Login_User}, Вы действительно правильно заполнили поля?", "Контрольный выстрел!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                aDD_Parametrs_Update.Update_ORG(oRG);
                MessageBox.Show($"Изменнения приянты!");
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void ComboBox_Countyr_Org_Leave(object sender, EventArgs e)
        {
            comboBox_Countyr_Org.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void ComboBox_Section_Leave(object sender, EventArgs e)
        {
            comboBox_Section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void ComboBox_Countyr_Pers_Leave_1(object sender, EventArgs e)
        {
            comboBox_Countyr_Pers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }



        private void CheckBox_Forced_Deposite_Small_Leave(object sender, EventArgs e)
        {
            if (checkBox_Forced_Deposite_Small.Checked == true && checkBox_Forced_Deposite_Large.Checked == true)
            {

                MessageBox.Show("Невозможно одновременно выбрать два вида задатка!", "Внимание!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                checkBox_Forced_Deposite_Small.Checked = false;
                checkBox_Forced_Deposite_Large.Checked = false;
                label_Not_Two_Depos_Small.Visible = true;
                label_Not_Two_Depos_Largw.Visible = true;
                return;
            }
            if (checkBox_Forced_Deposite_Small.Checked == true && checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Not_Two_Depos_Small.Visible = false;
                label_Not_Two_Depos_Largw.Visible = false;
            }
        }

        private void CheckBox_Forced_Deposite_Large_Leave(object sender, EventArgs e)
        {
            if (checkBox_Forced_Deposite_Small.Checked == true && checkBox_Forced_Deposite_Large.Checked == true)
            {

                MessageBox.Show("Невозможно одновременно выбрать два вида задатка!", "Внимание!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                checkBox_Forced_Deposite_Small.Checked = false;
                checkBox_Forced_Deposite_Large.Checked = false;
                label_Not_Two_Depos_Small.Visible = true;
                label_Not_Two_Depos_Largw.Visible = true;
                return;
            }
            if (checkBox_Forced_Deposite_Large.Checked == true && checkBox_Forced_Deposite_Small.Checked == false)
            {
                label_Not_Two_Depos_Small.Visible = false;
                label_Not_Two_Depos_Largw.Visible = false;
            }
        }
    }
}



