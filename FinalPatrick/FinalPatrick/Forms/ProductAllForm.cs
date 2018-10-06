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
    public partial class ProductAllForm : Form
    {
        string connectionString = "workstation id=StockControl.mssql.somee.com;packet size=4096;user id=levelupacademy_SQLLogin_1;pwd=3wwate8gu1;data source=StockControl.mssql.somee.com;persist security info=False;initial catalog=StockControl";
        User aux = new User();

        public ProductAllForm(User user)
        {
            InitializeComponent();
            aux = user;
            ShowData();
            ResizeDataGridView();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            ProductDetailsForm cprod = new ProductDetailsForm(aux);
            cprod.Show();
            this.Hide();
        }
        private void ShowData()
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                SqlCommand cmd;
                sqlConnect.Open();
                if (aux.UserProfile.Id != 3)
                {
                    cmd = new SqlCommand("SELECT PRODUCT.ID, PRODUCT.NAME, PRODUCT.ACTIVE, PRODUCT.PRICE, CATEGORY.NAME FROM PRODUCT INNER JOIN CATEGORY ON PRODUCT.FK_PRODUCT = CATEGORY.ID WHERE PRODUCT.ACTIVE = @active", sqlConnect);    
                    cmd.Parameters.Add(new SqlParameter("@active", true));
                }
                else
                {
                    cmd = new SqlCommand("SELECT PRODUCT.ID, PRODUCT.NAME, PRODUCT.ACTIVE, PRODUCT.PRICE, CATEGORY.NAME FROM PRODUCT INNER JOIN CATEGORY ON PRODUCT.FK_PRODUCT = CATEGORY.ID", sqlConnect);
                }
                
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sqlDtAdapter = new SqlDataAdapter(cmd);
                sqlDtAdapter.Fill(dt);

                dgvProduct.DataSource = dt;

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
            dgvProduct.Columns["ID"].Visible = false;
            dgvProduct.Columns["NAME"].HeaderText = "Nome";
            dgvProduct.Columns["ACTIVE"].HeaderText = "Ativo";
            dgvProduct.Columns["ACTIVE"].DisplayIndex = 4;
            dgvProduct.Columns["NAME1"].HeaderText = "Categoria";
            dgvProduct.Columns["NAME1"].DisplayIndex = 3;
            dgvProduct.Columns["PRICE"].HeaderText = "Preço";

            foreach (DataGridViewColumn col in dgvProduct.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void pbxSearch_Click_1(object sender, EventArgs e)
        {
            string optionForm = "ProductForm";
            string optionString = "name";

            Search search = new Search();
            dgvProduct.DataSource = search.SearchFilter(connectionString, tbxSearch.Text, optionString, optionForm);

            tbxSearch.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            int idProduct = Int32.Parse(dgvProduct.SelectedRows[0].Cells[0].Value.ToString());

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();
                string sql = "UPDATE PRODUCT SET ACTIVE = @active WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@id", idProduct));
                cmd.Parameters.Add(new SqlParameter("@active", false));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto inativo!");

                Log.SaveLog("Produto Excluido", "Exclusão", DateTime.Now);
                ShowData();

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erro ao Excluir este produto!" + "\n\n" + Ex.Message);
                throw;
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void pbxEdit_Click(object sender, EventArgs e)
        {
            int idProduct = Int32.Parse(dgvProduct.SelectedRows[0].Cells[0].Value.ToString());

            ProductDetailsForm ProductDetails = new ProductDetailsForm(idProduct, aux);
            ProductDetails.Show();

            this.Close();
        }

        private void pbxAdd_MouseEnter(object sender, EventArgs e)
        {
            pbxAdd.BackColor = Color.Bisque;
        }

        private void pbxEdit_MouseEnter(object sender, EventArgs e)
        {
            pbxEdit.BackColor = Color.Bisque;
        }

        private void pbxDelete_MouseEnter(object sender, EventArgs e)
        {
            pbxDelete.BackColor = Color.Bisque;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
           button1.BackColor = Color.Bisque;
        }

        private void pbxSearch_MouseEnter(object sender, EventArgs e)
        {
           pbxSearch.BackColor = Color.Bisque;
        }
    }
}
