using System;
using System.Threading.Tasks;
using shortid;
using shortid.Configuration;
using BotCrypt;
using EmailValidation;
using IdGen;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Net;
using FluentEmail.Core;
using System.Text;
using FluentEmail.Razor;
using System.Configuration;

namespace Fintech
{
    public static class Utils
    {
        //Validating user email
        public static bool EmailValidation(string email)
        {
            bool isValid = false;
            email = email.Trim();
            EmailValidator emailValidator = new EmailValidator();
            EmailValidationResult result;
            if(!emailValidator.Validate(email,out result))
            {
                Console.WriteLine("Unable to check email");
            }
            switch (result)
            {
                case EmailValidationResult.OK:
                    isValid = true;
                    break;
                case EmailValidationResult.InvalidFormat:
                    Console.WriteLine("INVALID FORMAT");
                    break;
                case EmailValidationResult.DomainNotResolved:
                    Console.WriteLine("DOMAIN NOT RESOLVED");
                    break;
                case EmailValidationResult.AddressIsEmpty:
                    Console.WriteLine("INVALID ADDRESS IS EMPTY");
                    break;
                case EmailValidationResult.MailboxUnavailable:
                    Console.WriteLine("MAILBOX IS UNAVAILABLE");
                    break;
            }
            return isValid;
        }
        //Hashing Password
        public static string Hash(string password)
        {
            String EncryptedPassword = Crypter.Sha256Hash(password);
            return EncryptedPassword;
        }

        //Matching passwords
        public static bool Match(string encrypted,string password)
        {   
            return Crypter.Equals(encrypted, password);
        }

        //Generating Unique Code for Transcation
        public static string GenerateUniqueCode()
        { 
            string Code = ShortId.Generate(new GenerationOptions(useNumbers:true,length:10,useSpecialCharacters:false)).ToUpper();
            return Code;
        }

        public static int GenerateUniqueID()
        {
            var generator = new IdGenerator(2);
            int id = (int)generator.CreateId();
            return Math.Abs(id);
        }

        public static string GenerateResetCode()
        {
            return ShortId.Generate(new GenerationOptions(useNumbers: true, length: 8, useSpecialCharacters: false));
        }

 

        public  static async Task<Boolean> MailAccountNo(string email,string firstname,int accountNo)
        {
            try
            {

                StringBuilder EmailTemplate = new StringBuilder();

                EmailTemplate.AppendLine("Dear @Model.Firstname");
                EmailTemplate.AppendLine("<p>Welcome to our banking services! We're delighted to have you as a new member of our financial family.<br/>" +
                    "Your has been succefully completed,and we're exited to provide you new bank account</p>");
                EmailTemplate.AppendLine("<p>Your account number is @Model.AccountNo. You can use this to login to into your account</p>");
                EmailTemplate.AppendLine("<p>Thank You for choosing us as your trusted banking partner. We look forward to providing you with a seamless banking experience and helping you achieve your financial goals</p>");
                EmailTemplate.AppendLine("<p>Best regards</p>");
                EmailTemplate.AppendLine("Fintech Bank");

                Email.DefaultSender = Sender.EmailSender();
                Email.DefaultRenderer = new RazorRenderer();

                var RecieversEmail = await Email.From("fintechbank6@gmail.com", "Fintech")
                            .To(email, firstname)
                            .Subject("Welcome to Fintech Bank")
                            .UsingTemplate(EmailTemplate.ToString(), new { Firstname = firstname, AccountNo = accountNo })
                            .SendAsync();

                return RecieversEmail.Successful;
            }
            catch (SmtpException e)
            {
                Console.WriteLine($"Failed error {e.Message}");
                throw ;
            }
           
            //email password-G8qa2@Fi*hwL83rbH1m
        }

        public static async Task<Boolean> MailResetCode(string email,string firstname,string resetCode)
        {
            StringBuilder EmailTemplate = new StringBuilder();

            try
            {
                EmailTemplate.AppendLine("Dear @Model.Firstname");
                EmailTemplate.AppendLine("<p>We hope this email finds you well. We recieved your request to reset your password.<br/></p>");
                EmailTemplate.AppendLine("<p>Your Reset code is @Model.ResetCode. Please note the reset is valid only for next 5 minutes</p>");
                EmailTemplate.AppendLine("<p>If you didn't request the password please call this number 0700 000 000</p>");
                EmailTemplate.AppendLine("<p>Regards</p>");
                EmailTemplate.AppendLine("Fintech Bank");

                Email.DefaultSender = Sender.EmailSender();
                Email.DefaultRenderer = new RazorRenderer();

                var RecieversEmail = await Email.From(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["username"])
                            .To(email, firstname)
                            .Subject("Fintech Password Reset")
                            .UsingTemplate(EmailTemplate.ToString(), new { Firstname = firstname, ResetCode = resetCode, })
                            .SendAsync();

                return RecieversEmail.Successful;
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Email Timed Out {ex.Message}");
                throw ex;
            }
            catch (SmtpException e)
            {
                Console.WriteLine($"Failed error {e.Message}");
                throw e;
            }


        }
    }
}
