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
    public partial class Login : Form
    {
        private User user;
        public Login()
        {
            InitializeComponent();
            user = new User();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int accountno = int.Parse(accountNo.Text);
                string pass = password.Text;
                string DB_pass = null;
                bool isMatch = false;

                //Check for Empty Inputs
                if(String.IsNullOrEmpty(accountNo.Text) || String.IsNullOrEmpty(pass))
                {
                    msg.Text = "Fill all the Inputs";
                }
                else
                {
                   var user= DataAccess.Login(accountno);

                    //if the Account Exist
                    if (user != null)
                    {
                        DB_pass = user.Password;
                        pass = Utils.Hash(pass);
                        //matching entered password with the one in the DB
                        isMatch = Utils.Match(DB_pass, pass);

                        //if match Login successfull
                        if (isMatch)
                        {
                            msg.Text = "Login successfull";
                            this.Close();
                            new Forms.Dashboard(accountno).Show();
                        }
                        //Show invalid Login
                        else
                        {
                            msg.Text = "Invalid Credentials";
                        }
                    }
                    //Incase Account Doesnt Exist
                    else
                    {
                        msg.Text = "Invalid Credentials";
                    }     
                }
            }
            catch (FormatException ex)
            {
                msg.Text = ex.Message;
            }
        }

        private void Resend_Click(object sender, EventArgs e)
        {
            new Forms.SignUp().Show();
            this.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Forms.PasswordReset().Show();
        }
    }
}
