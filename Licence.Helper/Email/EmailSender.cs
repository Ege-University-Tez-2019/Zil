using Licence.Bll.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Helper.Email
{
    public static class EmailSender
    {
        //public static bool SendMail(string subject, string message, string[] addresses, Manager _manager)
        //{
        //    //var smtp = _manager.SmtpSettings.First();
        //    try
        //    {
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress(smtp.MailAdress, smtp.Title);
        //        foreach (var address in addresses)
        //        {
        //            mailMessage.To.Add(address);
        //        }
        //        mailMessage.Subject = subject;
        //        mailMessage.Body = message;
        //        mailMessage.IsBodyHtml = true;
        //        SmtpClient client = new SmtpClient(smtp.ServerAdress, smtp.Port);
        //        client.Credentials = new NetworkCredential(smtp.MailAdress, smtp.Password);
        //        client.EnableSsl = smtp.SSL;
        //        client.Send(mailMessage);
        //        return true;
        //    }
        //    catch (Exception exc)
        //    {
        //        return false;
        //    }
        //}



        public static bool SendTestMail(string toAddress, string fromAddress, string password, int port, bool isSSL, string serverAddress)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromAddress, "Eselfware");
                mailMessage.To.Add(toAddress);
                mailMessage.Subject = "Eselfware Test Mail";
                mailMessage.Body = String.Format("Bu mail {0} tarihinde test amaçlı gönderilmiştir.", DateTime.Now);
                mailMessage.IsBodyHtml = true;
                SmtpClient client = new SmtpClient(serverAddress, port);
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(fromAddress, password);
                client.EnableSsl = isSSL;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public static bool SendErrorMail(string errorMessage)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("emretufandev@yandex.com", "Hata");
                mailMessage.To.Add("emretufandev@yandex.com");
                mailMessage.Subject = "Hata";
                mailMessage.Body = errorMessage;
                mailMessage.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                client.Credentials = new NetworkCredential("emretufandev@yandex.com", "Ener43314");
                client.EnableSsl = true;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
