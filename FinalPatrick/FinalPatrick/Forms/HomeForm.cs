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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void pbxCategory_MouseEnter(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.CadetBlue;
            lblCategory.Visible = true;
        }

        private void pbxCategory_MouseLeave(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.Transparent;
            lblCategory.Visible = false;
        }

        private void pbxProduct_MouseEnter(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.CadetBlue;
            lblProduct.Visible = true;
        }

        private void pbxProduct_MouseLeave(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.Transparent;
            lblProduct.Visible = false;
        }

        private void pbxUserProfire_MouseEnter(object sender, EventArgs e)
        {
            pbxUserProfile.BackColor = Color.CadetBlue;
            lblUserProfile.Visible = true;
        }

        private void pbxUserProfire_MouseLeave(object sender, EventArgs e)
        {
            pbxUserProfile.BackColor = Color.Transparent;
            lblUserProfile.Visible = false;
        }

        private void pbxLog_MouseEnter(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.CadetBlue;
            lblLog.Visible = true;
        }

        private void pbxLog_MouseLeave(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.Transparent;
            lblLog.Visible = false;
        }

        private void pbxUser_MouseEnter(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.CadetBlue;
            lblUser.Visible = true;
        }

        private void pbxUser_MouseLeave(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.Transparent;
            lblUser.Visible = false;
        }

        private void pbxCategory_Click(object sender, EventArgs e)
        {
            CategoryAllForm categoryAllForm = new CategoryAllForm();
            categoryAllForm.Show();
           
        }

        private void pbxProduct_Click(object sender, EventArgs e)
        {
            ProductAllForm productAllForm = new ProductAllForm();
            productAllForm.Show();
           
        }

        private void pbxUserProfile_Click(object sender, EventArgs e)
        {

            UserProfileAllForm userProfileAllForm = new  UserProfileAllForm();
            userProfileAllForm.Show();
           
        }

        private void pbxLog_Click(object sender, EventArgs e)
        {

            LogForm logForm = new LogForm();
            logForm.Show();
            
        }

        private void pbxUser_Click(object sender, EventArgs e)
        {

           UserAllForm userAllForm = new UserAllForm();
           userAllForm.Show();
           
        }
    }
}
