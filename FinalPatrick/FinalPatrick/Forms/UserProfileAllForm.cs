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
    public partial class UserProfileAllForm : Form
    {
        string connectionString = "workstation id=StockControl.mssql.somee.com;packet size=4096;user id=levelupacademy_SQLLogin_1;pwd=3wwate8gu1;data source=StockControl.mssql.somee.com;persist security info=False;initial catalog=StockControl";



        public UserProfileAllForm()
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
            UserProfileDetailsForm cuserprofile = new UserProfileDetailsForm();
            cuserprofile.Show();
            this.Hide();
        }
        private void ShowData()
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM  USER_PROFILE", sqlConnect);
               
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sqlDtAdapter = new SqlDataAdapter(cmd);
                sqlDtAdapter.Fill(dt);

                dgvUserProfile.DataSource = dt;

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
            dgvUserProfile.Columns["ID"].Visible = false;
            dgvUserProfile.Columns["NAME"].HeaderText = "Nome";
            dgvUserProfile.Columns["ACTIVE"].HeaderText = "Ativo";



            foreach (DataGridViewColumn col in dgvUserProfile.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {
            string optionForm = "UserProfileForm";
            string optionString = "name";

            Search search = new Search();
            dgvUserProfile.DataSource = search.SearchFilter(connectionString, tbxSearch.Text, optionString, optionForm);

            tbxSearch.Text = "";
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            int idUserProfile = Int32.Parse(dgvUserProfile.SelectedRows[0].Cells[0].Value.ToString());

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();
                string sql = "UPDATE USER_PROFILE SET ACTIVE = @active WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@id", idUserProfile));
                cmd.Parameters.Add(new SqlParameter("@active", false));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Perfil de Usuario inativo!");
                Log.SaveLog("Perfil de Usuario Excluido", "Exclusão", DateTime.Now);
                ShowData();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erro ao Excluir este Perfil!" + "\n\n" + Ex.Message);
                throw;
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void pbxEdit_Click(object sender, EventArgs e)
        {
            int idUserProfile = Int32.Parse(dgvUserProfile.SelectedRows[0].Cells[0].Value.ToString());

           UserProfileDetailsForm UserProfileDetails = new UserProfileDetailsForm(idUserProfile);
            UserProfileDetails.Show();

            this.Close();
        }
    }
}