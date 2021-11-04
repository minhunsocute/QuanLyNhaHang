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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Admin_staff : UserControl
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

        string id_string;


        private static Admin_staff _instance;
        public static Admin_staff Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Admin_staff();
                return _instance;
            }
        }
        public Admin_staff()
        {
            InitializeComponent();
        }

        private void Admin_staff_Load(object sender, EventArgs e)
        {
            LoadData();
            panel4.Hide();
            guna2Button6.Hide();
            LoadComboBox();
        }
        private void LoadData()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "SELECT ID,NAME,DAY_BORN,COUNTRY FROM STAFF";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "ID");
            dt = ds.Tables["ID"];

            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel4.Show();
            guna2Button6.Show();
            if (!panel4.Controls.Contains(Add_staff.Instance))
            {
                panel4.Controls.Add(Add_staff.Instance);
                Add_staff.Instance.Dock = DockStyle.Fill;
                Add_staff.Instance.BringToFront();
            }
            else
                Add_staff.Instance.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            guna2Button6.Hide();
            LoadData();
        }

        private void guna2DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dt.Rows.Count > 0)
            {
                int row = e.RowIndex;
                try
                {
                    id_string = dt.Rows[row]["ID"].ToString();
                    name_textBox.Text = dt.Rows[row]["NAME"].ToString();
                    country_textBox.Text = dt.Rows[row]["COUNTRY"].ToString();
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    comm1 = conn.CreateCommand();
                    comm1.Parameters.AddWithValue("@id", id_string);
                    comm1.CommandText = "SELECT PEOPLE_IMAGE FROM STAFF WHERE ID = @id";
                    SqlDataReader reader = comm1.ExecuteReader();
                    if (reader.Read())
                    {
                        MemoryStream stream = new MemoryStream(reader.GetSqlBytes(0).Buffer);
                        guna2PictureBox1.Image = Image.FromStream(stream);
                        guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    conn.Close();
                    if(id_string == "1")
                    {
                        type_textBox.Text = "Cashier";
                    }
                    else if(id_string == "2")
                    {
                        type_textBox.Text = "Bartender";
                    }
                    else if(id_string == "3")
                    {
                        type_textBox.Text = "Staff";
                    }         
                }
                catch { }
                
            }
        }

        private void LoadComboBox()
        {
            type_textBox.Items.Add("Cashier");
            type_textBox.Items.Add("Bartender");
            type_textBox.Items.Add("Staff");

            type_textBox.Text = "Cashider";
        }

        private void searchValue(string Value)
        {
            conn = new SqlConnection(conStr);
            conn.Open();

            string sqlString = "SELECT ID,NAME,DAY_BORN,COUNTRY FROM STAFF " +
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("DO YOU WANT TO DELETE THIS STAFF", "QUESTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(re == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString = "DELETE FROM STAFF WHERE id ="+id_string;
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("DO YOU WANT CHANGE INFOR STAFF", "QUESTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(re == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                int type_int = 0 ;
                if (type_textBox.Text.ToString() == "Cashier")
                    type_int = 1;
                else if (type_textBox.Text.ToString() == "Bartender")
                    type_int = 2;
                else if (type_textBox.Text.ToString() == "Staff")
                    type_int = 3;
                var image = new ImageConverter().ConvertTo(guna2PictureBox1.Image, typeof(Byte[]));
                comm = conn.CreateCommand();
                comm.Parameters.AddWithValue("@image", image);
                string sqlString = "UPDATE STAFF SET NAME = N'"+name_textBox.Text.ToString()+"', COUNTRY = N'"+country_textBox.Text.ToString()+
                                    "', TYPE_STAF = "+type_int.ToString()+", PEOPLE_IMAGE = @image  WHERE ID = "+id_string;
                comm.CommandText = sqlString;
                comm.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
            
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.FileName = "";
            OD.Filter = "Supported Images |*.jpg;*.jpeg;*.png";
            if (OD.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Load(OD.FileName);
                guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
