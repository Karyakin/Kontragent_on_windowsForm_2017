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

    public partial class General_Form : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        ORG oRG = new ORG();
        CHECK_class cHECK_Class = new CHECK_class();



        public General_Form()
        {
            InitializeComponent();
        }

        public void General_Form_Load(object sender, EventArgs e)
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
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
               
                if (checkBox10.Checked){ORG.Prev_Broker_Client                           = 1;}  if (!checkBox10.Checked){ORG.Prev_Broker_Client             = 0;}
                if (checkBox12.Checked){ORG.Trader                                       = 1;}  if (!checkBox12.Checked){ORG.Trader                         = 0;}
                if (checkBox14.Checked){ORG.First_Accred                                 = 1;}  if (!checkBox14.Checked){ORG.First_Accred                   = 0;}
                if (checkBox15.Checked){ORG.Second_Accred                                = 1;}  if (!checkBox15.Checked){ORG.Second_Accred                  = 0;}
                if (checkBox1.Checked){ORG.Ownership_Org                                 = 1;}  if (!checkBox1.Checked){ORG.Ownership_Org                   = 0;}
                if (Tax_Debt.Checked){ORG.Tax_Debt                                       = 1;}  if (!Tax_Debt.Checked){ORG.Tax_Debt                         = 0;}
                if (Debts_Enforcement_Documents.Checked){ORG.Debts_Enforcement_Documents = 1;}  if (!Debts_Enforcement_Documents.Checked){ORG.Debts_Enforcement_Documents = 0;}
                if (Debts_Enforcement_Documents.Checked){ORG.Debts_Enforcement_Documents = 1;}  if (!Debts_Enforcement_Documents.Checked){ORG.Debts_Enforcement_Documents = 0;}
                if (False_Business.Checked) { ORG.False_Business                         = 1;}  if (!False_Business.Checked) { ORG.False_Business           = 0; }
                if (Special_Risc.Checked) { ORG.Special_Risc                             = 1;}  if (!Special_Risc.Checked) { ORG.Special_Risc               = 0; }
                if (Execute_Proc.Checked) { ORG.Execute_Proc                             = 1;}  if (!Execute_Proc.Checked) { ORG.Execute_Proc               = 0; }
                if (Bankruptcy_Proc.Checked) { ORG.Bankruptcy_Proc                       = 1;}  if (!Bankruptcy_Proc.Checked) { ORG.Bankruptcy_Proc         = 0; }
                if (Liquidation_Proc.Checked) { ORG.Liquidation_Proc                     = 1;}  if (!Liquidation_Proc.Checked) { ORG.Liquidation_Proc       = 0; }
                if (Resident.Checked) { ORG.Resident                                     = 1;}  if (!Resident.Checked) { ORG.Resident                       = 0; }
                if (Broker_Client.Checked) { ORG.Broker_Client                           = 1;}  if (!Broker_Client.Checked) { ORG.Broker_Client             = 0; }
                if (Trading_experience.Checked) { ORG.Trading_experience                 = 1;}  if (!Trading_experience.Checked) { ORG.Trading_experience   = 0; }
                if (Manufacturer.Checked) { ORG.Manufacturer                             = 1;}  if (!Manufacturer.Checked) { ORG.Manufacturer               = 0; }
                if (Exchenge_Trading_Disorders.Checked) { ORG.Exchenge_Trading_Disorders = 1;}  if (!Exchenge_Trading_Disorders.Checked) { ORG.Exchenge_Trading_Disorders = 0; }
                if (Negativ_Data.Checked) { ORG.Negativ_Data                             = 1;}  if (!Negativ_Data.Checked) { ORG.Negativ_Data               = 0; }

                if (Negativ_Owner.Checked) { ORG.Negativ_Data_Pers                       = 1;}  if (!Negativ_Owner.Checked) { ORG.Negativ_Data_Pers         = 0; }



                if (Reputation.Checked) { ORG.Reputation                                 = 1;}  if (!Reputation.Checked) { ORG.Reputation                   = 0; }
                if (Prev_Liquidated.Checked) { ORG.Prev_Liquidated                       = 1;}  if (!Prev_Liquidated.Checked) { ORG.Prev_Liquidated         = 0; }
                if (Prev_Bankruptcy.Checked) { ORG.Prev_Bankruptcy                       = 1;}  if (!Prev_Bankruptcy.Checked) { ORG.Prev_Bankruptcy         = 0; }
                if (Prev_State_Debt.Checked) { ORG.Prev_State_Debt                       = 1;}  if (!Prev_State_Debt.Checked) { ORG.Prev_State_Debt         = 0; }
                if (Prev_Tax_Debt.Checked) { ORG.Prev_Tax_Debt                           = 1;}  if (!Prev_Tax_Debt.Checked) { ORG.Prev_Tax_Debt             = 0; }
                if (Prev_Execute_Proc.Checked) { ORG.Prev_Execute_Proc                   = 1;}  if (!Prev_Execute_Proc.Checked) { ORG.Prev_Execute_Proc     = 0; }


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
            checkBox12.Checked = false;
            Manufacturer.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
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



            progressBar1.Value = 16;

            Progress_Level.Text = Convert.ToString(progressBar1.Value);











        }

        private void ComboBox_Countyr_Org_SelectedIndexChanged(object sender, EventArgs e)//при выборе страны метод обращается в класс progressBar использует метод получения риска страны и возвращенным значением передаем его в инкремент прогресс бара
        {
            progressBar1.Value -= Risc_Level.Get_Country_Risk(oRG.Risk_Country_ORG);
            oRG.Risk_Country_ORG = comboBox_Countyr_Org.Text;
            this.progressBar1.Increment(Risc_Level.Get_Country_Risk(oRG.Risk_Country_ORG));
            Progress_Level.Text = Convert.ToString(progressBar1.Value);
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
            }
            return;
        }

        private void ComboBox_Section_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            progressBar1.Value -= Risc_Level.Get_Section_Risk(oRG.Risk_Section_ORG);
            oRG.Risk_Section_ORG = comboBox_Section.Text;
            this.progressBar1.Increment(Risc_Level.Get_Section_Risk(oRG.Risk_Section_ORG));
            Progress_Level.Text = Convert.ToString(progressBar1.Value);
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
               label22.Visible = false;
               label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
            }
            return;
        }

        public void MaskedTextBox_Create_date_Org_Leave_1(object sender, EventArgs e)
        {
            if (cHECK_Class.Check_Create_date_Org(maskedTextBox_Create_date_Org.Text) == true)
            {
              //  DateTime Create_date_Org = DateTime.ParseExact(maskedTextBox_Create_date_Org.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None);
                DateTime Create_date_Org = Convert.ToDateTime(maskedTextBox_Create_date_Org.Text);
                DateTime dateTime_NOW = DateTime.Today;

                var age_Year = (dateTime_NOW - Create_date_Org).TotalDays/365;
                var old_Age_Year = (dateTime_NOW - ORG.Create_date_Org).TotalDays/365;
                               
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
                Age_Org_1.Text = $" {Math.Truncate( age_Year)}              {age_Mouns}              {age_Day}";
                Age_Org_1.Visible = true;
                label_Create_date_Org.Visible = true;

                if (old_Age_Year<1)
                {
                    progressBar1.Value -= 3;
                }
               ORG.Create_date_Org = Create_date_Org;

                if (age_Year < 1)//  метод глючит. Если постоянно выставлять значение меньше года то постоянно минусует
                {
                    this.progressBar1.Increment(3);
                    Progress_Level.Text = Convert.ToString(progressBar1.Value);
                }
                
                if (progressBar1.Value > oRG.Sbor_Sdelka)
                {
                    label22.Visible = false;
                    label23.Visible = true;
                    Progress_Level.Text = Convert.ToString(progressBar1.Value);
                }
                else
                {
                    label23.Visible = false;
                    label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
            }
        }

        private void Broker_Client_CheckedChanged(object sender, EventArgs e)
        {
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
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
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
            }
        }

        private void ComboBox_Country_Pers(object sender, EventArgs e)
        {
            progressBar1.Value -= Risc_Level.Get_Country_Risk(oRG.Risk_Country_Pers);
            oRG.Risk_Country_Pers = comboBox_Countyr_Pers.Text;
            this.progressBar1.Increment(Risc_Level.Get_Country_Risk(oRG.Risk_Country_Pers));
            Progress_Level.Text = Convert.ToString(progressBar1.Value);
            if (progressBar1.Value > oRG.Sbor_Sdelka)
            {
                label22.Visible = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label22.Visible = true;
            }
            return;
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

            ORG_SELECT.Owner_Name = textBox_Owner_Name.Text;
            ORG_SELECT.Head_Name = textBox_Head_Name.Text;


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {             
                sqlConnection.Open();
                SqlCommand general_SELECT = new SqlCommand("General_SELECT", sqlConnection);
                general_SELECT.CommandType = CommandType.StoredProcedure;




                if (string.IsNullOrEmpty(textBox_UNP_Org_SELECT.Text) && string.IsNullOrWhiteSpace(textBox_UNP_Org_SELECT.Text)){general_SELECT.Parameters.AddWithValue("UNP_Org", null);}
                else{general_SELECT.Parameters.AddWithValue("UNP_Org", ORG_SELECT.UNP_Org);}

                if (string.IsNullOrEmpty(textBox_Full_Name_Org_SELECT.Text) && string.IsNullOrWhiteSpace(textBox_Full_Name_Org_SELECT.Text)){general_SELECT.Parameters.AddWithValue("Full_Name_Org", null );}
                else{general_SELECT.Parameters.AddWithValue("Full_Name_Org", ORG_SELECT.Full_Name_Org);}

                if (string.IsNullOrEmpty(textBox_Short_Name_Org_SELECT.Text) && string.IsNullOrWhiteSpace(textBox_Short_Name_Org_SELECT.Text)){general_SELECT.Parameters.AddWithValue("Short_Name_Org", null);}
                else{general_SELECT.Parameters.AddWithValue("Short_Name_Org", ORG_SELECT.Short_Name_Org);}

                if (comboBox_Countyr_Org_SELECT.Text == "(не выбрано)"){general_SELECT.Parameters.AddWithValue("Name_Country", null);}
                else{general_SELECT.Parameters.AddWithValue("Name_Country", ORG_SELECT.Countyr_Org);}
               
                if (comboBox_Name_Section.Text == "(не выбрано)"){general_SELECT.Parameters.AddWithValue("Name_Section", null);}
                else{general_SELECT.Parameters.AddWithValue("Name_Section", ORG_SELECT.Name_Section);}

                general_SELECT.Parameters.AddWithValue("Create_date_Org_START", ORG_SELECT.Create_date_Org_START);
                general_SELECT.Parameters.AddWithValue("Create_date_Org_FINAL", ORG_SELECT.Create_date_Org_FINAL);
                
                if (comboBox_SELECT_Country_Pers.Text == "(не выбрано)"){general_SELECT.Parameters.AddWithValue("Country_Pers", null);}
                else{general_SELECT.Parameters.AddWithValue("Country_Pers", ORG_SELECT.Country_Pers);}

                if (string.IsNullOrEmpty(textBox_Owner_Name.Text) && string.IsNullOrWhiteSpace(textBox_Owner_Name.Text)){general_SELECT.Parameters.AddWithValue("Owner_Name", null);}
                else{general_SELECT.Parameters.AddWithValue("Owner_Name", ORG_SELECT.Owner_Name);}

                if (string.IsNullOrEmpty(textBox_Head_Name.Text) && string.IsNullOrWhiteSpace(textBox_Head_Name.Text)){general_SELECT.Parameters.AddWithValue("Head_Name", null);}
                else{general_SELECT.Parameters.AddWithValue("Head_Name", ORG_SELECT.Head_Name);}

                #region Чекбоксы для SELECT

                if (checkBox_Ownership_Org.Checked){general_SELECT.Parameters.AddWithValue("Ownership_Org", 1);}
                else{general_SELECT.Parameters.AddWithValue("Ownership_Org", null);}//Госпредприятие

                if (checkBox_Tax_Debt.Checked){general_SELECT.Parameters.AddWithValue("Tax_Debt", 1);}
                else{general_SELECT.Parameters.AddWithValue("Tax_Debt", null);}//Задолженности по налогам

                if (checkBox_Debts_Enforcement_Documents.Checked){general_SELECT.Parameters.AddWithValue("Debts_Enforcement_Documents", 1);}
                else{general_SELECT.Parameters.AddWithValue("Debts_Enforcement_Documents", null);}//Задолженности по исполнительным документам

                if (checkBox_False_Business.Checked){general_SELECT.Parameters.AddWithValue("False_Business", 1);}
                else{general_SELECT.Parameters.AddWithValue("False_Business", null);}//Лжепредпринимательство

                if (checkBox_Special_Risc.Checked){general_SELECT.Parameters.AddWithValue("Special_Risc", 1);}
                else{general_SELECT.Parameters.AddWithValue("Special_Risc", null);}//Особый риск

                if (checkBox_Execute_Proc.Checked){general_SELECT.Parameters.AddWithValue("Execute_Proc", 1);}
                else{general_SELECT.Parameters.AddWithValue("Execute_Proc", null);}//Исполнительное производство

                if (checkBox_Bankruptcy_Proc.Checked){general_SELECT.Parameters.AddWithValue("Bankruptcy_Proc", 1);}
                else{general_SELECT.Parameters.AddWithValue("Bankruptcy_Proc", null);}//Банкротство

                if (checkBox_Liquidation_Proc.Checked){general_SELECT.Parameters.AddWithValue("Liquidation_Proc", 1);}
                else{general_SELECT.Parameters.AddWithValue("Liquidation_Proc", null);}//Процесс ликвидации

                if (checkBox_Resident.Checked){general_SELECT.Parameters.AddWithValue("Resident", 1);}
                else{general_SELECT.Parameters.AddWithValue("Resident", null);}//Резидент

                if (checkBox_Broker_Client.Checked){general_SELECT.Parameters.AddWithValue("Broker_Client", 1);}
                else{general_SELECT.Parameters.AddWithValue("Broker_Client", null);}//Клиент брокера

                if (checkBox_Prev_Broker_Client.Checked){general_SELECT.Parameters.AddWithValue("Prev_Broker_Client", 1);}
                else{general_SELECT.Parameters.AddWithValue("Prev_Broker_Client", null);}//Клиент брокера

                if (checkBox_Trading_experience.Checked) { general_SELECT.Parameters.AddWithValue("Trading_experience", 1); }
                else {general_SELECT.Parameters.AddWithValue("Trading_experience", null); }//Опыт торгов

                if (checkBox_Trader.Checked) {general_SELECT.Parameters.AddWithValue("Trader", 1); }
                else { general_SELECT.Parameters.AddWithValue("Trader", null); }//Трейдер
                
                if (checkBox_Manufacturer.Checked) {general_SELECT.Parameters.AddWithValue("Manufacturer", 1); }
                else { general_SELECT.Parameters.AddWithValue("Manufacturer", null); }//Производитель

                if (checkBox_First_Accred.Checked) {general_SELECT.Parameters.AddWithValue("First_Accred", 1); }
                else { general_SELECT.Parameters.AddWithValue("First_Accred", null); }//Первичная аккредитация

                if (checkBox_Second_Accred.Checked) {general_SELECT.Parameters.AddWithValue("Second_Accred", 1); }
                else { general_SELECT.Parameters.AddWithValue("Second_Accred", null); }//Первичная аккредитация

                if (checkBox_Exchenge_Trading_Disorders.Checked) {general_SELECT.Parameters.AddWithValue("Exchenge_Trading_Disorders", 1); }
                else { general_SELECT.Parameters.AddWithValue("Exchenge_Trading_Disorders", null); }//Нарушение правил торгов

                if (checkBox_Negativ_Data.Checked) { general_SELECT.Parameters.AddWithValue("Negativ_Data", 1); }
                else { general_SELECT.Parameters.AddWithValue("Negativ_Data", null); }//Негатив

                if (checkBox_Reputation.Checked) { general_SELECT.Parameters.AddWithValue("Reputation", 1); }
                else { general_SELECT.Parameters.AddWithValue("Reputation", null); }//Репутация

                #endregion

                SqlDataReader reader_SELECT = null;
                reader_SELECT = general_SELECT.ExecuteReader();

          

                listView1.Clear();

                listView1.GridLines = true;
                
                listView1.FullRowSelect = true;
                listView1.View = View.Details;

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


                while (reader_SELECT.Read())
                {
                    List<string> qqq = new List<string>();

                    qqq.Add(Convert.ToString(reader_SELECT["UNP_Org"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Full_Name_Org"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Short_Name_Org"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Name_Country"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Name_Section"]));
                    qqq.Add(Convert.ToString(reader_SELECT["Create_date_Org"]));
                  

                    if (checkBox_Description_ORG.Checked){qqq.Add(Convert.ToString(reader_SELECT["Description_Org"]));}
                    if (checkBox_Description_Pers.Checked){qqq.Add(Convert.ToString(reader_SELECT["Description_Pers"]));}
                    if (checkBox_Auditor_Opinion.Checked){qqq.Add(Convert.ToString(reader_SELECT["Auditor_Opinion"]));}
                    if (checkBox_Section_Head_Opinion.Checked){qqq.Add(Convert.ToString(reader_SELECT["Section_Head_Opinion"]));}
                    if (checkBox_textBox_BrokerOpinion.Checked){qqq.Add(Convert.ToString(reader_SELECT["Broker_Opinion"]));}
                    if (checkBox3.Checked){qqq.Add(Convert.ToString(reader_SELECT["Country_Pers"]));}
                    if (checkBox2.Checked){qqq.Add(Convert.ToString(reader_SELECT["Head_Name"]));}
                    if (checkBox4.Checked){qqq.Add(Convert.ToString(reader_SELECT["Owner_Name"]));}

                    ListViewItem item = new ListViewItem(
                        qqq.ToArray()
                    );
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
            textBox_UNP_Org_SELECT.Clear();
            textBox_Short_Name_Org_SELECT.Clear();
            textBox_Full_Name_Org_SELECT.Clear();
            comboBox_Countyr_Org_SELECT.SelectedValue = "(не выбрано)";
            comboBox_Name_Section.SelectedValue = "(не выбрано)";
            dateTimePicker_Create_date_Org_STARTL.Value = dateTimePicker_Create_date_Org_STARTL.MinDate;
            dateTimePicker_Create_date_Org_FINAL.Value = DateTime.Now;
            comboBox_SELECT_Country_Pers.SelectedValue = "(не выбрано)";
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
            checkBox12.Checked = false;
            Manufacturer.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
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

   
    }
}







