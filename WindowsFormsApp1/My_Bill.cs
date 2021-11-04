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
    public partial class My_Bill : UserControl
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        private static My_Bill _instance;
        public static My_Bill Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new My_Bill();
                return _instance;
            }
        }
        public My_Bill()
        {
            InitializeComponent();

            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "SELECT COUNT(*) FROM BILL WHERE STATUS = 0 AND IDTABLE = 19";
            comm = new SqlCommand(sqlString, conn);
            Int32 count = (Int32)comm.ExecuteScalar();
            if (count == 0)
            {
                guna2Button1.Show();
            }
            else
                guna2Button1.Hide();
        }

        private void My_Bill_Load(object sender, EventArgs e)
        {
            LoadData1();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "INSERT INTO BILL (DATECHECKIN,DATECHECKOUT,IDTABLE,STATUS) VALUES" +
                                " (GETDATE(),GETDATE(),19,0)";
            comm = new SqlCommand(sqlString, conn);
            comm.ExecuteNonQuery();
            MessageBox.Show("BILL WAS INSERTED", "OK", MessageBoxButtons.OK);
            conn.Close();
            guna2Button1.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "EXEC UPDATE_BILL " + 19.ToString();
            comm = new SqlCommand(sqlString, conn);
            comm.ExecuteNonQuery();

            conn.Close();
            guna2Button1.Show();
            LoadData1();
        }
        private void LoadData1()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "EXEC SELECT_BILL " + 19.ToString();
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "FN");
            dt = ds.Tables["FN"];
            guna2DataGridView1.DataSource = dt;
            int sum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                guna2DataGridView1.Rows[i].Cells["price"].Value = int.Parse(guna2DataGridView1.Rows[i].Cells["cost"].Value.ToString()) * int.Parse(guna2DataGridView1.Rows[i].Cells["no"].Value.ToString());
                sum += int.Parse(guna2DataGridView1.Rows[i].Cells["price"].Value.ToString());
            }
            sum_money.Text = sum.ToString();
        }
    }
}
