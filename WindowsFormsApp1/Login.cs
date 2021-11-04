using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;
        public static string user_name = "";
        public static string pass_word = "";

        public Login()
        {           
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void formRun()
        {
            Application.Run(new Loading());
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //check out app
            DialogResult re = MessageBox.Show("DO YOU WANT TO CLOSE THIS APP", "QUESTIONS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(re == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (username.Text.ToString() != "" && password.Text.ToString() != "")
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString = "SELECT COUNT(*) FROM ACCOUNT WHERE USERNAME = N'" + username.Text.ToString()+"' AND " +
                                "PASSWORD = N'" + password.Text.ToString()+"' AND TYPE_ACCOUNT = 0";
                comm = new SqlCommand(sqlString, conn);
                Int32 count = (Int32)comm.ExecuteScalar();
                if (count != 0)
                {
                    user_name = username.Text.ToString();
                    pass_word = password.Text.ToString();
                    Main_mana f = new Main_mana();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("USERNAME OR PASSWORD IS VALID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("INPUT IS NULL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
