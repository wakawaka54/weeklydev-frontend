using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace TestApp.Services.Email
{
    public class EmailService : IEmailService
    {
        public void SendMail(string toName, string toAddress, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Alex Bello", "abello.2015@gmail.com"));
            message.To.Add(new MailboxAddress(toName, toAddress));
            message.Subject = subject;

            message.Body = new TextPart()
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.elasticemail.com", 2525, false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("abello.2015@gmail.com", "74d3f701-c876-4b9b-be23-3568435c6550");

                client.Send(message);

                client.Disconnect(true);
            }
        }
    }
}
