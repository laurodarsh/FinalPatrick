using FinalPatrick.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPatrick.Forms
{
    public partial class LogForm : Form
    {
        string connectionString = "workstation id=StockControl.mssql.somee.com;packet size=4096;user id=levelupacademy_SQLLogin_1;pwd=3wwate8gu1;data source=StockControl.mssql.somee.com;persist security info=False;initial catalog=StockControl";

        public LogForm()
        {
            InitializeComponent();

            ShowData();
            ResizeDataGridView();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void ShowData()
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM LOG ORDER BY DATE DESC ", sqlConnect);
            

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sqlDtAdapter = new SqlDataAdapter(cmd);
                sqlDtAdapter.Fill(dt);

              dgvLog.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar. " + ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void ResizeDataGridView()
        {
            dgvLog.Columns["ID"].Visible = false;
            dgvLog.Columns["DESCRIPTION"].HeaderText = "Descrição";
            dgvLog.Columns["TYPE"].HeaderText = "Tipo";
            dgvLog.Columns["DATE"].HeaderText = "Data";
           

            foreach (DataGridViewColumn col in dgvLog.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {
            string optionForm = "LogForm";
            string optionString = "description";

            Search search = new Search();
            dgvLog.DataSource = search.SearchFilter(connectionString, tbxSearch.Text, optionString, optionForm);

            tbxSearch.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();

        }

        private void pbxBack_MouseEnter(object sender, EventArgs e)
        {
            pbxBack.BackColor = SystemColors.ActiveBorder;
        }

        private void pbxBack_MouseLeave(object sender, EventArgs e)
        {

            pbxBack.BackColor = SystemColors.Window;
        }

        private void pbxSearch_MouseEnter(object sender, EventArgs e)
        {
            pbxBack.BackColor = SystemColors.ActiveBorder;
        }
    }
}
