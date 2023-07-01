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
    public partial class Deposit : Form
    {
        private decimal Amount;
        private int AccountNo;
        private Account account;
        protected Label Balance;

        public Deposit(Label balance,int accountNo=0)
        {
            account = new Account();
            this.Balance = balance;

            InitializeComponent();
            if (accountNo != 0)
            {
                account = DataAccess.AccountInfo(accountNo);
                AccountNo = accountNo;
                Amount = account.Balance;
               
                amountLabel.Text = $"{account.Balance.ToString()}";
            }
           
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                decimal deposit = int.Parse(amount.Text);
                deposit += Amount;
                if (!String.IsNullOrEmpty(amount.Text))
                {

                   //Updating account info
                    DataAccess.UpdateBalance(AccountNo,deposit);

                    //generating unique TranscationID
                    string TranscationID = Utils.GenerateUniqueCode();
                    string type = "Deposit";
                    string recipent = "ME";

                    
                    //inserting to Transcation table
                    int row=DataAccess.InsertTranscation(TranscationID,type,recipent,AccountNo,DateTime.Today);
                }
                else
                {
                    MessageBox.Show("Amount Cant be Empty");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Only Numbers are allowed");
            }
            finally
            {
                var newBalance = DataAccess.UserBalance(this.AccountNo);
                amount.Text = "";
                this.Close();
                Console.WriteLine($"new balance { newBalance }");
                Balance.Text =  newBalance.ToString();
            }
        }
    }
}
