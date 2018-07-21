using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPatrick.Forms
{
    public partial class UserDetailsForm : Form
    {
        string name = "";
        string email = "";
        string password = "";
        string confpassword = "";
        bool active = false;

        public UserDetailsForm()
        {
            InitializeComponent();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            UserAllForm home = new UserAllForm();
            home.Show();
            this.Hide();
        }
        void GetData()
        {
            name = tbxName.Text;
            email = tbxEmail.Text;
            password = tbxpassword.Text;
            confpassword = tbxConfirmPassword.Text;
            active = cbxActive.Checked;
        }

        void CleanData()
        {
            tbxName.Text = "";
            tbxEmail.Text = "";
            tbxpassword.Text = "";
            tbxConfirmPassword.Text = "";
            cbxActive.Checked = false;
        }
    }
}
