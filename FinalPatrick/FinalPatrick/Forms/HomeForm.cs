using FinalPatrick.Classes;
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

        User aux = new User();
        public HomeForm(User user)
        {
            InitializeComponent();

            if (user.UserProfile.Id != 3)
            {
                pbxLog.Enabled = false;
                pbxUser.Enabled = false;
                pbxUserProfile.Enabled = false;

            }
            aux = user;

            lbluserOn.Text = "Seja Bem Vindo " + user.Name;
        }

        private void pbxCategory_MouseEnter(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.White;

        }
        private void pbxCategory_MouseLeave(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.White;

        }

        private void pbxProduct_MouseEnter(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.White;

        }

        private void pbxProduct_MouseLeave(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.White;

        }

        private void pbxUserProfire_MouseEnter(object sender, EventArgs e)
        {
            pbxUserProfile.BackColor = Color.White;

        }

        private void pbxUserProfire_MouseLeave(object sender, EventArgs e)
        {
            pbxUserProfile.BackColor = Color.White;

        }

        private void pbxLog_MouseEnter(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.White;

        }

        private void pbxLog_MouseLeave(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.White;

        }

        private void pbxUser_MouseEnter(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.White;

        }

        private void pbxUser_MouseLeave(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.White;

        }

        private void pbxCategory_Click(object sender, EventArgs e)
        {
            CategoryAllForm categoryAllForm = new CategoryAllForm(aux);
            categoryAllForm.Show();

        }

        private void pbxProduct_Click(object sender, EventArgs e)
        {
            ProductAllForm productAllForm = new ProductAllForm(aux);
            productAllForm.Show();

        }

        private void pbxUserProfile_Click(object sender, EventArgs e)
        {

            UserProfileAllForm userProfileAllForm = new UserProfileAllForm();
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
