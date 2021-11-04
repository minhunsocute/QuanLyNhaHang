using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Addmin_form : Form
    {
        private static Addmin_form _instance;

        public static Addmin_form Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Addmin_form();
                return _instance;
            }
        }
        public Addmin_form()
        {
            InitializeComponent();
        }

        private void Addmin_form_Load(object sender, EventArgs e)
        {
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Admin_food.Instance))
            {
                panel2.Controls.Add(Admin_food.Instance);
                Admin_food.Instance.Dock = DockStyle.Fill;
                Admin_food.Instance.BringToFront();
            }
            else
                Admin_food.Instance.BringToFront();
        }
        

        private void siticoneButton1_CheckedChanged(object sender, EventArgs e)
        {
           // if (siticoneButton1.Checked)Admin_Revenue.Instance.BringToFront();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Admin_Revenue.Instance))
            {
                panel2.Controls.Add(Admin_Revenue.Instance);
                Admin_Revenue.Instance.Dock = DockStyle.Fill;
                Admin_Revenue.Instance.BringToFront();
            }
            else
                Admin_Revenue.Instance.BringToFront();
        }

        private void siticoneButton2_CheckedChanged(object sender, EventArgs e)
        {
          //  if (siticoneButton2.Checked) Admin_food.Instance.BringToFront();
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Admin_table.Instance))
            {
                panel2.Controls.Add(Admin_table.Instance);
                Admin_table.Instance.Dock = DockStyle.Fill;
                Admin_table.Instance.BringToFront();
            }
            else
                Admin_table.Instance.BringToFront();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Category.Instance))
            {
                panel2.Controls.Add(Category.Instance);
                Category.Instance.Dock = DockStyle.Fill;
                Category.Instance.BringToFront();
            }
            else
                Category.Instance.BringToFront();
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Admin_account.Instance))
            {
                panel2.Controls.Add(Admin_account.Instance);
                Admin_account.Instance.Dock = DockStyle.Fill;
                Admin_account.Instance.BringToFront();
            }
            else
                Admin_account.Instance.BringToFront();
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Admin_staff.Instance))
            {
                panel2.Controls.Add(Admin_staff.Instance);
                Admin_staff.Instance.Dock = DockStyle.Fill;
                Admin_staff.Instance.BringToFront();
            }
            else
                Admin_staff.Instance.BringToFront();
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Admin_bill.Instance))
            {
                panel2.Controls.Add(Admin_bill.Instance);
                Admin_bill.Instance.Dock = DockStyle.Fill;
                Admin_bill.Instance.BringToFront();
            }
            else
                Admin_bill.Instance.BringToFront();
        }
    }
}
