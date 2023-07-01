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
    public partial class Dashboard : Form
    {
        private Form activeForm;
        private User user;
        private Account account;
        private int Account;

        public  Dashboard(int accountNo=0)
        {
            InitializeComponent();
            user = new User();
            account = new Account();
            if (accountNo != 0)
            {
                Account = accountNo;
                user = DataAccess.UserDetails(accountNo);
                greetings.Text = $"Hello {user.Fullname}";
            }
            else
            {
                //Dont Open form Code here
            }

        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Contentpanel.Controls.Add(childForm);
            this.Contentpanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            new Forms.Deposit(balance,Account).Show();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Loan(this.Account));
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            new Forms.Withdrawal(balance,this.Account).Show();
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            new Forms.Send(this.Account).Show();
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            account = DataAccess.AccountInfo(this.Account);
            balance.Text = account.Balance.ToString();
            myBalance.Text = account.Balance.ToString();
            dataBox.DataSource = await DataAccess.FetchTranscations(this.Account);
        }

        private void gunaAdvenceButton5_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Forms.Edit(this.Account));
        }

    }
}
