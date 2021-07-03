using Microsoft.Extensions.Logging;
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
                message.From = new MailAddress("nikolaj.smirnov@rehau.com", "Моя компания");
                message.To.Add("kolekdoma@mail.ru");
                message.Subject = "Сообщение от System.Net.Mail";
                message.Body = "<div style=\"color: red;\">Сообщение от System.Net.Mail</div>";
                //message.Attachments.Add(new Attachment("...путь к файлу..."));

                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("gmpservicerobot@gmail.com", "pass");
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
                logger.LogInformation("Сообщение отправлено успешно!");
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);

            }
        }
    }
}
