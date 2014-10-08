using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AstroScraper
{
    public class EmailHelper:IMessenger
    {
      

        public void SendMessage(string message, string receiver,string server,string password,string serverUser)
        {
            SendEmailMessage(message, receiver,server,password,serverUser);
        }

        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="text"></param>
        private void SendEmailMessage(string message, string receiver,string server,string password,string serverUser)
        {
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = server;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(serverUser, password);
            objeto_mail.From = new MailAddress(receiver);
            objeto_mail.To.Add(new MailAddress(receiver));
            objeto_mail.Subject = message;
            objeto_mail.Body = message;
            client.Send(objeto_mail);
        }
    }
}
