using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fintech.Forms
{
    public partial class ConfirmationBox : Form
    {
        public ConfirmationBox(string info, string message=null)
        {
            InitializeComponent();
            content.Text = info;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
