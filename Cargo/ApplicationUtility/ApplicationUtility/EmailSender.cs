using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace ApplicationUtility
{
    public class EmailSetting
    {
        /// <summary>
        /// Gets or sets an email address
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets an email display name
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets an email host
        /// </summary>
        public virtual string Host { get; set; }

        /// <summary>
        /// Gets or sets an email port
        /// </summary>
        public virtual int Port { get; set; }

        /// <summary>
        /// Gets or sets an email user name
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets an email password
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets or sets a value that controls whether the SmtpClient uses Secure Sockets Layer (SSL) to encrypt the connection
        /// </summary>
        public virtual bool EnableSsl { get; set; }

        /// <summary>
        /// Gets or sets a value that controls whether the default system credentials of the application are sent with requests.
        /// </summary>
        public virtual bool UseDefaultCredentials { get; set; }

        /// <summary>
        /// Gets a friendly email account name
        /// </summary>
        public virtual string FriendlyName
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(this.DisplayName))
                    return this.Email + " (" + this.DisplayName + ")";
                return this.Email;
            }
        }
    }
    public class EmailSender
    {
        public static void SendEmail(string subject, string body,
          string toEmail, string toName )
        {
            EmailSetting es = new EmailSetting();
            es.DisplayName = "System admin";
            es.Host = "smtp.live.com";
            es.UseDefaultCredentials = false;
            es.Username = "suochensheng@hotmail.com";
            es.Password = "1qaz2WSX";
            es.Email = "do_not_reply@bmcargo.com";
            es.EnableSsl = true;
            es.Port = 25;
            try
            {
                SendEmail(es, subject, body, es.Email, es.FriendlyName, toEmail, toName);
            }
            catch (Exception ex)
            { }
            finally
            { }
        }
        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAccount">Email account to use</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="fromAddress">From address</param>
        /// <param name="fromName">From display name</param>
        /// <param name="toAddress">To address</param>
        /// <param name="toName">To display name</param>
        /// <param name="bcc">BCC addresses list</param>
        /// <param name="cc">CC addresses ist</param>
        public static void SendEmail(EmailSetting emailSetting, string subject, string body,
            string fromAddress, string fromName, string toAddress, string toName,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null, string logopath = "")
        {
            SendEmail(emailSetting, subject, body,
                new MailAddress(fromAddress, fromName), new MailAddress(toAddress, toName),
                bcc, cc, logopath);
        }

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAccount">Email account to use</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="from">From address</param>
        /// <param name="to">To address</param>
        /// <param name="bcc">BCC addresses list</param>
        /// <param name="cc">CC addresses ist</param>
        public static void SendEmail(EmailSetting emailSetting, string subject, string body,
            MailAddress from, MailAddress to,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null, string logopath = "")
        {
            var message = new MailMessage();
            
            message.From = from;
            message.To.Add(to);
            if (null != bcc)
            {
                foreach (var address in bcc.Where(bccValue => !String.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(address.Trim());
                }
            }
            if (null != cc)
            {
                foreach (var address in cc.Where(ccValue => !String.IsNullOrWhiteSpace(ccValue)))
                {
                    message.CC.Add(address.Trim());
                }
            }
            message.Subject = subject;
            message.Priority = System.Net.Mail.MailPriority.High;
            message.IsBodyHtml = true;
            if (!string.IsNullOrWhiteSpace(logopath))
            {
                string attach1path = System.IO.Path.Combine(logopath, "Conf_email_header2.jpg");

                string attach2path = System.IO.Path.Combine(logopath, "MailLogo.png");

                string attach3path = System.IO.Path.Combine(logopath, "MailBg.jpg");

                message.Attachments.Add(new Attachment(attach1path));
                message.Attachments[0].ContentType.Name = "image/jpg";
                message.Attachments[0].ContentId = "emailheaderlogo";
                message.Attachments[0].ContentDisposition.Inline = true;
                message.Attachments[0].TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                message.Attachments.Add(new Attachment(attach2path));
                message.Attachments[1].ContentType.Name = "image/png";
                message.Attachments[1].ContentId = "customervalidationemaillogo";
                message.Attachments[1].ContentDisposition.Inline = true;
                message.Attachments[1].TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                message.Attachments.Add(new Attachment(attach3path));
                message.Attachments[2].ContentType.Name = "image/jpg";
                message.Attachments[2].ContentId = "customervalidationemailbg";
                message.Attachments[2].ContentDisposition.Inline = true;
                message.Attachments[2].TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            }
            message.Body = body;
            
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = emailSetting.UseDefaultCredentials;
                smtpClient.Host = emailSetting.Host;
                smtpClient.Port = emailSetting.Port;
                smtpClient.EnableSsl = emailSetting.EnableSsl;
                if (emailSetting.UseDefaultCredentials)
                    smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                else
                    smtpClient.Credentials = new NetworkCredential(emailSetting.Username, emailSetting.Password);
               
                smtpClient.Send(message);
            }
        }
    }
}
