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
    public partial class Admin_table : UserControl
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;


        private static Admin_table _instance;
        public static Admin_table Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Admin_table();
                return _instance;
            }
        }
        private void LoadTable()
        {
            panel3.Controls.Clear();
            List<Table> tableList = TableInstance.Instance.LoadTableList();
            int n = 1;
            int x = 3; int y = 10;
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = 90, Height = 90 };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Tag = item;
                btn.Font = new Font("Segoe UI", 10);

                if (item.Status == "Empty Table")
                {
                    btn.BackColor = Color.SeaGreen;
                }
                else btn.BackColor = Color.IndianRed;
                btn.Location = new Point(x, y);
                x += 100;
                if (n % 6 == 0)
                {
                    y += 100;
                    x = 3;
                }
                panel3.Controls.Add(btn);
                n++;
            }
        }

        public Admin_table()
        {
            InitializeComponent();
        }

        private void Admin_table_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void add_bill_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "EXEC INSER_TABLE";
            comm = new SqlCommand(sqlString, conn);
            comm.ExecuteNonQuery();
            LoadTable();
            conn.Close();
        }
    }
}
