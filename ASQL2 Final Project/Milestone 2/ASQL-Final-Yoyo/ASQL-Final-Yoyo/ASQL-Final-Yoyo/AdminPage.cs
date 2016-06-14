using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASQL_Final_Yoyo
{
    public partial class frmAdminPage : Form
    {
        public frmAdminPage()
        {
            InitializeComponent();
        }

        private void btnBeginTransaction_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtboxDebug1.Text = dateTimePicker1.Value.ToString();
            txtboxDebug2.Text = dateTimePicker1.Text;
            txtboxDebug3.Text = dateTimePicker1.ToString();
        }
    }
}
