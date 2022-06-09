using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Services
{
    public class EmailServices
    {
        public static void SendEmail(string emailTo, string subject, string body)
        {
            var client = new SmtpClient("smtp.ethereal.email", 587)
            {
                Credentials = new NetworkCredential("ima.roob26@ethereal.email", "f3hBzxpMX6ftdhSCtd"),
                EnableSsl = true
            };
            client.Send("ima.roob26@ethereal.email", "reinhard@gmail.com", subject, body);
                
        }
    }
}
