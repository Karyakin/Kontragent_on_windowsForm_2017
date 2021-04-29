using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp3
{
    public partial class New_Organisation : Form
    {
        private static string ConnectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        ORG oRG = new ORG();
        CHECK_class cHECK_Class = new CHECK_class();

        public New_Organisation()
        {
            InitializeComponent();
        }



        private void New_Organisation_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet13.View_Section". При необходимости она может быть перемещена или удалена.
            this.view_SectionTableAdapter.Fill(this.kontragentDataSet13.View_Section);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet12.View_Country". При необходимости она может быть перемещена или удалена.
            this.view_CountryTableAdapter1.Fill(this.kontragentDataSet12.View_Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kontragentDataSet11.View_Country". При необходимости она может быть перемещена или удалена.
            this.view_CountryTableAdapter.Fill(this.kontragentDataSet11.View_Country);

            #region lable False
            label_UNP_Err.Visible = false;
            label28.Visible = false;
            label_TextBox_Err.Visible = false;
            label_ShortName_Err.Visible = false;
            label_Fill_in_the_field.Visible = false;
            label_Organisatuon_Exists.Visible = false;
            label_invalid_date.Visible = false;
            label_Country_Org_Err.Visible = false;
            Age_Org_1.Visible = false;
            label_Need_Section.Visible = false;
            label_Point_Country_Pers.Visible = false;
            Err_label_Name_Head.Visible = false;
            label_Err_label_Name_Owner.Visible = false;
            label_Point_Diskription_Org.Visible = false;

            Resident.Visible = false;////////////////////////////////// легенький костыли следующие 4 позиции
            Trader.Checked = true;
            Trader.Visible = false;
            First_Accreditation.Checked = true;
            First_Accreditation.Visible = false;
            this.textBox_BrokerOpinion.Enabled = false;
            #endregion

            #region lable False
            label_UNP_Err.Visible = false;
            label28.Visible = false;
            label_TextBox_Err.Visible = false;
            label_ShortName_Err.Visible = false;
            label_Fill_in_the_field.Visible = false;
            label_Organisatuon_Exists.Visible = false;
            label_invalid_date.Visible = false;
            label_Country_Org_Err.Visible = false;
            Age_Org_1.Visible = false;
            label_Need_Section.Visible = false;
            label_Point_Country_Pers.Visible = false;
            Err_label_Name_Head.Visible = false;
            label_Err_label_Name_Owner.Visible = false;
            label_Point_Diskription_Org.Visible = false;


            #endregion


            Risc_Level.All_Check_Risk();

            if (checkBox1.Checked)
            {
                this.progressBar1.Increment(-ORG.Ownership_Org);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!checkBox1.Checked)
            {
                this.progressBar1.Increment(ORG.Ownership_Org);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }

            if (Resident.Checked)
            {
                this.progressBar1.Increment(-ORG.Resident);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Resident.Checked)
            {
                this.progressBar1.Increment(ORG.Resident);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }

            if (Broker_Client.Checked)
            {
                this.progressBar1.Increment(-ORG.Broker_Client);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Broker_Client.Checked)
            {
                this.progressBar1.Increment(ORG.Broker_Client);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }

            if (Trading_experience.Checked)
            {
                this.progressBar1.Increment(-ORG.Trading_experience);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }

            if (!Trading_experience.Checked)
            {
                this.progressBar1.Increment(ORG.Trading_experience);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }

            if (Manufacturer.Checked)
            {
                this.progressBar1.Increment(-ORG.Manufacturer);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Manufacturer.Checked)
            {
                this.progressBar1.Increment(ORG.Manufacturer);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }

            if (Reputation.Checked)
            {
                this.progressBar1.Increment(-ORG.Reputation);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Reputation.Checked)
            {
                this.progressBar1.Increment(ORG.Reputation);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }

            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label_Small.Visible = false;
                label_Large.Visible = true;
            }
            else
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }

            label_Auditor.Text = ORG.Login_User;
            label_Department.Text = ORG.Department;
            //label_Date.Text = Convert.ToString(ORG.Check_Date);


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                #region lable False
                label_UNP_Err.Visible = false;
                label28.Visible = false;
                label_TextBox_Err.Visible = false;
                label_ShortName_Err.Visible = false;
                label_Fill_in_the_field.Visible = false;
                label_Organisatuon_Exists.Visible = false;
                label_invalid_date.Visible = false;
                label_Country_Org_Err.Visible = false;
                label_Need_Section.Visible = false;
                label_Point_Diskription_Org.Visible = false;

                #endregion

                sqlConnection.Open();

                //Проверка на пустое поле УНП
                if (!string.IsNullOrEmpty(UNP.Text) && !string.IsNullOrWhiteSpace(UNP.Text))
                {   //Проверка УНП на идентичность
                    if (cHECK_Class.Check_UNP(UNP.Text) == true)
                    {
                        ORG.UNP_Org = UNP.Text;
                        label1.Visible = true;
                    }
                    else
                    {
                        label_UNP_Err.Visible = true;
                        return;
                    }
                }
                else
                {
                    label1.Visible = false;
                    label28.Visible = true;
                    return;
                }

                //Проверка на пустое поле Кр. имени
                if (!string.IsNullOrEmpty(short_name.Text) && !string.IsNullOrWhiteSpace(short_name.Text))
                {   // Проверка Кр. имя на идентичность
                    if (cHECK_Class.Check_Short_Name_Org(short_name.Text) == true)
                    {
                        ORG.Short_Name_Org = short_name.Text;
                        label_Short_Name.Visible = true;
                    }
                    else
                    {
                        label_Short_Name.Visible = false;
                        label_ShortName_Err.Visible = true;
                        return;
                    }
                }
                else
                {
                    label_Short_Name.Visible = false;
                    label_TextBox_Err.Visible = true;
                    return;
                }

                //Проверка полного имени на идентичность
                if (!string.IsNullOrEmpty(textBox_Full_Name_Org.Text) && !string.IsNullOrWhiteSpace(textBox_Full_Name_Org.Text))
                {
                    if (cHECK_Class.Check_Full_Name_Org(textBox_Full_Name_Org.Text) == true)
                    {
                        ORG.Full_Name_Org = textBox_Full_Name_Org.Text;
                        label_Full_Name_Org.Visible = true;
                    }
                    else
                    {
                        label_Full_Name_Org.Visible = false;
                        label_Organisatuon_Exists.Visible = true;
                        return;
                    }
                }
                else
                {
                    label_Full_Name_Org.Visible = false;
                    label_Fill_in_the_field.Visible = true;
                    return;
                }

                // Проверка корректности вводимой даты
                if (cHECK_Class.Check_Create_date_Org(maskedTextBox_Create_date_Org.Text) == true)
                {
                    //DateTime dateTime = DateTime.ParseExact(maskedTextBox_Create_date_Org.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None);
                    DateTime dateTime = Convert.ToDateTime(maskedTextBox_Create_date_Org.Text);
                    ORG.Create_date_Org = dateTime;
                    label_Create_date_Org.Visible = true;
                }
                else
                {
                    label_Create_date_Org.Visible = false;
                    label_invalid_date.Visible = true;
                    return;
                }

                //Проверка ввода страны
                if (cHECK_Class.Check_Country(comboBox_Countyr_Org.Text) == true)
                {
                    ORG.Countyr_Org = comboBox_Countyr_Org.Text;

                }
                else
                {
                    label_Country_Org.Visible = false;
                    label_Country_Org_Err.Visible = true;
                    return;
                }

                //Проверка секции
                if (cHECK_Class.Check_Section(comboBox_Section.Text) == true)
                {
                    ORG.Name_Section = comboBox_Section.Text;
                }
                else
                {
                    label_Section.Visible = false;
                    label_Need_Section.Visible = true;
                    return;
                }

                //Проверка страны руководителя
                if (cHECK_Class.Check_Country_Pers(comboBox_Countyr_Pers.Text) == true)
                {
                    ORG.Country_Pers = comboBox_Countyr_Pers.Text;
                    label1_Country_Pers.Visible = true;
                    label_Point_Country_Pers.Visible = false;

                }
                else
                {
                    label1_Country_Pers.Visible = false;
                    label_Point_Country_Pers.Visible = true;
                    return;
                }

                //Проверка данных собственника
                if (!string.IsNullOrEmpty(Name_Owner.Text) && !string.IsNullOrWhiteSpace(Name_Owner.Text))
                {
                    ORG.Owner_Name = Name_Owner.Text;
                    label_Name_Head.Visible = true;
                    Err_label_Name_Head.Visible = false;
                }
                else
                {
                    label_Name_Head.Visible = false;
                    Err_label_Name_Head.Visible = true;
                    return;
                }

                // Проверка данных руководителя
                if (!string.IsNullOrEmpty(TextBox_Name_Head.Text) && !string.IsNullOrWhiteSpace(TextBox_Name_Head.Text))
                {
                    ORG.Head_Name = TextBox_Name_Head.Text;
                    label_Name_Owner.Visible = true;
                    label_Err_label_Name_Owner.Visible = false;
                }
                else
                {
                    label_Name_Owner.Visible = false;
                    label_Err_label_Name_Owner.Visible = true;
                    return;
                }

                if (string.IsNullOrEmpty(textBox_BrokerOpinion.Text) && string.IsNullOrWhiteSpace(textBox_BrokerOpinion.Text))
                {
                    ORG.Broker_Opinion = "нет";
                }
                else
                {
                    ORG.Broker_Opinion = textBox_BrokerOpinion.Text;
                }

                if (string.IsNullOrEmpty(textBox_Section_Head_Opinion.Text) && string.IsNullOrWhiteSpace(textBox_Section_Head_Opinion.Text))
                {
                    ORG.Section_Head_Opinion = "нет";
                }
                else
                {
                    ORG.Section_Head_Opinion = textBox_Section_Head_Opinion.Text;
                }

                if (string.IsNullOrEmpty(textBox_Auditor_Opinion.Text) && string.IsNullOrWhiteSpace(textBox_Auditor_Opinion.Text))
                {
                    ORG.Auditor_Opinion = "нет";
                }
                else
                {
                    ORG.Auditor_Opinion = textBox_Auditor_Opinion.Text;
                }

                if (string.IsNullOrEmpty(lable_Description_Pers.Text) && string.IsNullOrWhiteSpace(lable_Description_Pers.Text))
                {
                    ORG.Description_Pers = "нет";
                }
                else
                {
                    ORG.Description_Pers = lable_Description_Pers.Text;
                }

                if (checkBox10.Checked) { ORG.Prev_Broker_Client = 1; }
                if (!checkBox10.Checked) { ORG.Prev_Broker_Client = 0; }
                if (Trader.Checked) { ORG.Trader = 1; }
                if (!Trader.Checked) { ORG.Trader = 0; }
                if (First_Accreditation.Checked) { ORG.First_Accred = 1; }
                if (!First_Accreditation.Checked) { ORG.First_Accred = 0; }
                if (Second_Accreditation.Checked) { ORG.Second_Accred = 1; }
                if (!Second_Accreditation.Checked) { ORG.Second_Accred = 0; }
                if (checkBox1.Checked) { ORG.Ownership_Org = 1; }
                if (!checkBox1.Checked) { ORG.Ownership_Org = 0; }
                if (Tax_Debt.Checked) { ORG.Tax_Debt = 1; }
                if (!Tax_Debt.Checked) { ORG.Tax_Debt = 0; }
                if (Debts_Enforcement_Documents.Checked) { ORG.Debts_Enforcement_Documents = 1; }
                if (!Debts_Enforcement_Documents.Checked) { ORG.Debts_Enforcement_Documents = 0; }
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

                if (comboBox_Countyr_Org.Text == "Беларусь") { ORG.Resident = 1; }
                if (comboBox_Countyr_Org.Text != "Беларусь") { ORG.Resident = 0; }

                if (Broker_Client.Checked) { ORG.Broker_Client = 1; }
                if (!Broker_Client.Checked) { ORG.Broker_Client = 0; }
                if (Trading_experience.Checked) { ORG.Trading_experience = 1; }
                if (!Trading_experience.Checked) { ORG.Trading_experience = 0; }
                if (Manufacturer.Checked) { ORG.Manufacturer = 1; }
                if (!Manufacturer.Checked) { ORG.Manufacturer = 0; }
                if (Exchenge_Trading_Disorders.Checked) { ORG.Exchenge_Trading_Disorders = 1; }
                if (!Exchenge_Trading_Disorders.Checked) { ORG.Exchenge_Trading_Disorders = 0; }
                if (Negativ_Data.Checked) { ORG.Negativ_Data = 1; }
                if (!Negativ_Data.Checked) { ORG.Negativ_Data = 0; }

                if (Negativ_Owner.Checked) { ORG.Negativ_Data_Pers = 1; }
                if (!Negativ_Owner.Checked) { ORG.Negativ_Data_Pers = 0; }

                if (Reputation.Checked) { ORG.Reputation = 1; }
                if (!Reputation.Checked) { ORG.Reputation = 0; }
                if (Prev_Liquidated.Checked) { ORG.Prev_Liquidated = 1; }
                if (!Prev_Liquidated.Checked) { ORG.Prev_Liquidated = 0; }
                if (Prev_Bankruptcy.Checked) { ORG.Prev_Bankruptcy = 1; }
                if (!Prev_Bankruptcy.Checked) { ORG.Prev_Bankruptcy = 0; }
                if (Prev_State_Debt.Checked) { ORG.Prev_State_Debt = 1; }
                if (!Prev_State_Debt.Checked) { ORG.Prev_State_Debt = 0; }
                if (Prev_Tax_Debt.Checked) { ORG.Prev_Tax_Debt = 1; }
                if (!Prev_Tax_Debt.Checked) { ORG.Prev_Tax_Debt = 0; }
                if (Prev_Execute_Proc.Checked) { ORG.Prev_Execute_Proc = 1; }
                if (!Prev_Execute_Proc.Checked) { ORG.Prev_Execute_Proc = 0; }

                if (checkBox_Forced_Deposite_Small.Checked) { ORG.Forced_Deposite = 1; }
                else
                {
                    if (!checkBox_Forced_Deposite_Large.Checked)
                    {
                        ORG.Forced_Deposite = 0;
                    }

                }

                if (checkBox_Forced_Deposite_Large.Checked) { ORG.Forced_Deposite = 1; }
                else
                {
                    if (!checkBox_Forced_Deposite_Small.Checked)
                    {
                        ORG.Forced_Deposite = 0;

                    }
                }





                if (!string.IsNullOrEmpty(Description_ORG.Text) && !string.IsNullOrWhiteSpace(Description_ORG.Text))
                {
                    label_Discription_Org.Visible = true;
                    label_Point_Diskription_Org.Visible = false;
                    ORG.Description_ORG = Description_ORG.Text;

                    SQL_ADD_Parametrs sQL_ADD_Parametrs = new SQL_ADD_Parametrs();

                    DialogResult dialogResult = MessageBox.Show($"Господин {ORG.Login_User}, Вы действительно правильно заполнили поля?", "Контрольный выстрел!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        sQL_ADD_Parametrs.ADD_ORG_Parametrs(oRG);
                        MessageBox.Show($"Огранизация {ORG.Full_Name_Org} добавлена в ИС 'Контрагент' ");
                        this.Close();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                }
                else
                {
                    label_Discription_Org.Visible = false;
                    label_Point_Diskription_Org.Visible = true;
                    return;
                }
            }


            UNP.Clear();
            short_name.Clear();
            textBox_Full_Name_Org.Clear();
            maskedTextBox_Create_date_Org.Clear();

            comboBox_Countyr_Org.SelectedValue = "(не выбрано)";
            comboBox_Section.SelectedValue = "(не выбрано)";
            checkBox1.Checked = false;
            Tax_Debt.Checked = false;

            Debts_Enforcement_Documents.Checked = false;
            False_Business.Checked = false;
            Special_Risc.Checked = false;
            Execute_Proc.Checked = false;
            Bankruptcy_Proc.Checked = false;
            Liquidation_Proc.Checked = false;
            Resident.Checked = false;
            Broker_Client.Checked = false;
            checkBox10.Checked = false;
            Trading_experience.Checked = false;
            Trader.Checked = false;
            Manufacturer.Checked = false;
            First_Accreditation.Checked = false;
            Second_Accreditation.Checked = false;
            Exchenge_Trading_Disorders.Checked = false;
            Negativ_Data.Checked = false;
            Reputation.Checked = false;
            Prev_Liquidated.Checked = false;
            Prev_Bankruptcy.Checked = false;
            Prev_Execute_Proc.Checked = false;
            Negativ_Owner.Checked = false;
            Prev_Tax_Debt.Checked = false;
            Prev_State_Debt.Checked = false;

            comboBox_Countyr_Pers.SelectedValue = "(не выбрано)";
            Name_Owner.Clear();
            TextBox_Name_Head.Clear();
            lable_Description_Pers.Clear();
            Description_ORG.Clear();
            textBox_BrokerOpinion.Clear();
            textBox_Section_Head_Opinion.Clear();
            textBox_Auditor_Opinion.Clear();
        }

        private void ComboBox_Countyr_Org_SelectedIndexChanged(object sender, EventArgs e)
        {
            progressBar1.Value -= Risc_Level.Get_Country_Risk(oRG.Risk_Country_ORG);
            oRG.Risk_Country_ORG = comboBox_Countyr_Org.Text;
            this.progressBar1.Increment(Risc_Level.Get_Country_Risk(oRG.Risk_Country_ORG));
            Progress_Level.Text = Convert.ToString(progressBar1.Value);
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }

            if (comboBox_Countyr_Org.Text == "Беларусь")
            {
                Resident.Checked = true;
            }

            if (comboBox_Countyr_Org.Text != "Беларусь")
            {
                Resident.Checked = false;
            }

            return;
        }

        private void ComboBox_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            progressBar1.Value -= Risc_Level.Get_Section_Risk(oRG.Risk_Section_ORG);
            oRG.Risk_Section_ORG = comboBox_Section.Text;
            this.progressBar1.Increment(Risc_Level.Get_Section_Risk(oRG.Risk_Section_ORG));
            Progress_Level.Text = Convert.ToString(progressBar1.Value);
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
            return;
        }

        private void MaskedTextBox_Create_date_Org_Leave(object sender, EventArgs e)
        {
            if (cHECK_Class.Check_Create_date_Org(maskedTextBox_Create_date_Org.Text) == true)
            {
                // DateTime Create_date_Org = DateTime.ParseExact(maskedTextBox_Create_date_Org.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None);
                DateTime Create_date_Org = Convert.ToDateTime(maskedTextBox_Create_date_Org.Text);
                DateTime dateTime_NOW = DateTime.Today;

                var age_Year = (dateTime_NOW - Create_date_Org).TotalDays / 365;
                var old_Age_Year = (dateTime_NOW - ORG.Create_date_Org).TotalDays / 365;

                var age_Mouns = 0;
                if (dateTime_NOW.Month < Create_date_Org.Month)
                {
                    age_Mouns = dateTime_NOW.Month;
                }
                else
                {
                    age_Mouns = dateTime_NOW.Month - Create_date_Org.Month;
                }

                var age_Day = 0;
                if (dateTime_NOW.Day < Create_date_Org.Day)
                {
                    age_Day = dateTime_NOW.Day;
                }
                else
                {
                    age_Day = dateTime_NOW.Day - Create_date_Org.Day;
                }

                label_Create_date_Org.Visible = false;
                Year_Org.Visible = true;
                Month_Org.Visible = true;
                Day_Org.Visible = true;
                label_invalid_date.Visible = false;
                Age_Org_1.Text = $" {Math.Truncate(age_Year)}              {age_Mouns}              {age_Day}";
                Age_Org_1.Visible = true;
                label_Create_date_Org.Visible = true;

                if (old_Age_Year < 1)
                {
                    progressBar1.Value -= 3;
                }
                ORG.Create_date_Org = Create_date_Org;

                if (age_Year < 1)
                {
                    this.progressBar1.Increment(3);
                    Progress_Level.Text = Convert.ToString(progressBar1.Value);
                }

                if (progressBar1.Value > oRG.Sbor_Sdelka)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                    Progress_Level.Text = Convert.ToString(progressBar1.Value);
                }
                else
                {
                    label_Large.Visible = false;
                    label_Small.Visible = true;
                    Progress_Level.Text = Convert.ToString(progressBar1.Value);
                }
                return;
            }
            else
            {
                return;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.progressBar1.Increment(-ORG.Ownership_Org);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!checkBox1.Checked)
            {
                this.progressBar1.Increment(ORG.Ownership_Org);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {

                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Tax_Debt_CheckedChanged(object sender, EventArgs e)
        {
            if (Tax_Debt.Checked)
            {
                this.progressBar1.Increment(ORG.Tax_Debt);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Tax_Debt.Checked)
            {
                this.progressBar1.Increment(-ORG.Tax_Debt);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Debts_Enforcement_Documents_CheckedChanged(object sender, EventArgs e)
        {
            if (Debts_Enforcement_Documents.Checked)
            {
                this.progressBar1.Increment(ORG.Debts_Enforcement_Documents);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Debts_Enforcement_Documents.Checked)
            {
                this.progressBar1.Increment(-ORG.Debts_Enforcement_Documents);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void False_Business_CheckedChanged(object sender, EventArgs e)
        {
            if (False_Business.Checked)
            {
                this.progressBar1.Increment(ORG.False_Business);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!False_Business.Checked)
            {
                this.progressBar1.Increment(-ORG.False_Business);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Special_Risc_CheckedChanged(object sender, EventArgs e)
        {
            if (Special_Risc.Checked)
            {
                this.progressBar1.Increment(ORG.Special_Risc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Special_Risc.Checked)
            {
                this.progressBar1.Increment(-ORG.Special_Risc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Execute_Proc_CheckedChanged(object sender, EventArgs e)
        {
            if (Execute_Proc.Checked)
            {
                this.progressBar1.Increment(ORG.Execute_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Execute_Proc.Checked)
            {
                this.progressBar1.Increment(-ORG.Execute_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Bankruptcy_Proc_CheckedChanged(object sender, EventArgs e)
        {
            if (Bankruptcy_Proc.Checked)
            {
                this.progressBar1.Increment(ORG.Bankruptcy_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Bankruptcy_Proc.Checked)
            {
                this.progressBar1.Increment(-ORG.Bankruptcy_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Liquidation_Proc_CheckedChanged(object sender, EventArgs e)
        {
            if (Liquidation_Proc.Checked)
            {
                this.progressBar1.Increment(ORG.Liquidation_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Liquidation_Proc.Checked)
            {
                this.progressBar1.Increment(-ORG.Liquidation_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Resident_CheckedChanged(object sender, EventArgs e)
        {
            if (Resident.Checked)
            {
                this.progressBar1.Increment(-ORG.Resident);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Resident.Checked)
            {
                this.progressBar1.Increment(ORG.Resident);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Broker_Client_CheckedChanged(object sender, EventArgs e)
        {
            if (Broker_Client.Checked)
            {
                this.progressBar1.Increment(-ORG.Broker_Client);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
                Trader.Checked = false;
                this.textBox_BrokerOpinion.Enabled = true;
            }
            if (!Broker_Client.Checked)
            {
                this.progressBar1.Increment(ORG.Broker_Client);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
                Trader.Checked = true;
                this.textBox_BrokerOpinion.Enabled = false;
                this.textBox_BrokerOpinion.Clear();
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Trading_experience_CheckedChanged(object sender, EventArgs e)
        {
            if (Trading_experience.Checked)
            {
                this.progressBar1.Increment(-ORG.Trading_experience);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Trading_experience.Checked)
            {
                this.progressBar1.Increment(ORG.Trading_experience);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }


        private void Manufacturer_CheckedChanged(object sender, EventArgs e)
        {
            if (Manufacturer.Checked)
            {
                this.progressBar1.Increment(-ORG.Manufacturer);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Manufacturer.Checked)
            {
                this.progressBar1.Increment(ORG.Manufacturer);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }


        private void Exchenge_Trading_Disorders_CheckedChanged(object sender, EventArgs e)
        {
            if (Exchenge_Trading_Disorders.Checked)
            {
                this.progressBar1.Increment(ORG.Exchenge_Trading_Disorders);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Exchenge_Trading_Disorders.Checked)
            {
                this.progressBar1.Increment(-ORG.Exchenge_Trading_Disorders);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Negativ_Data_CheckedChanged(object sender, EventArgs e)
        {
            if (Negativ_Data.Checked)
            {
                this.progressBar1.Increment(ORG.Negativ_Data);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Negativ_Data.Checked)
            {
                this.progressBar1.Increment(-ORG.Negativ_Data);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Reputation_CheckedChanged(object sender, EventArgs e)
        {
            if (Reputation.Checked)
            {
                this.progressBar1.Increment(-ORG.Reputation);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Reputation.Checked)
            {
                this.progressBar1.Increment(ORG.Reputation);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Prev_Liquidated_CheckedChanged(object sender, EventArgs e)
        {
            if (Prev_Liquidated.Checked)
            {
                this.progressBar1.Increment(ORG.Prev_Liquidated);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Prev_Liquidated.Checked)
            {
                this.progressBar1.Increment(-ORG.Prev_Liquidated);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Prev_Bankruptcy_CheckedChanged(object sender, EventArgs e)
        {
            if (Prev_Bankruptcy.Checked)
            {
                this.progressBar1.Increment(ORG.Prev_Bankruptcy);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Prev_Bankruptcy.Checked)
            {
                this.progressBar1.Increment(-ORG.Prev_Bankruptcy);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Prev_Execute_Proc_CheckedChanged(object sender, EventArgs e)
        {
            if (Prev_Execute_Proc.Checked)
            {
                this.progressBar1.Increment(ORG.Prev_Execute_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Prev_Execute_Proc.Checked)
            {
                this.progressBar1.Increment(-ORG.Prev_Execute_Proc);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }


        private void Negativ_Owner_CheckedChanged(object sender, EventArgs e)
        {
            if (Negativ_Owner.Checked)
            {
                this.progressBar1.Increment(ORG.Negativ_Data);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Negativ_Owner.Checked)
            {
                this.progressBar1.Increment(-ORG.Negativ_Data);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Prev_Tax_Debt_CheckedChanged(object sender, EventArgs e)
        {
            if (Prev_Tax_Debt.Checked)
            {
                this.progressBar1.Increment(ORG.Prev_Tax_Debt);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Prev_Tax_Debt.Checked)
            {
                this.progressBar1.Increment(-ORG.Prev_Tax_Debt);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void Prev_State_Debt_CheckedChanged(object sender, EventArgs e)
        {
            if (Prev_State_Debt.Checked)
            {
                this.progressBar1.Increment(ORG.Prev_State_Debt);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (!Prev_State_Debt.Checked)
            {
                this.progressBar1.Increment(-ORG.Prev_State_Debt);
                Progress_Level.Text = Convert.ToString(progressBar1.Value);
            }
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
        }

        private void ComboBox_Country_Pers(object sender, EventArgs e)
        {
            progressBar1.Value -= Risc_Level.Get_Country_Risk(oRG.Risk_Country_Pers);
            oRG.Risk_Country_Pers = comboBox_Countyr_Pers.Text;
            this.progressBar1.Increment(Risc_Level.Get_Country_Risk(oRG.Risk_Country_Pers));
            Progress_Level.Text = Convert.ToString(progressBar1.Value);
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
            return;
        }

        private void ComboBox_Countyr_Pers_SelectedIndexChanged(object sender, EventArgs e)
        {
            progressBar1.Value -= Risc_Level.Get_Country_Risk(oRG.Risk_Country_Pers);
            oRG.Risk_Country_Pers = comboBox_Countyr_Pers.Text;
            this.progressBar1.Increment(Risc_Level.Get_Country_Risk(oRG.Risk_Country_Pers));
            Progress_Level.Text = Convert.ToString(progressBar1.Value);
            if (progressBar1.Value >= oRG.Sbor_Sdelka)
            {
                if (checkBox_Forced_Deposite_Small.Checked == false)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
            else if (checkBox_Forced_Deposite_Large.Checked == false)
            {
                label_Large.Visible = false;
                label_Small.Visible = true;
            }
            return;
        }

        private void New_Organisation_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Main_Form main_Form = new Main_Form();
            //main_Form.Enabled = true;

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            UNP.Clear();
            short_name.Clear();
            textBox_Full_Name_Org.Clear();
            maskedTextBox_Create_date_Org.Clear();
            comboBox_Countyr_Org.SelectedValue = "(не выбрано)";
            comboBox_Section.SelectedValue = "(не выбрано)";
            checkBox1.Checked = false;
            Tax_Debt.Checked = false;
            Debts_Enforcement_Documents.Checked = false;
            False_Business.Checked = false;
            Special_Risc.Checked = false;
            Execute_Proc.Checked = false;
            Bankruptcy_Proc.Checked = false;
            Liquidation_Proc.Checked = false;
            Resident.Checked = false;
            Broker_Client.Checked = false;
            checkBox10.Checked = false;
            Trading_experience.Checked = false;
            Trader.Checked = false;
            Manufacturer.Checked = false;
            First_Accreditation.Checked = false;
            Second_Accreditation.Checked = false;
            Exchenge_Trading_Disorders.Checked = false;
            Negativ_Data.Checked = false;
            Reputation.Checked = false;
            Prev_Liquidated.Checked = false;
            Prev_Bankruptcy.Checked = false;
            Prev_Execute_Proc.Checked = false;
            Negativ_Owner.Checked = false;
            Prev_Tax_Debt.Checked = false;
            Prev_State_Debt.Checked = false;
            comboBox_Countyr_Pers.SelectedValue = "(не выбрано)";
            Name_Owner.Clear();
            TextBox_Name_Head.Clear();
            lable_Description_Pers.Clear();
            Description_ORG.Clear();
            textBox_BrokerOpinion.Clear();
            textBox_Section_Head_Opinion.Clear();
            textBox_Auditor_Opinion.Clear();
            checkBox_Forced_Deposite_Small.Checked = false;
            checkBox_Forced_Deposite_Large.Checked = false;
            label_Large.Visible = true;
            label_Small.Visible = false;
        }

        private void CheckBox_Forced_Deposite_Small_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Forced_Deposite_Small.Checked)
            {
                checkBox_Forced_Deposite_Large.Enabled = false;
                label_Small.Visible = true;
                label_Large.Visible = false;
            }
            else
            {
                checkBox_Forced_Deposite_Large.Enabled = true;
                if (progressBar1.Value >= oRG.Sbor_Sdelka)
                {
                    label_Small.Visible = false;
                    label_Large.Visible = true;
                }
            }
        }

        private void CheckBox_Forced_Deposite_Large_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Forced_Deposite_Large.Checked)
            {
                checkBox_Forced_Deposite_Small.Enabled = false;
                label_Large.Visible = true;
                label_Small.Visible = false;
            }
            else
            {
                checkBox_Forced_Deposite_Small.Enabled = true;
                if (progressBar1.Value <= oRG.Sbor_Sdelka)
                {
                    label_Large.Visible = false;
                    label_Small.Visible = true;
                }
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

        private void ComboBox_Countyr_Pers_Leave(object sender, EventArgs e)
        {
            comboBox_Countyr_Pers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void CheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (Second_Accreditation.Checked == true)
            {
                First_Accreditation.Checked = false;
            }
            if (Second_Accreditation.Checked == false)
            {
                First_Accreditation.Checked = true;
            }
        }

        [Obsolete]
        public void Button2_Click(object sender, EventArgs e)
        {
            string ORA_UNP = UNP.Text;
                       

            // "191372734";
            if (!string.IsNullOrEmpty(UNP.Text) && !string.IsNullOrWhiteSpace(UNP.Text))
            {
                label28.Visible = false;
                label1.Visible = true;

                string sql_Check_UNP = "SELECT COUNT(*) FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP =" + $"'{ ORA_UNP}'";
                string sql = "SELECT mns_constitutor.FULL_NAME FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP =" + $"{ ORA_UNP}";


                using (OracleConnection ORA_con = new OracleConnection(ConnectionStringOracle))
                {
                    ORA_con.Open();
                    OracleCommand com_Check_UNP = new OracleCommand(sql_Check_UNP, ORA_con);
                    if ((Convert.ToInt32((com_Check_UNP.ExecuteOracleScalar()).ToString()) != 1))
                    {
                        MessageBox.Show("Организации с таким УНП не существует!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    OracleCommand ORA_command = new OracleCommand(sql, ORA_con);
                    OracleDataReader reader = ORA_command.ExecuteReader();
                    ORG.ORA_FULL_NAME_PERS = null;
                    while (reader.Read())
                    {
                        ORG.ORA_FULL_NAME_PERS = $"{ORG.ORA_FULL_NAME_PERS}" + $"{ Convert.ToString(reader.GetString(0))}; ";
                    }
                    Name_Owner.Text = ORG.ORA_FULL_NAME_PERS;

                    string sql_ORA_FULL_NAME = "SELECT mns_subject.FULL_NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
                    OracleCommand com_ORA_FULL_NAME = new OracleCommand(sql_ORA_FULL_NAME, ORA_con);
                    ORG.ORA_FULL_NAME_ORG = com_ORA_FULL_NAME.ExecuteOracleScalar().ToString();
                    textBox_Full_Name_Org.Text = ORG.ORA_FULL_NAME_ORG;


                    string sql_ORA_SHORT_NAME = "SELECT mns_subject.NAME FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
                    OracleCommand com_ORA_SHORT_NAME = new OracleCommand(sql_ORA_SHORT_NAME, ORA_con);
                    ORG.ORA_SHORT_NAME = com_ORA_SHORT_NAME.ExecuteOracleScalar().ToString();
                    short_name.Text = ORG.ORA_SHORT_NAME;


                    string sql_ORA_FIO_CHIEF = "SELECT mns_subject.FIO_CHIEF FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
                    OracleCommand com_ORA_FIO_CHIEF = new OracleCommand(sql_ORA_FIO_CHIEF, ORA_con);
                    ORG.ORA_FIO_CHIEF = com_ORA_FIO_CHIEF.ExecuteOracleScalar().ToString();
                    TextBox_Name_Head.Text = ORG.ORA_FIO_CHIEF;


                    string sql_ORA_RESIDENT = "SELECT mns_constitutor.RESIDENT FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
                    OracleCommand com_ORA_RESIDENT = new OracleCommand(sql_ORA_RESIDENT, ORA_con);
                    ORG.ORA_RESIDENT = Convert.ToInt32(com_ORA_RESIDENT.ExecuteOracleScalar().ToString());

                    if (ORG.ORA_RESIDENT ==1)
                    {
                        comboBox_Countyr_Pers.Text = "Беларусь";
                    }
                    else
                    {
                        string sql_NCOUNTRY_ID = "SELECT mns_constitutor.NCOUNTRY_ID FROM BUTB_SEC.mns_constitutor join BUTB_SEC.mns_subject on mns_constitutor.MNS_SUBJECT_ID = mns_subject.ID WHERE mns_subject.UNP = " + $"{ ORA_UNP}";

                        OracleCommand com_ORA_NCOUNTRY_ID = new OracleCommand(sql_NCOUNTRY_ID, ORA_con);
                        ORG.ORA_NCOUNTRY_ID = com_ORA_NCOUNTRY_ID.ExecuteOracleScalar().ToString();
                        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                        {
                            sqlConnection.Open();
                            SqlCommand Country_Select = new SqlCommand("Country_Select", sqlConnection);
                            Country_Select.CommandType = CommandType.StoredProcedure;
                            Country_Select.Parameters.AddWithValue("Country_Code", ORG.ORA_NCOUNTRY_ID);
                            comboBox_Countyr_Pers.Text = Country_Select.ExecuteScalar().ToString();
                            sqlConnection.Close();
                        }
                    }

                    string sql_ORA_NREGO_ID = "SELECT COUNT( mns_subject.NREGO_ID) FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
                    OracleCommand com_ORA_NREGO_ID = new OracleCommand(sql_ORA_NREGO_ID, ORA_con);
                    ORG.ORA_NREGO_ID = com_ORA_NREGO_ID.ExecuteOracleScalar().ToString();
                    if (Convert.ToUInt32(ORG.ORA_NREGO_ID) == 1)
                    {
                        comboBox_Countyr_Org.Text = "Беларусь";
                    }

                    string sql_OWNERSHIP_FORM_ID = "SELECT mns_subject.OWNERSHIP_FORM_ID FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";
                    OracleCommand ORA_command_OWNERSHIP_FORM_ID = new OracleCommand(sql_OWNERSHIP_FORM_ID, ORA_con);
                    OracleDataReader reader_OWNERSHIP_FORM_ID = ORA_command_OWNERSHIP_FORM_ID.ExecuteReader();
                    ORG.ORA_FULL_NAME_PERS = null;
                    while (reader_OWNERSHIP_FORM_ID.Read())
                    {
                        ORG.ORA_OWNERSHIP_FORM_ID = Convert.ToString(reader_OWNERSHIP_FORM_ID.GetString(0)); 
                    }
                    if ((Convert.ToUInt32(ORG.ORA_OWNERSHIP_FORM_ID)) == 100 || (Convert.ToUInt32(ORG.ORA_OWNERSHIP_FORM_ID)) == 110 || (Convert.ToUInt32(ORG.ORA_OWNERSHIP_FORM_ID)) == 111 || (Convert.ToUInt32(ORG.ORA_OWNERSHIP_FORM_ID)) == 112 || (Convert.ToUInt32(ORG.ORA_OWNERSHIP_FORM_ID)) == 120 || (Convert.ToUInt32(ORG.ORA_OWNERSHIP_FORM_ID)) == 122 || (Convert.ToUInt32(ORG.ORA_OWNERSHIP_FORM_ID)) ==121)
                    {
                        checkBox1.Checked = true;
                    }

                    string sql_ORA_REG_DATE = "SELECT mns_subject.REG_DATE FROM BUTB_SEC.mns_subject WHERE mns_subject.UNP = " + $"{ ORA_UNP}";

                    OracleCommand com_ORA_REG_DATE = new OracleCommand(sql_ORA_REG_DATE, ORA_con);
                    ORG.ORA_NREGO_ID = com_ORA_REG_DATE.ExecuteOracleScalar().ToString();
                    maskedTextBox_Create_date_Org.Text = ORG.ORA_NREGO_ID;
                }

            }
            else
            {
                label1.Visible = false;
                label28.Visible = true;
                return;
            }


        }
    }
}
