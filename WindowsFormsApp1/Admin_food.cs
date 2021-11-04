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
   
    public partial class Admin_food : UserControl
    {
        int flag = -1;
        
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

        private static Admin_food _instance;
        public static Admin_food Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Admin_food();
                return _instance;
            }
        }
        public Admin_food()
        {
            InitializeComponent();
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Admin_food_Load(object sender, EventArgs e)
        {
            guna2Button6.Hide();
            panel4.Hide();
            LoadData();
            LoadCboBox();
        }
        private void LoadData()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            // set data for datagridView
            string sqlString = "SELECT * FROM FOOD";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();

            myAdapter.Fill(ds, "ID");
            dt = ds.Tables["ID"];
            guna2DataGridView1.DataSource = dt;

            //set name category 
            /*for(int i = 0; i < dt.Rows.Count; i++)
            {
                string sqlString1 = "SELECT TOP(1) C.NAME FROM FOOD_CATEGORY AS C,FOOD as F WHERE " +
                                    "F.IDCATEGORY = C.ID AND F.ID = " + guna2DataGridView1.Rows[i].Cells["id"].ToString();
                myAdapter = new SqlDataAdapter(sqlString1, conn);
            }*/
            
           // LoadCboBox();

            conn.Close();
        }

        private void LoadCboBox()
        {
            int n = 0;
            string[] category_string = new string[500];
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "SELECT * FROM FOOD_CATEGORY ORDER BY ID ASC";
            myAdapter1 = new SqlDataAdapter(sqlString, conn);
            ds1 = new DataSet();
            myAdapter1.Fill(ds1, "ID");
            dt1 = ds1.Tables["ID"];

            for(int i = 0; i < dt1.Rows.Count; i++)
            {
                category_string[i] = dt1.Rows[i]["NAME"].ToString();
                n++;
            }

            for(int i = 0; i < n; i++)
            {
                category_textBox.Items.Add(category_string[i]);
            }
            conn.Close();
        }
        private void guna2DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dt.Rows.Count > 0)
            {
                int row = e.RowIndex;
                try
                {
                    id_textBox.Text = dt.Rows[row]["ID"].ToString();
                    name_textBox.Text = dt.Rows[row]["NAME"].ToString();
                    price_text.Value = Int32.Parse(dt.Rows[row]["COST"].ToString());
                    //category_textBox.Text = dt.Rows[row]["NAME_CATEGORY"].ToString();

                }
                catch { }
            }
        }
        private void searchValue(string Value)
        {
            conn = new SqlConnection(conStr);
            conn.Open();

            string sqlString = "SELECT * FROM FOOD" +
                            " WHERE NAME LIKE N'%"+Value+"%'";
            comm = new SqlCommand(sqlString, conn);
            myAdapter = new SqlDataAdapter(comm);
            dt = new DataTable();
            myAdapter.Fill(dt);
            guna2DataGridView1.DataSource = dt; 
            conn.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string value = searchString.Text.ToString();
            searchValue(value);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //flag *= -1;
            //if (flag == 1)
            //{
            panel4.Show();
            guna2Button6.Show();
            if (!panel4.Controls.Contains(add_food.Instance))
            {
                panel4.Controls.Add(add_food.Instance);
                add_food.Instance.Dock = DockStyle.Fill;
                add_food.Instance.BringToFront();
            }
            else
                add_food.Instance.BringToFront();
            //}
           // else
            //{
              //  panel4.Hide();
            //}
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            guna2Button6.Hide();
            LoadData();
        }

        private void price_text_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("DO YOU WANT DELETE THIS FOOD", "QUESTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(re == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString1 = "DELETE BILL_INFO WHERE  IDFOOD = " + id_textBox.Text.ToString();
                comm = new SqlCommand(sqlString1, conn);
                comm.ExecuteNonQuery();

                string sqlString = "DELETE FROM FOOD WHERE ID = "+id_textBox.Text.ToString();
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("DO YOU WANT CHANGE INFORMATION THIS FOOD ID", "QUESTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(re == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString1 = "SELECT TOP(1) C.ID FROM FOOD_CATEGORY AS C WHERE C.NAME = N'"+category_textBox.Text.ToString()+"'";
                myAdapter = new SqlDataAdapter(sqlString1, conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "ID");
                dt = ds.Tables["ID"];
                string sqlString = "UPDATE FOOD SET NAME = N'" + name_textBox.Text.ToString()+ "',IDCATEGORY = " + dt.Rows[0]["ID"].ToString()+",COST = "+price_text.Value.ToString()+
                                   " WHERE ID = "+id_textBox.Text.ToString();
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                //searchString.Text = dt.Rows[0]["ID"].ToString();
            }
            LoadData();
        }
    }
}
