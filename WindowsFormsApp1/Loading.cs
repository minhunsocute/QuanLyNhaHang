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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Left += 2;
            if (panel2.Left > 315)
            {
                panel2.Left = 100;
            }
            if (panel2.Left < 0)
            {
                panel2.Left = 315;
            }
        }
    }
}
