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
    public partial class Edit : Form
    {
        private User user;
        private User temp;
        private int ID;
        private string DBpassword = null;
        public Edit(int id = 0)
        {
            InitializeComponent();
            if (id != 0)
            {
                this.ID = id;
                user = DataAccess.UserDetails(this.ID);
                temp = DataAccess.Login(this.ID);
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            firstname.Text = this.user.Firstname;
            lastname.Text = user.Lastname;
            nationalID.Text = user.NationalID.ToString();
            residence.Text = user.Residence;
            branch.Text = user.Branch;
        }
       

        private async void UpdateAccount_Click(object sender, EventArgs e)
        {
            int row;
            try
            {
                //check the neccesary inputs are not empty
                if (!String.IsNullOrEmpty(firstname.Text) || !String.IsNullOrEmpty(lastname.Text) ||
                     !String.IsNullOrEmpty(residence.Text) ||
                   !String.IsNullOrEmpty(branch.Text))
                {
                    //Updating the user info
                    row = await DataAccess.UpdateUser(firstname.Text, lastname.Text, int.Parse(nationalID.Text), residence.Text, branch.Text, user.AccountNo);
                    if (Math.Abs(row) == 1)
                    {
                        //Show message for successfull update
                        MessageBox.Show("PROFILE UPDATED SUCCESSFULLY");
                    }
                    else
                    {
                        MessageBox.Show("COULD NOT UPDATE PROFILE");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill all the necessary inputs");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter the Correct Format");
                throw;
            }
        }

        private void Resend_Click(object sender, EventArgs e)
        {
            new Forms.PasswordReset().Show();
        }
    }
}

