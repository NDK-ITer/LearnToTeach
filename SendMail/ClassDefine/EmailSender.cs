using SendMail.Interfaces;
using System.Net.Mail;
using System.Net;

namespace SendMail.ClassDefine
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string emailNeedSend, string subject, string message)
        {
            //var email = "learntoteach2023@gmail.com";
            //var pass = "LearnToTeach2023";
            var email = "tn29805.code@gmail.com";
            var pass = "uovlqjanyqakzmck";
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email, pass)
            };

            return client.SendMailAsync(
                new MailMessage(from: email,
                                to: emailNeedSend,
                                subject,
                                message
                                ));
        }
    }
}
