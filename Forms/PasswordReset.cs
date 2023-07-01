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
    public partial class PasswordReset : Form
    {
        private User user;
        private ResetCode resetCode;
        public PasswordReset()
        {
            InitializeComponent();
            user = null;
            resetCode = null;
        }

        private void VerifyCode_Click(object sender, EventArgs e)
        {
           resetCode = DataAccess.FetchResetCode(resetcode.Text);
           
            //checks if code exists
            if(resetCode != null)
            {
                //checks if the valid code is used
                if(resetCode.Isused == 0)
                {
                    //checks if the code has expired
                    if (DateTime.Now > resetCode.CodeExpiration)
                    {
                        Codemsg.Text = "Reset code has expired";
                    }
                    //if code hasnt expired
                    else
                    {
                        newPassword.Enabled = true;
                        confirmPassword.Enabled = true;
                        Submit.Enabled = true;
                    }
                }
                //code has already been used
                else
                {
                    Codemsg.Text = "Reset code Already used";
                }
                
            }
            //code provided is wrong
            else
            {
                Codemsg.Text = "Invalid Code Given";
            }
        }

        private async void SendAccount_Click_1(object sender, EventArgs e)
        {
            int AccountNo = int.Parse(accountNo.Text);

            msg.Text = "Processing...";
            user = DataAccess.UserDetails(AccountNo);


            if (user != null)
            {

                string reset_Code = Utils.GenerateResetCode();

                DateTime currentTime = DateTime.Now;

                DateTime codeExpiration = currentTime.AddMinutes(5);

                int row = await DataAccess.InsertResetCode(reset_Code, user.AccountNo, null, codeExpiration);

                if (Math.Abs(row) == 1)
                {
                    bool is_Success = await Utils.MailResetCode(user.Email, user.Firstname, reset_Code);

                    //if the email is sent successfully;
                    if (is_Success)
                    {
                        resetcode.Enabled = true;
                        VerifyCode.Enabled = true;
                        msg.Text = "Reset Code is sent to your Email";
                    }
                    else
                    {
                        await DataAccess.DeleteCode(resetCode.id);
                        MessageBox.Show("An error occurred Try again Later, If this keeps happenning, kindly Contact us through this 0700 000 000");
                    }
                }
                else
                {
                    MessageBox.Show("An Error Occurred");
                }

            }
            else
            {
                msg.Text = "Invalid Credentials";
            }
        }

        private async void Submit_Click(object sender, EventArgs e)
        {
            string newpassword = newPassword.Text;
            string confirmpassword = confirmPassword.Text;

            if ( !String.IsNullOrEmpty(newpassword) && !String.IsNullOrEmpty(confirmpassword))
            {
                if (newpassword.Equals(confirmpassword))
                {
                    newpassword = Utils.Hash(newpassword);

                    //fix this datatype error
                   int row = await DataAccess.UpdatePassword(newpassword,int.Parse(accountNo.Text));

                    if(Math.Abs(row) == 1)
                    {
                        Console.WriteLine($"Reset ID :{resetCode.id}");

                        int update = await DataAccess.UpdateResetCode(DateTime.Now,1,resetCode.id);
                        MessageBox.Show("Password Updated");

                        this.Close();

                        new Forms.Login().Show();
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }
                }
                else
                {
                    passwordmsg.Text = "Password don't match";
                }
            }
            passwordmsg.Text = "Fill all inputs";
        }
    }
}
