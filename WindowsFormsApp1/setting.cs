using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class setting : Form
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        public setting()
        {
            InitializeComponent();
        }

        private void setting_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            username.Text = Login.user_name;
            password.Text = Login.pass_word;
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "SELECT SHOW_NAME FROM ACCOUNT WHERE USERNAME = N'" + username.Text.ToString() + "'";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "SHOW_NAME");
            dt = ds.Tables["SHOW_NAME"];
            name.Text = dt.Rows[0]["SHOW_NAME"].ToString();
            conn.Close();
        }

        private void add_bill_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("DO YOU WANT CHANGE YOUR PASSWORD", "QUESTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(re == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString = "UPDATE ACCOUNT SET PASSWORD = N'" + password.Text.ToString() + "',SHOW_NAME = N'" + name.Text.ToString() + "' WHERE USERNAME = N'" + username.Text.ToString() + "'";
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                conn.Close();               
            }
            
        }
    }
}
