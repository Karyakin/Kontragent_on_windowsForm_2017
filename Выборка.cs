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

namespace WindowsFormsApp3
{
    public partial class Search : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        ORG oRG = new ORG();
        CHECK_class cHECK_Class = new CHECK_class();



        public Search()
        {
            InitializeComponent();
            /* dateTimePicker_Check_date_START.Format = DateTimePickerFormat.Custom;
             dateTimePicker_Check_date_START.CustomFormat = "MM/dd/yyyy hh:mm";

             dateTimePicker_Create_date_FINAL.Format = DateTimePickerFormat.Custom;
             dateTimePicker_Create_date_FINAL.CustomFormat = "MM/dd/yyyy hh:mm";*/
            label_Err_Only_Digit_Min.Visible = false;
            label_Err_Only_Digit_Max.Visible = false;

            

        }


        private void Button2_Click(object sender, EventArgs e)
        {
            ORG_SELECT.UNP_Org = textBox_UNP_Org_SELECT.Text;
            ORG_SELECT.Full_Name_Org = textBox_Full_Name_Org_SELECT.Text;
            ORG_SELECT.Short_Name_Org = textBox_Short_Name_Org_SELECT.Text;
            ORG_SELECT.Countyr_Org = comboBox_Countyr_Org_SELECT.Text;
            ORG_SELECT.Name_Section = comboBox_Name_Section.Text;

            ORG_SELECT.Country_Pers = comboBox_SELECT_Country_Pers.Text;


            ORG_SELECT.Create_date_Org_START = Convert.ToDateTime(dateTimePicker_Create_date_Org_STARTL.Text);
            ORG_SELECT.Create_date_Org_FINAL = Convert.ToDateTime(dateTimePicker_Create_date_Org_FINAL.Text);


            ORG_SELECT.dateTimePicker_Check_date_START = Convert.ToDateTime(dateTimePicker_Check_date_START.Text);
            ORG_SELECT.dateTimePicker_Create_date_FINAL = Convert.ToDateTime(dateTimePicker_Create_date_FINAL.Text);

            ORG_SELECT.Owner_Name = textBox_Owner_Name.Text;
            ORG_SELECT.Head_Name = textBox_Head_Name.Text;

            ORG_SELECT.Risc_Level_Less = textBox_Risc_Level_Less.Text;
            ORG_SELECT.Risc_Level_More = textBox_Risc_Level_More.Text;


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand general_SELECT = new SqlCommand("General_SELECT", sqlConnection);
                general_SELECT.CommandType = CommandType.StoredProcedure;




                if (string.IsNullOrEmpty(textBox_UNP_Org_SELECT.Text) && string.IsNullOrWhiteSpace(textBox_UNP_Org_SELECT.Text)) { general_SELECT.Parameters.AddWithValue("UNP_Org", null); }
                else { general_SELECT.Parameters.AddWithValue("UNP_Org", ORG_SELECT.UNP_Org); }

                if (string.IsNullOrEmpty(textBox_Full_Name_Org_SELECT.Text) && string.IsNullOrWhiteSpace(textBox_Full_Name_Org_SELECT.Text)) { general_SELECT.Parameters.AddWithValue("Full_Name_Org", null); }
                else { general_SELECT.Parameters.AddWithValue("Full_Name_Org", ORG_SELECT.Full_Name_Org); }

                if (string.IsNullOrEmpty(textBox_Short_Name_Org_SELECT.Text) && string.IsNullOrWhiteSpace(textBox_Short_Name_Org_SELECT.Text)) { general_SELECT.Parameters.AddWithValue("Short_Name_Org", null); }
                else { general_SELECT.Parameters.AddWithValue("Short_Name_Org", ORG_SELECT.Short_Name_Org); }

                if (comboBox_Countyr_Org_SELECT.Text == "(не выбрано)") { general_SELECT.Parameters.AddWithValue("Name_Country", null); }
                else { general_SELECT.Parameters.AddWithValue("Name_Country", ORG_SELECT.Countyr_Org); }
               
                if (comboBox_Name_Section.Text == "(не выбрано)") { general_SELECT.Parameters.AddWithValue("Name_Section", null); }
                else { general_SELECT.Parameters.AddWithValue("Name_Section", ORG_SELECT.Name_Section); }

                general_SELECT.Parameters.AddWithValue("Create_date_Org_START", ORG_SELECT.Create_date_Org_START);
                general_SELECT.Parameters.AddWithValue("Create_date_Org_FINAL", ORG_SELECT.Create_date_Org_FINAL);

                general_SELECT.Parameters.AddWithValue("Check_Date_Org_START", ORG_SELECT.dateTimePicker_Check_date_START);
                general_SELECT.Parameters.AddWithValue("Check_Date_Org_FINAL", ORG_SELECT.dateTimePicker_Create_date_FINAL);

                if (comboBox_SELECT_Country_Pers.Text == "(не выбрано)") { general_SELECT.Parameters.AddWithValue("Country_Pers", null); }
                else { general_SELECT.Parameters.AddWithValue("Country_Pers", ORG_SELECT.Country_Pers); }

                if (string.IsNullOrEmpty(textBox_Owner_Name.Text) && string.IsNullOrWhiteSpace(textBox_Owner_Name.Text)) { general_SELECT.Parameters.AddWithValue("Owner_Name", null); }
                else { general_SELECT.Parameters.AddWithValue("Owner_Name", ORG_SELECT.Owner_Name); }

                if (string.IsNullOrEmpty(textBox_Head_Name.Text) && string.IsNullOrWhiteSpace(textBox_Head_Name.Text)) { general_SELECT.Parameters.AddWithValue("Head_Name", null); }
                else { general_SELECT.Parameters.AddWithValue("Head_Name", ORG_SELECT.Head_Name); }
                
                #region Чекбоксы для SELECT

                if (checkBox_Ownership_Org.Checked) { general_SELECT.Parameters.AddWithValue("Ownership_Org", 1); }
                else { general_SELECT.Parameters.AddWithValue("Ownership_Org", null); }//Госпредприятие

                if (checkBox_Tax_Debt.Checked) { general_SELECT.Parameters.AddWithValue("Tax_Debt", 1); }
                else { general_SELECT.Parameters.AddWithValue("Tax_Debt", null); }//Задолженности по налогам

                if (checkBox_Debts_Enforcement_Documents.Checked) { general_SELECT.Parameters.AddWithValue("Debts_Enforcement_Documents", 1); }
                else { general_SELECT.Parameters.AddWithValue("Debts_Enforcement_Documents", null); }//Задолженности по исполнительным документам

                if (checkBox_False_Business.Checked) { general_SELECT.Parameters.AddWithValue("False_Business", 1); }
                else { general_SELECT.Parameters.AddWithValue("False_Business", null); }//Лжепредпринимательство

                if (checkBox_Special_Risc.Checked) { general_SELECT.Parameters.AddWithValue("Special_Risc", 1); }
                else { general_SELECT.Parameters.AddWithValue("Special_Risc", null); }//Особый риск

                if (checkBox_Execute_Proc.Checked) { general_SELECT.Parameters.AddWithValue("Execute_Proc", 1); }
                else { general_SELECT.Parameters.AddWithValue("Execute_Proc", null); }//Исполнительное производство

                if (checkBox_Bankruptcy_Proc.Checked) { general_SELECT.Parameters.AddWithValue("Bankruptcy_Proc", 1); }
                else { general_SELECT.Parameters.AddWithValue("Bankruptcy_Proc", null); }//Банкротство

                if (checkBox_Liquidation_Proc.Checked) { general_SELECT.Parameters.AddWithValue("Liquidation_Proc", 1); }
                else { general_SELECT.Parameters.AddWithValue("Liquidation_Proc", null); }//Процесс ликвидации

                if (checkBox_Resident.Checked) {general_SELECT.Parameters.AddWithValue("Resident", 1); }
                if (checkBox_NOT_Resident.Checked) { general_SELECT.Parameters.AddWithValue("Resident", 0); }

                if (checkBox_Forset_Deposite.Checked) { general_SELECT.Parameters.AddWithValue("Forced_Deposite", 1); }
                if (!checkBox_Forset_Deposite.Checked) { general_SELECT.Parameters.AddWithValue("Forced_Deposite", null); }

                if (checkBox_Broker_Client.Checked) { general_SELECT.Parameters.AddWithValue("Broker_Client", 1); }
                else { general_SELECT.Parameters.AddWithValue("Broker_Client", null); }//Клиент брокера

                if (checkBox_Prev_Broker_Client.Checked) { general_SELECT.Parameters.AddWithValue("Prev_Broker_Client", 1); }
                else { general_SELECT.Parameters.AddWithValue("Prev_Broker_Client", null); }//Клиент брокера

                if (checkBox_Trading_experience.Checked) { general_SELECT.Parameters.AddWithValue("Trading_experience", 1); }
                else { general_SELECT.Parameters.AddWithValue("Trading_experience", null); }//Опыт торгов

                if (checkBox_Trader.Checked) { general_SELECT.Parameters.AddWithValue("Trader", 1); }
                else { general_SELECT.Parameters.AddWithValue("Trader", null); }//Трейдер

                if (checkBox_Manufacturer.Checked) { general_SELECT.Parameters.AddWithValue("Manufacturer", 1); }
                else { general_SELECT.Parameters.AddWithValue("Manufacturer", null); }//Производитель

                if (checkBox_First_Accred.Checked) { general_SELECT.Parameters.AddWithValue("First_Accred", 1); }
                else { general_SELECT.Parameters.AddWithValue("First_Accred", null); }//Первичная аккредитация

                if (checkBox_Second_Accred.Checked) { general_SELECT.Parameters.AddWithValue("Second_Accred", 1); }
                else { general_SELECT.Parameters.AddWithValue("Second_Accred", null); }//Первичная аккредитация

                if (checkBox_Exchenge_Trading_Disorders.Checked) { general_SELECT.Parameters.AddWithValue("Exchenge_Trading_Disorders", 1); }
                else { general_SELECT.Parameters.AddWithValue("Exchenge_Trading_Disorders", null); }//Нарушение правил торгов

                if (checkBox_Negativ_Data.Checked) { general_SELECT.Parameters.AddWithValue("Negativ_Data", 1); }
                else { general_SELECT.Parameters.AddWithValue("Negativ_Data", null); }//Негатив

                if (checkBox_Reputation.Checked) { general_SELECT.Parameters.AddWithValue("Reputation", 1); }
                else { general_SELECT.Parameters.AddWithValue("Reputation", null); }//Репутация

                if (checkBox_Prev_Tax_Debt.Checked) { general_SELECT.Parameters.AddWithValue("Prev_Tax_Debt", 1); }
                else { general_SELECT.Parameters.AddWithValue("Prev_Tax_Debt", null); }//Наличие задолженностей по налогам у руководителей

                if (checkBox_Prev_Liquidated.Checked) { general_SELECT.Parameters.AddWithValue("Prev_Liquidated", 1); }
                else { general_SELECT.Parameters.AddWithValue("Prev_Liquidated", null); }//Наличие ранее ликвидированных

                if (checkBox_Prev_Bankruptcy.Checked) { general_SELECT.Parameters.AddWithValue("Prev_Bankruptcy", 1); }
                else { general_SELECT.Parameters.AddWithValue("Prev_Bankruptcy", null); }//Наличие ранее обанкротившихся

                if (checkBox_Prev_Execute_Proc.Checked) { general_SELECT.Parameters.AddWithValue("Prev_Execute_Proc", 1); }
                else { general_SELECT.Parameters.AddWithValue("Prev_Execute_Proc", null); }//Наличие ранее исполнительных производств

                if (checkBox_Negativ_Owner.Checked) { general_SELECT.Parameters.AddWithValue("Negativ_Data_Pers", 1); }
                else { general_SELECT.Parameters.AddWithValue("Negativ_Data_Pers", null); }//Негатив в отношении руководителя

                if (checkBox_Prev_State_Debt.Checked) { general_SELECT.Parameters.AddWithValue("Prev_State_Debt", 1); }
                else { general_SELECT.Parameters.AddWithValue("Prev_State_Debt", null); }//Негатив в отношении руководителя

                if (string.IsNullOrEmpty(textBox_Risc_Level_Less.Text) && string.IsNullOrWhiteSpace(textBox_Risc_Level_Less.Text)) { general_SELECT.Parameters.AddWithValue("Risc_Level_Less", null); }
                else//проверка на ввод только цифр в степени риска "От"
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBox_Risc_Level_Less.Text, "[^0-9]"))
                    {
                        label_Err_Only_Digit_Max.Visible = true;
                        return;
                    }
                    general_SELECT.Parameters.AddWithValue("Risc_Level_Less", ORG_SELECT.Risc_Level_Less);
                    label_Err_Only_Digit_Max.Visible = false;
                }

                if (string.IsNullOrEmpty(textBox_Risc_Level_More.Text) && string.IsNullOrWhiteSpace(textBox_Risc_Level_More.Text)) { general_SELECT.Parameters.AddWithValue("Risc_Level_More", null); }
                else//проверка на ввод только цифр в степени риска "До"
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBox_Risc_Level_More.Text, "[^0-9]"))
                    {
                        label_Err_Only_Digit_Min.Visible = true;
                        return;
                    }
                    general_SELECT.Parameters.AddWithValue("Risc_Level_More", ORG_SELECT.Risc_Level_More);
                    label_Err_Only_Digit_Min.Visible = false;
                }


                #endregion

                SqlDataReader reader_SELECT = null;
                reader_SELECT = general_SELECT.ExecuteReader();

                listView1.Clear();

                listView1.GridLines = true;

                listView1.FullRowSelect = true;
                listView1.View = View.Details;

                listView1.Columns.Add("№");
                listView1.Columns.Add("УНП");
                listView1.Columns.Add("Полное");
                listView1.Columns.Add("Кратное");
                listView1.Columns.Add("Страна");
                listView1.Columns.Add("Секция");
                listView1.Columns.Add("Дата создания");

                if (checkBox_Description_ORG.Checked) { listView1.Columns.Add("Описание предприятия"); }
                if (checkBox_Description_Pers.Checked) { listView1.Columns.Add("Описание руководителей"); }
                if (checkBox_Auditor_Opinion.Checked) { listView1.Columns.Add("Мнение проверяющего"); }
                if (checkBox_Section_Head_Opinion.Checked) { listView1.Columns.Add("Мнение профильного управления"); }
                if (checkBox_textBox_BrokerOpinion.Checked) { listView1.Columns.Add("Мнение брокера"); }
                if (checkBox3.Checked) { listView1.Columns.Add("Гражданство руководства"); }
                if (checkBox2.Checked) { listView1.Columns.Add("Руководители"); }
                if (checkBox4.Checked) { listView1.Columns.Add("Учредители"); }
                if (checkBox_Check_Date.Checked) { listView1.Columns.Add("Дата проверки"); }
                if (checkBox_Auditor.Checked) { listView1.Columns.Add("Проверяющий"); }
                if (checkBox_Risc_Level.Checked) { listView1.Columns.Add("Степень риска"); }
                if (checkBox_Recomend_Deposit.Checked) { listView1.Columns.Add("Рекомендуемый задаток"); }
                if (checkBox_Deposite.Checked) { listView1.Columns.Add("Вид задатка"); }
                if (User_Update.Checked) { listView1.Columns.Add("Автор изменений"); }


                int numb = 0;

                while (reader_SELECT.Read())
                {
                    List<string> qqq = new List<string>();
                    numb++;
                    qqq.Add(Convert.ToString(numb));
                    qqq.Add(Convert.ToString(reader_SELECT["UNP_Org"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Full_Name_Org"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Short_Name_Org"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Name_Country"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Name_Section"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Create_date_Org"]));


                    if (checkBox_Description_ORG.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Description_Org"])); }
                    if (checkBox_Description_Pers.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Description_Pers"])); }
                    if (checkBox_Auditor_Opinion.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Auditor_Opinion"])); }
                    if (checkBox_Section_Head_Opinion.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Section_Head_Opinion"])); }
                    if (checkBox_textBox_BrokerOpinion.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Broker_Opinion"])); }
                    if (checkBox3.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Country_Pers"])); }
                    if (checkBox2.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Head_Name"])); }
                    if (checkBox4.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Owner_Name"])); }
                    if (checkBox_Check_Date.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Check_Date_Org"])); }
                    if (checkBox_Auditor.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Проверяющий"])); }
                    if (checkBox_Risc_Level.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Степень риска"])); }
                    if (checkBox_Recomend_Deposit.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Рекомендуемый вид задатка"])); }
                    if (checkBox_Deposite.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Вид задатка"])); }
                    if (User_Update.Checked) { qqq.Add(Convert.ToString(reader_SELECT["Автор изменений"])); }

                    ListViewItem item = new ListViewItem(qqq.ToArray());
                    listView1.Items.Add(item);

                }

                sqlConnection.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
        }

        private void Button4_Click(object sender, EventArgs e)
        {


            comboBox_Countyr_Org_SELECT.SelectedValue = "(Не выбрано)";
            comboBox_Name_Section.SelectedValue = "(Не выбрано)";
            comboBox_SELECT_Country_Pers.SelectedValue = "(Не Выбрано)";



            textBox_UNP_Org_SELECT.Clear();
            textBox_Short_Name_Org_SELECT.Clear();
            textBox_Full_Name_Org_SELECT.Clear();

            dateTimePicker_Create_date_Org_STARTL.Value =  dateTimePicker_Create_date_Org_STARTL.MinDate;
            dateTimePicker_Create_date_Org_FINAL.Value = DateTime.Now;
            
            textBox_Owner_Name.Clear();
            textBox_Head_Name.Clear();
            checkBox_Ownership_Org.Checked = false;
            checkBox_Tax_Debt.Checked = false;
            checkBox_Debts_Enforcement_Documents.Checked = false;
            checkBox_False_Business.Checked = false;
            checkBox_Special_Risc.Checked = false;
            checkBox_Execute_Proc.Checked = false;
            checkBox_Bankruptcy_Proc.Checked = false;
            checkBox_Liquidation_Proc.Checked = false;
            checkBox_Resident.Checked = false;
            checkBox_Broker_Client.Checked = false;
            checkBox_Prev_Broker_Client.Checked = false;
            checkBox_Trading_experience.Checked = false;
            checkBox_Trader.Checked = false;
            checkBox_Manufacturer.Checked = false;
            checkBox_First_Accred.Checked = false;
            checkBox_Second_Accred.Checked = false;
            checkBox_Exchenge_Trading_Disorders.Checked = false;
            checkBox_Negativ_Data.Checked = false;
            checkBox_Reputation.Checked = false;
            checkBox_Prev_Tax_Debt.Checked = false;
            checkBox_Prev_Liquidated.Checked = false;
            checkBox_Prev_Bankruptcy.Checked = false;
            checkBox_Prev_Execute_Proc.Checked = false;
            checkBox_Negativ_Owner.Checked = false;
            checkBox_Prev_State_Debt.Checked = false;
            checkBox_textBox_BrokerOpinion.Checked = false;
            checkBox_Section_Head_Opinion.Checked = false;
            checkBox_Auditor_Opinion.Checked = false;
            checkBox_Description_ORG.Checked = false;
            checkBox_Description_Pers.Checked = false;
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox_Check_Date.Checked = false;
            checkBox_Auditor.Checked = false;
            checkBox_Risc_Level.Checked = false;

            dateTimePicker_Check_date_START.Value = dateTimePicker_Check_date_START.MinDate;
            dateTimePicker_Create_date_FINAL.Value = dateTimePicker_Create_date_FINAL.MaxDate;

            textBox_Risc_Level_More.Clear();
            textBox_Risc_Level_Less.Clear();

            checkBox_Recomend_Deposit.Checked = false;
            checkBox_Deposite.Checked = false;

            label_Err_Only_Digit_Min.Visible = false;
            label_Err_Only_Digit_Max.Visible = false;

           
        }

        private void Search_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet16.View_Section". При необходимости она может быть перемещена или удалена.
            this.view_SectionTableAdapter.Fill(this.kontragentDataSet16.View_Section);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet15.View_Country". При необходимости она может быть перемещена или удалена.
            this.view_CountryTableAdapter1.Fill(this.kontragentDataSet15.View_Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet14.View_Country". При необходимости она может быть перемещена или удалена.
            this.view_CountryTableAdapter.Fill(this.kontragentDataSet14.View_Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet2.Section". При необходимости она может быть перемещена или удалена.

            comboBox_Countyr_Org_SELECT.SelectedValue = "(Не выбрано)";
            comboBox_Name_Section.SelectedValue = "(Не выбрано)";
            comboBox_SELECT_Country_Pers.SelectedValue = "(Не Выбрано)";

        }

        private void CheckBox_Resident_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Resident.Checked == true)
            {
                checkBox_NOT_Resident.Checked = false;
                checkBox_NOT_Resident.Enabled = false;
            }
            if (checkBox_Resident.Checked == false)
            {
                checkBox_NOT_Resident.Checked = false;
                checkBox_NOT_Resident.Enabled = true;
            }
        }

        private void CheckBox_NOT_Resident_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_NOT_Resident.Checked == true)
            {
                checkBox_Resident.Checked = false;
                checkBox_Resident.Enabled = false;
            }
            else
            {
                checkBox_Resident.Enabled = true;
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            ListViewItem item = listView1.SelectedItems[0];

            ORG.UNP_Org = item.SubItems[1].Text;

           // SQL_ADD_Parametrs sQL_Parametrs_Apdate = new SQL_ADD_Parametrs();
            //sQL_Parametrs_Apdate.Find_For_Update_ORG(oRG);

            Apdate_Delete apdate_Delete = new Apdate_Delete(ORG.UNP_Org);
            apdate_Delete.ShowDialog();


        }
    }
}
