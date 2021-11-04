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
    public partial class Category : UserControl
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        private SqlDataAdapter myAdapter1;
        private SqlCommand comm1;
        private DataSet ds1;
        private DataTable dt1;

        int row_check;
        private static Category _instance;
        public static Category Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Category();
                return _instance;
            }
        }
        public Category()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text.ToString() != "")
            {
                conn = new SqlConnection(conStr);
                conn.Open();

                string sqlString = "EXEC INSERT_FOODCATEGORY '" + name_textBox.Text.ToString() + "'";
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                LoadData();
                LoadData1();
                conn.Close();
            }
            else
            {
                MessageBox.Show("NAME CATEGORY IS NULL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "SELECT * FROM FOOD_CATEGORY";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();

            myAdapter.Fill(ds, "ID");
            dt = ds.Tables["ID"];
            guna2DataGridView1.DataSource = dt;

            conn.Close();
        }

        private void guna2DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dt.Rows.Count > 0)
            {
                int row = e.RowIndex;
                row_check = row;
                try
                {
                    id_textBox.Text = dt.Rows[row]["ID"].ToString();
                    name_text.Text = dt.Rows[row]["NAME"].ToString();
                    LoadData1();
                }
                catch { }
            }
        }

        private void LoadData1()
        {
            conn = new SqlConnection(conStr);
            conn.Open();

            string sqlString = "SELECT ID,NAME  FROM FOOD WHERE IDCATEGORY = " +id_textBox.Text.ToString();
            myAdapter1 = new SqlDataAdapter(sqlString, conn);
            ds1 = new DataSet();

            myAdapter1.Fill(ds1, "ID");
            dt1 = ds1.Tables["ID"];
            guna2DataGridView2.DataSource = dt1;
            conn.Close();
        }
        private void searchValue(string Value)
        {
            conn = new SqlConnection(conStr);
            conn.Open();

            string sqlString = "SELECT * FROM FOOD_CATEGORY" +
                            " WHERE NAME LIKE N'%" + Value + "%'";
            comm = new SqlCommand(sqlString, conn);
            myAdapter = new SqlDataAdapter(comm);
            dt = new DataTable();
            myAdapter.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string value = searchString.Text;
            searchValue(value);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("DO YOU WANT DELETE THIS CATEGORY", "QUESTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 

            if(re == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                //Delete all Food have idcategory is same id_textBox
                string sqlString1 = "DELETE FROM FOOD WHERE IDCATEGORY =" + id_textBox.Text.ToString();
                comm = new SqlCommand(sqlString1, conn);
                comm.ExecuteNonQuery();

                string sqlString = "DELETE FROM FOOD_CATEGORY WHERE ID=" + id_textBox.Text.ToString();
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
            LoadData1();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("DO YOU WANT UPDATE THIS CATEGORY", "QUESTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(re == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();

                string sqlString = "UPDATE FOOD_CATEGORY SET NAME = N'"+ name_text.Text.ToString()+"' WHERE ID = "+id_textBox.Text.ToString();
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }
    }
}
