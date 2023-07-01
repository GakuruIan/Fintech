using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Fintech
{
    public class DataAccess
    {
        //Creating An Account
        public static int CreateAccount(string firstname, string lastname, string email, string password, int nationalID, string residence, string branch, int accountNo, DateTime createDate)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                var output = 0;
                try
                {
                List<User> user = new List<User>();

                user.Add(new User { Firstname = firstname, Lastname = lastname, Email = email, Password = password, NationalID = nationalID, Residence = residence, Branch = branch, AccountNo = accountNo, create_Date = createDate });

                output=connection.Execute("dbo.STP_Create_User  @Firstname,@Lastname,@Email,@Password,@NationalID, @Residence,@Branch,@AccountNo,@create_Date", user);

                }
                catch (SqlException e)
                {
                    if (e.Message.Contains("email_un"))
                    {
                        MessageBox.Show("THAT EMAIL ALREADY EXISTS KINDLY USE ANOTHER ONE");
                    }
                    if (e.Message.Contains("national_un"))
                    {
                        MessageBox.Show("THE NATIONAL ID IS ALREADY REGISTERED");
                    }
                }
                return output;
            }
        }

        //For Login the user in
        public static User Login(int accountNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                var output = connection.QuerySingleOrDefault<User>("dbo.STP_Login @AccountNo", new { AccountNo = accountNo });
                return output;
            }
        }

        //Fetching User Data
        public static User UserDetails(int accountNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                return connection.QuerySingleOrDefault<User>("dbo.STP_UserDetails @AccountNo", new { AccountNo = accountNo });
            }
        }

        //Fetching users balance
        public static int UserBalance(int accountNo = 0)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
              
                try
                {
                    return connection.QuerySingleOrDefault<int>("[dbo].[STP_GetUserBalance] @AccountNo", new { AccountNo = accountNo });
                }
                catch (SqlException sp)
                {
                    throw sp;
                }
                
            }
        }

        //Adding reset code to Database passwordreset
        public async static Task<int> InsertResetCode(string code,int accountNo,string updateAt,DateTime codeExpiration)
        {

            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB"))) {
                {
                    var output = 0;
                    try
                    {
                        output = await Task.Run(() => connection.ExecuteAsync("[dbo].[STP_ADD_PASSWORDRESET]  @Code,@AccountNo,@Updated_At,@CodeExpiration", new { Code =code, AccountNo = accountNo, Updated_At = updateAt,CodeExpiration =codeExpiration }));
                    }
                    catch (SqlException sp)
                    {
                        Console.WriteLine(sp.Message);
                        throw sp;
                    }
                    return output;
                } }
        }

        //Update Reset code 
        public async static Task<int> UpdateResetCode(DateTime updatedAt,int Isused,int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                try
                {
                    return await Task.Run(() => connection.ExecuteAsync("[dbo].[STP_UPDATEPASSWORDRESET] @Updated_At,@Isused ,@id", new {Updated_At =updatedAt, Isused = Isused ,id =id }));
                }
                catch (SqlException sp)
                {

                    throw sp;
                }
            }
        }

        //Delete code in the event off an error
        public async static Task<int> DeleteCode(int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                try
                {
                    return await Task.Run(() => connection.ExecuteAsync("[dbo].[STP_DeleteResetCode] @id", new { id = id }));

                }
                catch (SqlException sp)
                {
                    throw sp;
                }
            }
        } 

        //update Password
        public async static Task<int> UpdatePassword(string password,int accountNo) 
         {
                using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
                {
                    try
                    {
                     return await Task.Run(() => connection.ExecuteAsync("[dbo].[STP_UpdatePassword] @Password, @AccountNo", new {Password = password, AccountNo = accountNo }));
                    }
                    catch (SqlException sp)
                    {
                        Console.WriteLine(sp.Message);
                        throw sp;
                    }
                }
        } 

        //Fetching Reset code
        public static ResetCode FetchResetCode(string code)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                try
                {
                    return connection.QuerySingleOrDefault<ResetCode>("[dbo].[STP_GETRESETCODE] @Code", new { Code = code });
                }
                catch (SqlException sp)
                {
                    throw sp;
                }
            }
        }

        //Update User information
        public async static Task<int> UpdateUser(string firstname, string lastname, int nationalID, string residence, string branch, int accountNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                var output = 0;
                try
                {
                      output = await Task.Run(()=>connection.ExecuteAsync("[dbo].[STP_UpdateUser]  @Firstname,@Lastname,@NationalID,@Residence,@Branch,@AccountNo", new { Firstname = firstname, Lastname = lastname, NationalID = nationalID, Residence = residence, Branch = branch, AccountNo = accountNo }));
                }
                catch (SqlException sp)
                {
                    Console.WriteLine(sp.Message);
                    throw sp;
                }
                return output;
            }
        }


        //inserting transcation
        public static int InsertTranscation(string transactionId,string type,string reciepentName,int accountNo,DateTime transcationDate, int reciepentAcc = 0)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                List<Transcation> transcation = new List<Transcation>();
                transcation.Add(new Transcation{ TranscationID = transactionId, TranscationType=type, Reciepent_Name=reciepentName, Reciepent_Acc=reciepentAcc, AccountNo=accountNo, Transcation_Date=transcationDate });

                return connection.Execute("[dbo].[STP_InsertTranscation]  @TranscationID ,@TranscationType,@Reciepent_Name,@Reciepent_Acc,@AccountNo,@Transcation_Date",transcation);
            }
        }
       //updating Account balance
       public static int UpdateBalance(int accountNo,decimal balance)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                return connection.Execute("[dbo].[STP_UpdateBalance] @AccountNo,@Balance",new { AccountNo =accountNo,Balance=balance});  
            }
        }

        //Get Account Info
        public static Account AccountInfo(int Account)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                return connection.QuerySingleOrDefault<Account>("[dbo].[STP_GetAccountInfo] @AccountNo", new { AccountNo = Account });
            }
        }

        //insert into Account
        public static int InsertIntoAccounts(int accountNo,int balance)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
            {
                List<Account> account = new List<Account>();
                account.Add(new Account { AccountNo = accountNo, Balance = balance });
                return connection.Execute("STP_InsertToAccount @AccountNo,@Balance", account);
            }

         }

        //Insert into loan
        public static int InsertIntoLoan(int accountNo, decimal amount, DateTime application,string approvedState,int granteeAcc, string name, int granteeID, int Phno, string asset,int approvedby = 0,string st="Not Approved")
        {
            int output = 0;
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
                {
                    List<Loan> loan = new List<Loan>();
                    loan.Add(new Loan { AccountNo = accountNo, Amount = amount, Application_Date = application, ApprovedBy = approvedby, Approved_State = approvedState, Grantee_Name = name, Grantee_ID = granteeID, Grantee_AccountNo = granteeAcc, Grantee_PhoneNO = Phno, state = st, Assets = asset });

                    output=connection.Execute("STP_InsertLoan @AccountNo,@Amount,@Application_Date,@ApprovedBy,@Approved_State,@Grantee_Name,@Grantee_ID,@Grantee_AccountNo,@Grantee_PhoneNO,@state,@Assets", loan);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }

        //Fetching all transcations
        public async static Task<List<Transcation>> FetchTranscations(int accountNo=0)
        {
            List<Transcation> transcations = new List<Transcation>();
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("fintechDB")))
                {
                    if (accountNo==0)
                    {
                        //Fetch all transcations
                        transcations =   await Task.Run(() => connection.Query<Transcation>("[dbo].[STP_GetAllTranscations]").ToList());
                    }
                    else
                    {
                        //Fetch specific Transcation of a given Account
                        transcations = await Task.Run(() => connection.Query<Transcation>("[dbo].[STP_GetAccountTranscations] @AccountNo", new Transcation {AccountNo =accountNo }).ToList());
                    }
                   
                }
               
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return transcations;
        }
    }

}