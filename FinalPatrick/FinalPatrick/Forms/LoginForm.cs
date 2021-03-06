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
    public partial class LoginForm : Form
    {
        string name = "";
        string password = "";
        User aux = new User();
        bool updated = true;

        string connectionString = "workstation id=StockControl.mssql.somee.com;packet size=4096;user id=levelupacademy_SQLLogin_1;pwd=3wwate8gu1;data source=StockControl.mssql.somee.com;persist security info=False;initial catalog=StockControl";

        public LoginForm()
        {
            InitializeComponent();
        }

        void GetData()
        {
            name = tbxName.Text;
            password = tbxPassword.Text;
        }

        void CleanData()
        {
            tbxName.Text = "";
            tbxPassword.Text = "";
        }

        private bool CheckLogin(string password, string name)
        {
            User user = UserHelper.SelectByName(name);

            if (user != null)
            {
                if (UserHelper.Hash(password) == user.Password)
                {
                    aux = user;
                    return true;
                }
            }
            return false;
        }

       private void btnLogin_Click_1(object sender, EventArgs e)
        {
            GetData();
            if (CheckLogin(password, name))
            {
                HomeForm mainForm = new HomeForm(aux);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                CleanData();
                MessageBox.Show("Usuário ou senha incorretos!");
           }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void UpdatePassword()
        {
            User user = UserHelper.SelectByName(tbxName.Text);

            if (user.Name == null)
            {
                MessageBox.Show("Usuário não encontrado");
                updated = false;
            }
            else
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);

                try
                {
                    EmailHelper.SendEmail(user.Email);

                    GetData();
                    sqlConnect.Open();
                    string sql = "UPDATE [USER] SET PASSWORD = @password Where ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);
                    cmd.Parameters.Add(new SqlParameter("@password", UserHelper.Hash("456")));

                    cmd.Parameters.Add(new SqlParameter("@id", user.Id));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uma nova senha foi enviada para seu e-mail!");
                    Log.SaveLog("Usuário Editado", "Edição", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao enviar nova senha!" + "\n\n" + Ex.Message);
                    updated = false;
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            HideComponents();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Length > 0)
            {
                UpdatePassword();
                if (updated)
                {
                    ShowComponents();
                }
            }
        }

        void HideComponents()
        {
            lblSenha.Visible = false;
            tbxPassword.Visible = false;
            btnSend.Visible = true;
            btnLogin.Visible = false;
            btnBack.Visible = true;
            lblrecoverPassword.Visible = false;

        }

        void ShowComponents()
        {
            lblSenha.Visible = true;
            tbxPassword.Visible = true;
            btnSend.Visible = false;
            btnLogin.Visible = true;
            btnBack.Visible = false;
            lblrecoverPassword.Visible = true;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowComponents();

        }

        private void lblrecoverPassword_Click(object sender, EventArgs e)
        {
            HideComponents();
        }
    }
}
