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
    public partial class ProductDetailsForm : Form

    {
        string name;
        float price = 0;
        bool active;

        public ProductDetailsForm()
        {
            InitializeComponent();
        }

        private void pbxback_Click(object sender, EventArgs e)
        {
            ProductAllForm home = new ProductAllForm();
            home.Show();
            this.Hide();
        }
        void GetData()
        {
            name = tbxName.Text;
            price = float.Parse(tbxPrice.Text);
            active = cbxActive.Checked;
        }

        void CleanData()
        {
            tbxName.Text = "";
            tbxPrice.Text = "";
            cbxActive.Checked = false;
        }
    }
}
