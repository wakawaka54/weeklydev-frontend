using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Services.Email
{
    public interface IEmailService
    {
        void SendMail(string toName, string toAddress, string subject, string body);
    }
}
