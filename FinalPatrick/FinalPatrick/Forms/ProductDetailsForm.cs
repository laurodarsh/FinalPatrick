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
    public partial class ProductDetailsForm : Form

    {
        string name;
        float price = 0;
        bool active;

        List<Category> categories = new List<Category>();

        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";

        User aux;

        public ProductDetailsForm(User user)
        {
            InitializeComponent();

            cmbCategory.DisplayMember = "NAME";
            LoadComboBox();
            aux = user;
        }
        public ProductDetailsForm(int idProduct, User user)
        {
            InitializeComponent();



            cmbCategory.DisplayMember = "NAME";
            LoadComboBox();
            aux = user;

            lblId.Text = idProduct.ToString();

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblId.Text))
            {
                try
                {

                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT WHERE ID = @id", sqlConnect);


                    cmd.Parameters.Add(new SqlParameter("@id", idProduct));

                    Product product = new Product();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.Id = Int32.Parse(reader["ID"].ToString());
                            product.Name = reader["NAME"].ToString();
                            product.Active = bool.Parse(reader["ACTIVE"].ToString());
                            product.Price = float.Parse(reader["PRICE"].ToString());
                        }
                    }

                    tbxName.Text = product.Name;
                    cbxActive.Checked = product.Active;
                    tbxPrice.Text = product.Price.ToString();

                }
                catch (Exception EX)
                {

                    throw;
                }
                finally
                {

                    sqlConnect.Close();
                }
            }
        }
        void LoadComboBox()
        {
            SqlConnection cn = new SqlConnection(connectionString);

            try
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CATEGORY", cn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category(reader["NAME"].ToString(), bool.Parse(reader["ACTIVE"].ToString()), Int32.Parse(reader["ID"].ToString()));
                    categories.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            foreach (Category c in categories)
            {
                cmbCategory.Items.Add(c);
            }
        }

        private void pbxback_Click(object sender, EventArgs e)
        {
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

        private void pbxSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(lblId.Text))
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);
                try
                {
                    GetData();

                    sqlConnect.Open();
                    string sql = "INSERT INTO PRODUCT(NAME, PRICE, ACTIVE, FK_PRODUCT) VALUES (@name, @price, @active, @category)";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@active", active));
                    cmd.Parameters.Add(new SqlParameter("@category", ((Category)cmbCategory.SelectedItem).Id));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Adicionado com sucesso!");
                    CleanData();

                    Log.SaveLog("Produto Adicionado", "Adição", DateTime.Now);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro ao adicionar Produto !" + ex.Message);
                    CleanData();
                }
                finally
                {
                    sqlConnect.Close();

                }
            }
            else
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);

                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE PRODUCT  SET NAME = @name , ACTIVE = @active , PRICE = @price, FK_PRODUCT = @fk_product Where ID =@id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", this.lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@name", this.tbxName.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", this.cbxActive.Checked));
                    cmd.Parameters.Add(new SqlParameter("@price", this.tbxPrice.Text));
                    cmd.Parameters.Add(new SqlParameter("@fk_product", ((Category)(cmbCategory.SelectedItem)).Id));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Altereções salvas com sucesso!");
                    Log.SaveLog("Produto Editado", "Edição", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao editar este Produto !" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                    UserProfileAllForm userProfileAll = new UserProfileAllForm();
                    userProfileAll.Show();
                    this.Hide();
                }
            }
        }
        private void pbxDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);

                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE PRODUCT SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Produto inativo!");
                    Log.SaveLog("Produto Excluido", "Exclusão", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar este Produto!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
        }
    }
}
