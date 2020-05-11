using LabA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace LabA.Services
{
    public class EmailHelper
    {
        private EmailSettings _emailSettings;
        public EmailHelper(EmailSettings _emailSettings)
        {
            this._emailSettings = _emailSettings;
        }

        public bool SendMail(string recipient, string subject)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.FromEmail, _emailSettings.DisplayName)
                };

                string toEmail = string.IsNullOrEmpty(recipient)
                                 ? _emailSettings.ToEmail : recipient;

                mail.To.Add(new MailAddress(toEmail));

                if (_emailSettings.BccEmails != null)
                {
                    foreach (string bcc in _emailSettings.BccEmails)
                    {
                        mail.Bcc.Add(new MailAddress(bcc));
                    }
                }


                // Subject and multipart/alternative Body
                mail.Subject = subject;

                string text = "Plain text version of a message body. ";
                string html = @"<p>HTML version of a message body. </p>";

                mail.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(text,
                        null, MediaTypeNames.Text.Plain));
                mail.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(html,
                        null, MediaTypeNames.Text.Html));

                //optional priority setting
                mail.Priority = MailPriority.High;

                // you can add attachments
                //mail.Attachments.Add(new Attachment(@"C:\mind.gif"));

                // Init SmtpClient and send
                SmtpClient smtp = new SmtpClient(_emailSettings.Domain, _emailSettings.Port);
                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameLogin, _emailSettings.UsernamePassword);
                smtp.EnableSsl = false;
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }

}
