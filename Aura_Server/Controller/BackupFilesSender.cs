using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Специальный объект для передачи файлов бэкапов куда-нибудь
/// </summary>
namespace Aura_Server.Controller
{
    public class BackupFilesSender
    {
        private string mailAddress = "south-nort@ya.ru";
        private string mailPassword = "TrVf9bYVCiueli";

        public void SendMail(params string[]files)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(mailAddress);
            mailMessage.To.Add(new MailAddress(mailAddress));
            mailMessage.Subject = "Logs " + DateTime.Today.ToLongDateString();

            foreach (var file in files)
            {
                Attachment attachment = new Attachment(file);
                mailMessage.Attachments.Add(attachment);
            }

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.yandex.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(mailAddress, mailPassword);

            try
            {
                client.Send(mailMessage);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



    }
}
