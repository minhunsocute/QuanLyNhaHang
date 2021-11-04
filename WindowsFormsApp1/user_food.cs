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
    public partial class user_food : UserControl
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

        private SqlDataAdapter myAdapter2;
        private SqlCommand comm2;
        private DataSet ds2;
        private DataTable dt2;

        private static user_food _instance;
        public static user_food Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new user_food();
                return _instance;
            }
        }

        public user_food()
        {
            InitializeComponent();
        }

        private void user_food_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData1();
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

        private void LoadData1()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "EXEC SELECT_BILL " + 19.ToString();
            myAdapter1 = new SqlDataAdapter(sqlString, conn);
            ds1 = new DataSet();
            myAdapter1.Fill(ds1, "FN");
            dt1 = ds1.Tables["FN"];
            guna2DataGridView2.DataSource = dt1;
            int sum = 0;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                guna2DataGridView2.Rows[i].Cells["price1"].Value = int.Parse(guna2DataGridView2.Rows[i].Cells["cost"].Value.ToString()) * int.Parse(guna2DataGridView2.Rows[i].Cells["no"].Value.ToString());
                sum += int.Parse(guna2DataGridView2.Rows[i].Cells["cost"].Value.ToString()) * int.Parse(guna2DataGridView2.Rows[i].Cells["no"].Value.ToString());
            }
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
                }
                catch { }
            }
        }
        private void searchValue(string Value)
        {
            conn = new SqlConnection(conStr);
            conn.Open();

            string sqlString = "SELECT * FROM FOOD" +
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
            string value = searchString.Text.ToString();
            searchValue(value);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "SELECT COUNT(*) FROM BILL WHERE STATUS = 0 AND IDTABLE = 19";
            comm = new SqlCommand(sqlString, conn);
            Int32 count = (Int32)comm.ExecuteScalar();
            if (count == 0)
                MessageBox.Show("PLEASE ADD BILL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string sqlString2 = "SELECT TOP(1) ID FROM BILL WHERE IDTABLE = 19 AND STATUS = 0";
                myAdapter2 = new SqlDataAdapter(sqlString2, conn);
                ds2 = new DataSet();
                myAdapter2.Fill(ds2, "ID");
                dt2 = ds2.Tables["ID"];
                string sqlString1 = "EXEC INSERT_TOBILLINFO " + dt2.Rows[0]["ID"].ToString()+","+id_textBox.Text.ToString()+","+price_text.Value.ToString();
                comm = new SqlCommand(sqlString1, conn);
                comm.ExecuteNonQuery();
                LoadData1();
            }
            conn.Close();
        }
    }
}
