﻿using FinalPatrick.Classes;
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
    public partial class UserProfileDetailsForm : Form
    {

        string name = "";
        bool active = false;

        string connectionString = "workstation id=StockControl.mssql.somee.com;packet size=4096;user id=levelupacademy_SQLLogin_1;pwd=3wwate8gu1;data source=StockControl.mssql.somee.com;persist security info=False;initial catalog=StockControl";

        public UserProfileDetailsForm()
        {
            InitializeComponent();
            pbxDelete.Visible = false;
        }

        public UserProfileDetailsForm(int idUserProfile)
        {
            InitializeComponent();
            lblId.Text = idUserProfile.ToString();

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblId.Text))
            {
                try
                {
                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM USER_PROFILE WHERE ID = @id", sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", idUserProfile));

                    UserProfile profile = new UserProfile();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profile.Id = Int32.Parse(reader["ID"].ToString());
                            profile.Name = reader["NAME"].ToString();
                            profile.Active = bool.Parse(reader["ACTIVE"].ToString());
                        }
                    }

                    tbxName.Text = profile.Name;
                    cbxActive.Checked = profile.Active;

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

        private void pbxBack_Click(object sender, EventArgs e)
        {

            UserProfileAllForm UserprofForm = new UserProfileAllForm();
            UserprofForm.Show();
            this.Hide();
          
        }
        void GetData()
        {
            name = tbxName.Text;
            active = cbxActive.Checked;
        }

        void CleanData()
        {
            tbxName.Text = "";
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
                    string sql = "INSERT INTO USER_PROFILE(NAME, ACTIVE) VALUES (@name, @active)";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@active", active));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Adicionado com sucesso!");
                    CleanData();

                    Log.SaveLog("Perfil Adicionado", "Adição", DateTime.Now);

                    UserProfileAllForm userProfileAll = new UserProfileAllForm();
                    userProfileAll.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar Perfil de Usuário !" + ex.Message);
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
                    string sql = "UPDATE USER_PROFILE SET NAME = @name, ACTIVE = @active Where ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", this.lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@name", this.tbxName.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", this.cbxActive.Checked));

                    cmd.ExecuteNonQuery();
                    Log.SaveLog("Perfil Editado" , "Edição", DateTime.Now);
                    MessageBox.Show("Altereções salvas com sucesso!");

                    UserProfileAllForm userProfileAll = new UserProfileAllForm();
                    userProfileAll.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao editar este Perfil de Usuario !" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                    
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
                    string sql = "UPDATE USER_PROFILE SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Perfil inativo!");

                    Log.SaveLog("Perfil de Usuario Excluido", "Exclusão", DateTime.Now);

                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar este Perfil!" + "\n\n" + Ex.Message);
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
