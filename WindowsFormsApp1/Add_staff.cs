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
    public partial class Add_staff : UserControl
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        private static Add_staff _instance;
        public static Add_staff Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Add_staff();
                return _instance;
            }
        }
        public Add_staff()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text.ToString() != "" && country_textBox.Text.ToString() != ""&&type_textBox.Text.ToString()!="")
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                int type_int = 0;
                if (type_textBox.Text.ToString() == "Cashier")
                    type_int = 1;
                else if (type_textBox.Text.ToString()== "Bartender")
                    type_int = 2;
                else if (type_textBox.Text.ToString() == "Staff")
                    type_int = 3;

                var image = new ImageConverter().ConvertTo(guna2PictureBox1.Image, typeof(Byte[]));
                comm = conn.CreateCommand();
                comm.Parameters.AddWithValue("@image", image);
                string sqlString = "INSERT INTO STAFF (NAME,DAY_BORN,COUNTRY,TYPE_STAF,PEOPLE_IMAGE) " +
                                  " VALUES (N'"+name_textBox.Text.ToString()+"','"+guna2DateTimePicker1.Text+"',N'"+country_textBox.Text.ToString()+"', " +
                                  ""+type_int.ToString()+",@image)";
                comm.CommandText = sqlString;
                if(comm.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("STAFF WAS INSERTED", "OK", MessageBoxButtons.OK);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("INPUT IS NULL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_staff_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            type_textBox.Items.Add("Cashier");
            type_textBox.Items.Add("Bartender");
            type_textBox.Items.Add("Staff");

            type_textBox.Text = "Cashider";
        }
    }
}
