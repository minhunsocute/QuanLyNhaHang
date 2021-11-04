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
    public partial class table_user : UserControl
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        private static table_user _instance;
        public static table_user Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new table_user();
                return _instance;
            }
        }
        public table_user()
        {
            InitializeComponent();
            LoadTable();
        }
        void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            table_textBox.Text = tableID.ToString();
        }

        private void LoadTable()
        {
            panel3.Controls.Clear();
            List<Table> tableList = TableInstance.Instance.LoadTableList();
            int n = 1;
            int x = 3; int y = 10;
            int i = 1;
            foreach (Table item in tableList)
            {
                if (i != 19)
                {
                    Button btn = new Button() { Width = 90, Height = 90 };
                    btn.Text = item.Name + Environment.NewLine + item.Status;
                    btn.Tag = item;
                    btn.Click += Btn_Click;
                    btn.Font = new Font("Segoe UI", 10);

                    if (item.Status == "Empty Table")
                    {
                        btn.BackColor = Color.SeaGreen;
                    }
                    else btn.BackColor = Color.IndianRed;
                    btn.Location = new Point(x, y);
                    x += 100;
                    if (n % 4 == 0)
                    {
                        y += 100;
                        x = 3;
                    }
                    panel3.Controls.Add(btn);
                    n++;
                }
                i++;
            }
        }

        private void paybutton_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString3 = "EXEC INSERT_TOBILL " + table_textBox.Text.ToString();
            comm = new SqlCommand(sqlString3, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            LoadTable();
        }
    }

}
