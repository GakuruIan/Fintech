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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void createAccount_Click(object sender, EventArgs e)  
        {
            try
            {
                string fname = firstname.Text;
                string lname = lastname.Text;
                string Email = email.Text;
                int NationalID = int.Parse(nationalID.Text);
                string Residence = residence.Text;
                string Branch = branch.Text;
                string Password = password.Text;
                string confirmation = confirmPassword.Text;

                //Checking for Empty Inputs
                if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname)
                    || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(nationalID.Text)
                    || string.IsNullOrEmpty(Residence) || string.IsNullOrEmpty(Branch)
                    || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(confirmation))
                {
                    MessageBox.Show("PLEASE FILL IN ALL FIELDS");
                }
                else
                {
                    //Matching the two password
                    if ((Password.CompareTo(confirmation)) == 0)
                    {
                        string hashedpass = Utils.Hash(Password);
                        int AccountNo = Utils.GenerateUniqueID();
                        var row = DataAccess.CreateAccount(fname,lname,Email,hashedpass,NationalID,Residence,Branch,AccountNo,DateTime.Today);
                       
                        if(Math.Abs(row) == 1)
                        {
                           bool result = await Utils.MailAccountNo(Email,fname,AccountNo);
                            if (result)
                            {
                                MessageBox.Show("ACCOUNT CREATED SUCCESSFULLY!!. CHECK EMAIL FOR ACCOUNT NUMBER");
                            }
                            DataAccess.InsertIntoAccounts(AccountNo, 0);
                            this.Close();
                            new Login().Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("PASSWORD DONT MATCH");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter Validation format for the Input");
            }
            finally
            {
                firstname.Text = "";
                lastname.Text = "";
                email.Text = "";
                nationalID.Text = "";
                residence.Text = "";
                branch.Text = "";
                password.Text = "";
                confirmPassword.Text = "";
            }

        }
    }
}
