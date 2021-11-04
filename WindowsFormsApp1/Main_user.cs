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
    public partial class Main_user : Form
    {
        public Main_user()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (!panel14.Controls.Contains(user_1.Instance))
            {
                panel14.Controls.Add(user_1.Instance);
                user_1.Instance.Dock = DockStyle.Fill;
                user_1.Instance.BringToFront();
            }
            else
                user_1.Instance.BringToFront();
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            if (!panel14.Controls.Contains(table_user.Instance))
            {
                panel14.Controls.Add(table_user.Instance);
                table_user.Instance.Dock = DockStyle.Fill;
                table_user.Instance.BringToFront();
            }
            else
                table_user.Instance.BringToFront();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            if (!panel14.Controls.Contains(user_food.Instance))
            {
                panel14.Controls.Add(user_food.Instance);
                user_food.Instance.Dock = DockStyle.Fill;
                user_food.Instance.BringToFront();
            }
            else
                user_food.Instance.BringToFront();
        }

        private void user_food1_Load(object sender, EventArgs e)
        {

        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            if (!panel14.Controls.Contains(My_Bill.Instance))
            {
                panel14.Controls.Add(My_Bill.Instance);
                My_Bill.Instance.Dock = DockStyle.Fill;
                My_Bill.Instance.BringToFront();
            }
            else
                My_Bill.Instance.BringToFront();
        }

        private void user_11_Load(object sender, EventArgs e)
        {

        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            if (!panel14.Controls.Contains(view.Instance))
            {
                panel14.Controls.Add(view.Instance);
                view.Instance.Dock = DockStyle.Fill;
                view.Instance.BringToFront();
            }
            else
                view.Instance.BringToFront();
        }
    }
}
