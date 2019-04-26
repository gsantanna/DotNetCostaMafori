//using SendGrid;
//using SendGrid.Helpers.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace TDLC.UI.Utility
{
    public class EmailSVC
    {

        public Task SendAsync(string para, string paraNome, string assunto, string corpo)
        {
            MailMessage objMsg = new MailMessage();
            objMsg.Body = corpo;
            objMsg.To.Add(new MailAddress(para, paraNome));
            objMsg.Subject = assunto;
            objMsg.IsBodyHtml = true;
            return SendAsync(objMsg);


        }

        public Task SendAsync(MailMessage msg)
        {
            return configSendGridasync(msg);
        }


        private async Task configSendGridasync(MailMessage message)
        {

            var apiKey = ConfigurationManager.AppSettings["API_SENDGRID_KEY"];

            Email from = new Email(ConfigurationManager.AppSettings["API_SENDGRID_FROM"]);
            Email to = new Email(message.To.First().Address, message.To.First().DisplayName);


            Content content = new Content("text/html", message.Body);
            Mail mail = new Mail(from, message.Subject, to, content);
            dynamic sg = new SendGridAPIClient(apiKey);
            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());

        }

    }

}