using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fintech
{
    public partial class Form1 : Form
    {
  
        public Form1()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            loader.Width += 3;
            if(loader.Width >= 762)
            {
                timer1.Stop();
                new Forms.Login().Show();
                this.Hide();
            }
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
