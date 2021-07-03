using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendEmailWebApplication
{
    public class Service
    {
        private readonly ILogger<Service> logger;

        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }

        public void SendEmailDefault()
        {                     
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("sales@spinningline.ru", "Моя компания");
                message.To.Add("kolekdoma@mail.ru");
                message.Subject = "Сообщение от System.Net.Mail";
                message.Body = "<div style=\"color: red;\">Сообщение от System.Net.Mail</div>";
                //message.Attachments.Add(new Attachment("...путь к файлу..."));

                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("kolekdoma1986@gmail.com", "Password");
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(message);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
                
            }
        }

        public void SendEmailCustom()
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Моя компания", "sales@spinningline.ru"));
                message.To.Add(new MailboxAddress("kolekdoma@mail.ru"));               
                message.Subject = "Сообщение от MailKit";
                message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color: green;\">Сообщение от MailKit</div>" }.ToMessageBody();

                using(MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("kolekdoma1986@gmail.com", "Password");
                    client.Send(message);

                    client.Disconnect(true);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }                
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);

            }
        }
    }
}
