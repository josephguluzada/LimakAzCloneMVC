using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html);
    }


    public class EmailService :IEmailService
    {

            public void Send(string to, string subject, string html)
            {
                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("code.limak.az@yandex.com"));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.yandex.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("code.limak.az@yandex.com", "code2022");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
    }
}
