using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            button_Update_Delite.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            New_Organisation new_Organisation = new New_Organisation();
            new_Organisation.Show();
            //this.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
            //this.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Apdate_Delete apdate_Delete = new Apdate_Delete();
            apdate_Delete.Show();
        }
    }
}
