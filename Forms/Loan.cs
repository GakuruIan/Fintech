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
    public partial class Loan : Form
    {
        private int AccountNo;
        private User user=null;
        public Loan(int accountNo=0)
        {
            InitializeComponent();
            if(accountNo != 0)
            {
                AccountNo = accountNo;
                user = new User();
            }
          
        }

        private void Loan_Load(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = granteeName.Text;
                int GranteeID = int.Parse(granteeID.Text);
                int GranteeAcc = int.Parse(granteeAcc.Text);
                int GranteePhno = int.Parse(granteePhNo.Text);
                decimal Amount = int.Parse(amount.Text);
                string Assets = assets.Text;
                int row = 0;
                if (!String.IsNullOrEmpty(granteeName.Text) || !String.IsNullOrEmpty(granteeID.Text) || !String.IsNullOrEmpty(granteeAcc.Text) || !String.IsNullOrEmpty(granteePhNo.Text) || !String.IsNullOrEmpty(amount.Text) || !String.IsNullOrEmpty(assets.Text) )
                {
                
                    // Confirm the grantee details
                    user = DataAccess.UserDetails(GranteeAcc);
                    if (user != null)
                    {
                        //Verification of Grantee info
                        if((name.CompareTo(user.Fullname) == 0) || GranteeID == user.NationalID)
                        {
                            //Add to database
                           row=DataAccess.InsertIntoLoan(AccountNo,Amount,DateTime.Today,"Pending",GranteeAcc,name,GranteeID,GranteePhno,Assets);
                            if (Math.Abs(row) == 1)
                            {
                                //Successful messages
                                MessageBox.Show("LOAN APPLICATION SUCCESSFULL!!");
                            }
                            else
                            {
                                //Error message
                                MessageBox.Show("AN ERROR OCCURED");
                            }
                        }
                        else
                        {
                            //Invalid grantee Information given 
                            MessageBox.Show("INVALID GRANTEE INFORMATION GIVEN");
                        }
                    }
                    else
                    {
                        //Incase the Grantee doesnt exist
                        MessageBox.Show("PLEASE FILL IN ALL INPUTS");
                    }
                }
                else
                {
                    //Empty Inputs
                    MessageBox.Show("PLEASE FILL IN ALL INPUTS");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("PLEASE ENTER THE CORRECT FORMAT");      
            }
            finally
            {
                granteeName.Text="";
                granteeID.Text="";
                granteeAcc.Text="";
                granteePhNo.Text="";
                amount.Text="";
                assets.Text="";
            }
        }
    }
}
