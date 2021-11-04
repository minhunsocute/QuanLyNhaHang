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
    public partial class Admin_Revenue : UserControl
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

        private static Admin_Revenue _instance;
        public static Admin_Revenue Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Admin_Revenue();
                return _instance;
            }
        }

        public Admin_Revenue()
        {
            InitializeComponent();
        }

        private void Admin_Revenue_Load(object sender, EventArgs e)
        {
            LoadDataforChart2();
            LoadForChart1();
        }
        //Load data for Chart 2
        private void LoadDataforChart2()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            for (int i = 1; i <= 12; i++)
            {
                int cost = 0;
                string sqlString = "EXEC RETURN_SUMREVENUE '" + i.ToString() + "','" + price_text.Value.ToString() + "'";
                myAdapter = new SqlDataAdapter(sqlString, conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "S");
                dt = ds.Tables["S"];
                try
                {
                    cost = int.Parse(dt.Rows[0]["S"].ToString());
                    chart2.Series["month"].Points.AddXY(i.ToString(), cost);
                }
                catch { }
            }
            conn.Close();
        }
        // Load data for chart 1
        private void LoadForChart1()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString_year = "SELECT DISTINCT YEAR(DATECHECKOUT) AS Y FROM BILL";
            myAdapter = new SqlDataAdapter(sqlString_year, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "Y");
            dt = ds.Tables["Y"];
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                int year_prirce = 0;
                for(int j = 1; j <= 12; j++)
                {
                    int cost = 0;
                    string sqlString = "EXEC RETURN_SUMREVENUE '" + j.ToString() + "','" + dt.Rows[i]["Y"].ToString() + "'";
                    myAdapter1 = new SqlDataAdapter(sqlString, conn);
                    ds1 = new DataSet();
                    myAdapter1.Fill(ds1, "S");
                    dt1 = ds1.Tables["S"];

                    try
                    {
                        cost = int.Parse(dt1.Rows[0]["S"].ToString());
                        year_prirce += cost;
                    }
                    catch { }
                }
                chart1.Series["year"].Points.AddXY(dt.Rows[i]["Y"].ToString(), year_prirce);
                if (i == 1) id_textBox.Text = year_prirce.ToString();
            }
            conn.Close();                              
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            for(int i = 1; i <= 12; i++)
            {
                chart2.Series["month"].Points.Clear();
            }
            //chart2.Series.Clear();
            LoadDataforChart2();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
