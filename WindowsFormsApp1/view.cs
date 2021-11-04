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
    public partial class view : UserControl
    {
        private static view _instance;
        public static view Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new view();
                return _instance;
            }
        }
        public view()
        {
            InitializeComponent();
        }
    }
}
