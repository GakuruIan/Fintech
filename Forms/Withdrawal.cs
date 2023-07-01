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
    public partial class Withdrawal : Form
    {
        private Account account;
        private User user;
        private decimal Balance;
        protected Label BalanceLabel;
        private int accountNo;

        public Withdrawal(Label balance,int accountNo=0)
        {
            InitializeComponent();
            user = new User();
            if (accountNo != 0)
            {
                this.accountNo = accountNo;
                this.BalanceLabel = balance;
                this.account = DataAccess.AccountInfo(accountNo);
                user = DataAccess.Login(accountNo);
                this.Balance = account.Balance;
                amountLabel.Text = this.Balance.ToString();
            }
            //Exit Code
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int amount = int.Parse(amountField.Text);
                string password = Utils.Hash(passwordField.Text);
                string encrypted = user.Password;
                bool isMatch = false;

                isMatch = Utils.Match(encrypted, password);
            if(!String.IsNullOrEmpty(amountField.Text) || !String.IsNullOrEmpty(passwordField.Text))
            {
                isMatch = Utils.Match(encrypted,password);
               if (isMatch)
               {
                   if (amount > this.Balance)
                   {
                       MessageBox.Show("INSUFFICENT FUNDS");
                   }
                        else if (amount < 50)
                        {
                            MessageBox.Show("Cannot Withdraw less than 50 shillings");
                        }
                   else
                   {
                       this.Balance -= amount;
                        //updating balance in DB
                       DataAccess.UpdateBalance(account.AccountNo, this.Balance);
                            //confirmation box
                       new ConfirmationBox($"Confirm Withdrawal of {amount}").Show();

                       //generating unique code
                            string code = Utils.GenerateUniqueCode();

                        //insert into transcation table
                            int row=DataAccess.InsertTranscation(code,"withdrawal","ME", account.AccountNo,DateTime.Today);

                            if (Math.Abs(row) == 1)
                            {
                                MessageBox.Show("Withdrawal Successful");
                                BalanceLabel.Text = DataAccess.UserBalance(this.accountNo).ToString();
                            }
                     }
               }
                 else
                  {
                   MessageBox.Show("INVALID PASSWORD PROVIDED");
                  }
              }
           else
           {
               MessageBox.Show("FILL IN ALL INPUTS");
           }
       }
            catch (FormatException)
            {
                throw;
            }
            finally
            {
                amountField.Text = "";
                passwordField.Text = "";
                this.Close();
            }
        }
    }
}
