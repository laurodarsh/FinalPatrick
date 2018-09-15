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
    public partial class UserDetailsForm : Form
    {
        string name = "";
        string email = "";
        string password = "";
        string confpassword = "";
        bool active = false;

        List<UserProfile> profiles = new List<UserProfile>();

        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";


        public UserDetailsForm()
        {
            InitializeComponent();
            pbxDelete.Visible = false;
            cmbProfile.DisplayMember = "NAME";
            LoadComboBox();
        }

        public UserDetailsForm(int idUser)
        {
            InitializeComponent();
            cmbProfile.DisplayMember = "NAME";
            LoadComboBox();
            lblId.Text = idUser.ToString();

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblId.Text))
            {
                try
                {
                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM [USER] WHERE ID = @id", sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", idUser));

                    User user = new User();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Id = Int32.Parse(reader["ID"].ToString());
                            user.Name = reader["NAME"].ToString();
                            user.Active = bool.Parse(reader["ACTIVE"].ToString());
                            user.Email = reader["Email"].ToString();
                            user.Password = reader["Password"].ToString();
                        }
                    }

                    tbxName.Text = user.Name;
                    cbxActive.Checked = user.Active;
                    tbxEmail.Text = user.Email;
                    tbxpassword.Text = user.Password;
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
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM USER_PROFILE", cn);
                int id;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader["ID"].ToString());
                    UserProfile u = new UserProfile(reader["NAME"].ToString(), bool.Parse(reader["ACTIVE"].ToString()), id);
                    profiles.Add(u);
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
            foreach (UserProfile u in profiles)
            {
                cmbProfile.Items.Add(u);
            }
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {

            UserAllForm userall = new UserAllForm();
            userall.Show();
            

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

        private void pbxSave_Click(object sender, EventArgs e)
        {
            if (tbxpassword.Text == tbxConfirmPassword.Text)

                if (string.IsNullOrEmpty(lblId.Text))
                {
                    SqlConnection sqlConnect = new SqlConnection(connectionString);
                    try
                    {
                        GetData();

                        if (confpassword == password)
                        {

                            sqlConnect.Open();
                            string sql = "INSERT INTO [USER] (NAME , PASSWORD , EMAIL , ACTIVE , FK_USERPROFILE) VALUES (@name, @password, @email , @active , @profile)";

                            SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                            cmd.Parameters.Add(new SqlParameter("@name", name));
                            cmd.Parameters.Add(new SqlParameter("@password", UserHelper.Hash(password)));
                            cmd.Parameters.Add(new SqlParameter("@email", email));
                            cmd.Parameters.Add(new SqlParameter("@active", active));
                            cmd.Parameters.Add(new SqlParameter("@profile", ((UserProfile)cmbProfile.SelectedItem).Id));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Adicionado com sucesso!");
                            CleanData();

                            Log.SaveLog("Usuário Adicionado", "Adição", DateTime.Now);

                        }
                        else
                        {
                            MessageBox.Show("Senhas Informadas são diferentes ");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao adicionar Usuário!" + ex.Message);
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
                        GetData();


                        sqlConnect.Open();
                        string sql = "UPDATE [USER] SET NAME = @name,PASSWORD = @password , EMAIL = @email , ACTIVE = @active , FK_USERPROFILE = @fkuserprofile Where ID = @id";

                        SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                        cmd.Parameters.Add(new SqlParameter("@name", name));
                        cmd.Parameters.Add(new SqlParameter("@password", UserHelper.Hash(password)));
                        cmd.Parameters.Add(new SqlParameter("@email", email));
                        cmd.Parameters.Add(new SqlParameter("@active", active));
                        cmd.Parameters.Add(new SqlParameter("@fkuserprofile", ((UserProfile)cmbProfile.SelectedItem).Id));
                        cmd.Parameters.Add(new SqlParameter("@id", this.lblId.Text));
                        cmd.ExecuteNonQuery();


                        MessageBox.Show("Alterações salvas com sucesso!");
                        Log.SaveLog("Usuário Editado", "Edição", DateTime.Now);

                        UserAllForm UserAllForm = new UserAllForm();
                        UserAllForm.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Erro ao editar esté Usuario!" + "\n\n" + Ex.Message);
                        throw;
                    }
                    finally
                    {
                        sqlConnect.Close();

                       
                    }
                }
            else
            {
                MessageBox.Show("As Senhas não coincidem");
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
                    string sql = "UPDATE [USER] SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario inativo!");

                    Log.SaveLog("Usuario Excluido", "Exclusão", DateTime.Now);

                    UserAllForm UserAllForm = new UserAllForm();
                    UserAllForm.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar este Usuario!" + "\n\n" + Ex.Message);
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
