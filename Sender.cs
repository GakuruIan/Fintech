using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;


namespace Fintech
{
    class  Sender
    {

       public static SmtpSender EmailSender() 
        {
           return new SmtpSender(() => new SmtpClient(ConfigurationManager.AppSettings["StmpServer"])
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Port = int.Parse(ConfigurationManager.AppSettings["StmpPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"]),
                Timeout = 60000
            });
        }
    }
}
