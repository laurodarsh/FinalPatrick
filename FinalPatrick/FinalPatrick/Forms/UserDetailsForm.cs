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

            cmbProfile.DisplayMember = "NAME";
            LoadComboBox();
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
                    cmd.Parameters.Add(new SqlParameter("@password",UserHelper.Hash(password)));
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
                    MessageBox.Show("Senhas Informadas são Diferentes ");
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
    }
}
