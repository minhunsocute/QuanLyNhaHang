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
    public partial class Main_mana : Form
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        private SqlDataAdapter myAdapter1;
        private DataSet ds1;
        private DataTable dt1;

        List<Button> button_list;
        int id_table = 0;
        public Main_mana()
        {
            InitializeComponent();
            LoadComboBox();
            LoadTable();
            
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Addmin_form f = new Addmin_form();
            f.ShowDialog();
            LoadComboBox();
            LoadTable();
        }

        private void LoadComboBox()
        {
            category_textBox.Items.Clear();
            conn = new SqlConnection(conStr);
            conn.Open();
            string[] category_string = new string[500];
            string sqlString = "SELECT NAME FROM FOOD_CATEGORY";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "NAME");
            dt = ds.Tables["NAME"];
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                category_textBox.Items.Add(dt.Rows[i]["NAME"].ToString());
            }
            if(dt.Rows.Count != 0)
            {
                category_textBox.Text = dt.Rows[0]["NAME"].ToString();
            }
            conn.Close();
        }

        private void food_textBox_Click(object sender, EventArgs e)
        {
            food_textBox.Items.Clear();
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "EXEC SELECT_FOODINMAIN '" + category_textBox.Text.ToString() + "'";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "NAME");
            dt = ds.Tables["NAME"];

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                food_textBox.Items.Add(dt.Rows[i]["NAME"].ToString());
            }

            if(dt.Rows.Count != 0)
            {
                food_textBox.Text = dt.Rows[0]["NAME"].ToString();
            }
            conn.Close();
        }
        
        void showDiaLog(int id)
        {
            table_textBox.Text = "Table " + id.ToString();
            id_table = id;
            LoadDataGridView(id);
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString1 = "SELECT TOP(1) ID FROM BILL WHERE STATUS = 0 AND IDTABLE = " + id_table.ToString();
            myAdapter = new SqlDataAdapter(sqlString1, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "ID");
            dt = ds.Tables["ID"];
            if (dt.Rows.Count != 0) 
                add_bill.Hide();
            else
                add_bill.Show();
            conn.Close();
        }
        private void LoadDataGridView(int id)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "EXEC SELECT_BILL " + id.ToString();
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
            conn.Close();
        }
        void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            showDiaLog(tableID);
        }
        private void LoadTable()
        {
            panel3.Controls.Clear();
            List<Table> tableList = TableInstance.Instance.LoadTableList();
            button_list = new List<Button>();
            int n = 1;
            int x = 35;int y = 10;
            int i = 1;
            foreach(Table item in tableList)
            {
                if (i != 19 )
                {
                    Button btn = new Button() { Width = 90, Height = 90 };
                    btn.Text = item.Name + Environment.NewLine + item.Status;
                    btn.Click += Btn_Click;
                    btn.Tag = item;
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
                        x = 35;
                    }
                    panel3.Controls.Add(btn);
                    button_list.Add(btn);
                    n++;
                }
                i++;
            }   
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (food_textBox.Text.ToString() != "")
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString1 = "SELECT TOP(1) ID FROM BILL WHERE STATUS = 0 AND IDTABLE = "+id_table.ToString();
                myAdapter = new SqlDataAdapter(sqlString1,conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "ID");
                dt = ds.Tables["ID"];
                if(dt.Rows.Count != 0)
                {
                    add_bill.Hide();
                    string sqlString3 = "SELECT TOP(1) ID FROM FOOD WHERE NAME = N'"+food_textBox.Text.ToString()+"'";
                    myAdapter1 = new SqlDataAdapter(sqlString3, conn);
                    ds1 = new DataSet();
                    myAdapter1.Fill(ds1, "ID");
                    dt1 = ds1.Tables["ID"];
                    string sqlString2 = "EXEC INSERT_TOBILLINFO " + dt.Rows[0]["ID"].ToString() +", "+dt1.Rows[0]["ID"].ToString()+", "+price_text.Value.ToString();
                    comm = new SqlCommand(sqlString2, conn);
                    comm.ExecuteNonQuery();
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("FOOD NAME IS NULL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDataGridView(id_table);
        }

        private void paybutton_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "EXEC UPDATE_BILL " +id_table.ToString();
            comm = new SqlCommand(sqlString, conn);
            comm.ExecuteNonQuery();

            LoadTable();
            LoadDataGridView(id_table);
            conn.Close();
        }

        private void add_bill_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString3 = "EXEC INSERT_TOBILL " + id_table.ToString();
            comm = new SqlCommand(sqlString3, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            LoadTable();
        }
        
        private void Main_mana_Load(object sender, EventArgs e)
        {
            add_bill.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            setting f = new setting();
            f.ShowDialog();
        }
    }
}
