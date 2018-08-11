using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPatrick.Classes
{
    public class Log
    {
        private int id;
        private string description;
        private DateTime date;
        private string type;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        //public int Id { get => id; set => id = value; }
        //public string Description { get => description; set => description = value; }
        //public DateTime Date { get => date; set => date = value; }
        //public string Type { get => type; set => type = value; }

        public Log(string description, DateTime dateTime, string type)
        {
            this.Description = description;
            this.Date = dateTime;
            this.Type = Type;
        }

        public Log()
        {
        }
        public static void SaveLog(string description, string type, DateTime date)
        {
            string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData"; ;

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            //Conectar
            sqlConnect.Open();
            string sql = "INSERT INTO LOG (DESCRIPTION, TYPE, DATE) VALUES (@description, @type, @date)";
            //string sql = "INSERT INTO CATEGORY(NAME, ACTIVE) VALUES (" 
            //    + this.tbxName.Text + "," + this.cbxActive.Checked + ")";

            SqlCommand cmd = new SqlCommand(sql, sqlConnect);

            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@date", date));
            

            cmd.ExecuteNonQuery();

        }

    }
} 

