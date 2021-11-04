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
    public partial class add_food : UserControl
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        string[] category_string = new string[500];
        private static add_food _instace;
        public static add_food Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new add_food();
                return _instace;
            }
        }
        public static int check = 0;
        public add_food()
        {
            InitializeComponent();
        }
            
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text.ToString() != "" && id_textBox.Text.ToString() != "")
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                int add_string = 0;
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (category_textBox1.Text.ToString() == category_string[i])
                    {
                        string SqlString1 = "SELECT TOP(1) ID FROM FOOD_CATEGORY WHERE NAME = N'"+category_string[i]+"'";
                        myAdapter = new SqlDataAdapter(SqlString1, conn);
                        ds = new DataSet();
                        myAdapter.Fill(ds, "ID");

                        dt = ds.Tables["ID"];

                        add_string = int.Parse(dt.Rows[0]["ID"].ToString());
                        break;
                    }
                }
                string sqlString = "EXEC INSERT_FOOD '"+name_textBox.Text.ToString()+"',"+add_string.ToString()+"" +
                                    ","+price_text.Value.ToString();
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("INPUT IS NULL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
            name_textBox.Clear();
            price_text.Value = 10000;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadData();
            //LoadCboBox();
        }
        private void LoadData()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString1 = "SELECT MAX(ID) FROM FOOD";
            comm = new SqlCommand(sqlString1, conn);
            Int32 count = (Int32)comm.ExecuteScalar();
            id_textBox.Text = (count + 1).ToString();
            
        }
        private void LoadCboBox()
        {

            int n = 0;
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "SELECT * FROM FOOD_CATEGORY ORDER BY ID ASC";
            category_string = new string[500];
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "ID");
            dt = ds.Tables["ID"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                category_string[i] = dt.Rows[i]["NAME"].ToString();
                n++;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                category_textBox1.Items.Add(category_string[i]);
            }
            conn.Close();
            
        }

        private void category_textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCboBox();
        }

        private void category_textBox1_Click(object sender, EventArgs e)
        {
            category_textBox1.Items.Clear();
            LoadCboBox();
        }
    }
}
