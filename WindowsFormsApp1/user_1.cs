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
    public partial class user_1 : UserControl
    {
        private static user_1 _instance;
        public static user_1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new user_1();
                return _instance;
            }
        }
        public user_1()
        {
            InitializeComponent();
        }
    }
}
