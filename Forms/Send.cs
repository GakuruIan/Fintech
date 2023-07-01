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
    public partial class Send : Form
    {
        private decimal Balance;
        private Account account;
        private Account ReciepentAccount;
        private User Reciepent;
        private User user;
        public Send(int accountNo=0)
        {
            InitializeComponent();
            Reciepent = new User();
            user = new User();
            account = new Account();
            ReciepentAccount = new Account();
            if (accountNo != 0)
            {
                account = DataAccess.AccountInfo(accountNo);
                user = DataAccess.Login(accountNo);
                this.Balance = account.Balance;
                amountLabel.Text = account.Balance.ToString();
            }
        }


        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int amount = int.Parse(amountField.Text);
                int receipentAccount = int.Parse(accountField.Text);
                string password = passwordField.Text;
                string encrypted ="";

                if (!String.IsNullOrEmpty(accountField.Text) || !String.IsNullOrEmpty(amountField.Text) || !String.IsNullOrEmpty(passwordField.Text) )
                {
                    Reciepent = DataAccess.UserDetails(receipentAccount);
                    ReciepentAccount = DataAccess.AccountInfo(receipentAccount);
                    encrypted = user.Password;
                    if (Reciepent != null)
                    {
                        if(amount > account.Balance)
                        {
                            MessageBox.Show($"INSUFFIENT FUNDS TO SEND {amount}");
                        }
                        else if(amount <= 0)
                        {
                            MessageBox.Show($"CANNOT SEND  {amount}");
                        }
                        else
                        {
                            password = Utils.Hash(password);
                            if (Utils.Match(encrypted, password))
                            {

                                //updating user balance
                                this.Balance -= amount;
                                DataAccess.UpdateBalance(user.AccountNo,this.Balance);


                                //updating recipent balance
                                 ReciepentAccount.Balance += amount;
                                DataAccess.UpdateBalance(receipentAccount,ReciepentAccount.Balance);

                                //Generating Unique code
                                 string code = Utils.GenerateUniqueCode();

                                //inserting user transfer transcation
                                int row=DataAccess.InsertTranscation(code,"Send",Reciepent.Firstname,user.AccountNo,DateTime.Today,Reciepent.AccountNo);

                                /*
                                                                //To be implemented after Adding ->Senders details to transcation table
                                                                string uniqueCode = Utils.GenerateUniqueCode();
                                                                //inserting Receipent recieve transcation 
                                                                DataAccess.InsertTranscation(uniqueCode,"Recieve","ME",Reciepent.AccountNo,DateTime.Today);
                                */
                                if (Math.Abs(row)==1)
                                {
                                   MessageBox.Show("TRANSFER WAS SUCCESSFUL");
                               }
                            }
                            else
                            {
                                //Incase of incorrect password
                                MessageBox.Show("INCORRECT PASSWORD");
                            }
                        }
                    }
                    else
                    {
                        //Incase of non existant Account
                        MessageBox.Show("ACCOUNT DOESNT EXIST");
                    }
                }
                else
                {
                    //Incase of empty inputs
                    MessageBox.Show("FILL IN ALL INPUTS");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("ONLY NUMBERS ARE ALLOWED");
            }
            finally
            {
                accountField.Text = "";
                amountField.Text = "";
                passwordField.Text = "";
            }
        }
    }
}
