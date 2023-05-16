using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class MailSender
    {
        // Kayıt Email gönderme
        public static async Task SendRegisterMail(string toMail)
        {
            {
                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("bilgiyasinmyb@outlook.com");
                    message.To.Add(new MailAddress(toMail));
                    message.Subject = "Hoş Geldiniz";
                    message.IsBodyHtml = true;
                    message.Body = "Tebrikler Kayıt İşleminiz Başarıyla Gerçekleşti";
                    smtp.Port = 587;
                    smtp.Host = "smtp.office365.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("bilgiyasinmyb@outlook.com", "PLT_MYB.HAYAL");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        // Giriş Email gönderme
        public static async Task SendLoginMail(string toMail)
        {
            {
                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("bilgiyasinmyb@outlook.com");
                    message.To.Add(new MailAddress(toMail));
                    message.Subject = "Hoş Geldiniz";
                    message.IsBodyHtml = true;
                    message.Body = "Giriş İşleminiz Başarıyla Gerçekleşti";
                    smtp.Port = 587;
                    smtp.Host = "smtp.office365.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("bilgiyasinmyb@outlook.com", "PLT_MYB.HAYAL");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
