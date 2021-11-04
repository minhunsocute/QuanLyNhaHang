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
    public partial class Admin_bill : UserControl
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

        private static Admin_bill _instance;
        public static Admin_bill Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new Admin_bill();
                return _instance;   
            }
        }
        public Admin_bill()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            int type_bill=0;
            if (category_textBox.Text.ToString() == "Paid")
            {
                type_bill = 1;
            }
            else if (category_textBox.Text.ToString() == "UnPaid")
            {
                type_bill = 0;
            }
            else if (category_textBox.Text.ToString() == "Ship")
            {
                type_bill = 2;
            }
            string sqlString = "SELECT ID,DATECHECKIN,DATECHECKOUT,STATUS FROM BILL WHERE STATUS = " + type_bill.ToString() +
                                    " AND DATECHECKIN BETWEEN '" + guna2DateTimePicker1.Text + "' AND '" + guna2DateTimePicker2.Text + "'";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "ID");
            dt = ds.Tables["ID"];
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }

        private void LoadData1() {
            conn = new SqlConnection(conStr);
            conn.Open();
            string SqlString = "SELECT ID , IDFOOD,COUNT_NUMBER FROM BILL_INFO WHERE IDBILL =" + id_textBox.Text.ToString();
            myAdapter1 = new SqlDataAdapter(SqlString, conn);
            ds1 = new DataSet();
            myAdapter1.Fill(ds1, "ID");
            dt1 = ds1.Tables["ID"];
            guna2DataGridView2.DataSource = dt1;
            conn.Close();   
        }

        private void LoadComboBox()
        {
            category_textBox.Items.Add("Paid");
            category_textBox.Items.Add("UnPaid");
            category_textBox.Items.Add("Ship");
            category_textBox.Text = "Paid";
        }
        private void Admin_bill_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadData();
        }

        private void guna2DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                int row = e.RowIndex;
                try {
                    id_textBox.Text = dt.Rows[row]["ID"].ToString();
                    in_textBox.Text = dt.Rows[row]["DATECHECKIN"].ToString();
                    out_textBox.Text = dt.Rows[row]["DATECHECKOUT"].ToString();
                    LoadData1();
                }
                catch { }
            }
        }

        private void category_textBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
