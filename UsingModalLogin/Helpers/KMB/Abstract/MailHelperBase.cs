using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingModalLogin.Helpers.KMB.Abstract
{
    internal abstract class MailHelperBase
    {
        public string MailHost { get; protected set; }
        public int MailPort { get; protected set; }
        public string MailUsername { get; protected set; }
        public string MailPassword { get; protected set; }

        public abstract bool SendMail(string body, string to, string subject, bool isHtml);
        public abstract bool SendMail(string body, List<string> to, string subject, bool isHtml);
    }
}
