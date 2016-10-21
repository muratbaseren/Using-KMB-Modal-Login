using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using UsingModalLogin.Helpers.KMB.Abstract;
using UsingModalLogin.Helpers.KMB.Concrete;

namespace UsingModalLogin.Helpers.KMB.Concrete
{
    internal partial class KMBMailHelper : MailHelperBase
    {
        public KMBMailHelper()
        {
            MailHost = KMBConfigHelper.MailHost;
            MailPort = int.Parse(KMBConfigHelper.MailPort);
            MailUsername = KMBConfigHelper.MailUid;
            MailPassword = KMBConfigHelper.MailPass;
        }

        public KMBMailHelper(string host, int port, string username, string password)
        {
            MailHost = host;
            MailPort = port;
            MailUsername = username;
            MailPassword = password;
        }



        public override bool SendMail(string body, string to, string subject, bool isHtml = true)
        {
            return SendMail(body, new List<string> { to }, subject, isHtml);
        }

        public override bool SendMail(string body, List<string> to, string subject, bool isHtml = true)
        {
            bool result = false;

            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(MailUsername);

                to.ForEach(x =>
                {
                    message.To.Add(new MailAddress(x));
                });

                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;

                using (var smtp = 
                    new SmtpClient(MailHost, MailPort))
                {
                    smtp.EnableSsl = false;
                    smtp.Credentials = 
                        new NetworkCredential(MailUsername, MailPassword);

                    smtp.Send(message);
                    result = true;
                }
            }
            catch (Exception)
            {
                // TODO : Write log for mail sending exception.
            }

            return result;
        }
    }
}