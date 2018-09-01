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
    public partial class UserAllForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";


        public UserAllForm()
        {
            InitializeComponent();

            ShowData();
            ResizeDataGridView();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {

           
            this.Hide();
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            UserDetailsForm cuser = new UserDetailsForm();
            cuser.Show();
            this.Hide();
        }
        private void ShowData()
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("SELECT [USER].ID ,[USER].NAME, [USER].EMAIL, [USER].ACTIVE, USER_PROFILE.NAME FROM [USER] INNER JOIN USER_PROFILE ON [USER].FK_USERPROFILE = USER_PROFILE.ID", sqlConnect);
                

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sqlDtAdapter = new SqlDataAdapter(cmd);
                sqlDtAdapter.Fill(dt);

                dgvUser.DataSource = dt;

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
            dgvUser.Columns["ID"].Visible = false;
            dgvUser.Columns["NAME"].HeaderText = "Nome";
            dgvUser.Columns["EMAIL"].HeaderText = "Email";
            dgvUser.Columns["ACTIVE"].HeaderText = "Ativo";
            dgvUser.Columns["ACTIVE"].DisplayIndex = 4;
            dgvUser.Columns["NAME1"].HeaderText = "Perfil";
            dgvUser.Columns["NAME1"].DisplayIndex = 3;
     
            foreach (DataGridViewColumn col in dgvUser.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {
            string optionForm = "UserForm";
            string optionString = "name";

            Search search = new Search();
            dgvUser.DataSource = search.SearchFilter(connectionString, tbxSearch.Text, optionString, optionForm);

            tbxSearch.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            int idUser = Int32.Parse(dgvUser.SelectedRows[0].Cells[0].Value.ToString());

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();
                string sql = "UPDATE USER SET ACTIVE = @active WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@id", idUser));
                cmd.Parameters.Add(new SqlParameter("@active", false));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario inativo!");
                Log.SaveLog("Usuario Excluido", "Exclusão", DateTime.Now);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erro ao Excluir este Usuario!" + "\n\n" + Ex.Message);
                throw;
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void pbxEdit_Click(object sender, EventArgs e)
        {

            int idUser = Int32.Parse(dgvUser.SelectedRows[0].Cells[0].Value.ToString());

            UserDetailsForm UserDetails = new UserDetailsForm(idUser);
            UserDetails.Show();

            this.Close();
        }
    }
}
