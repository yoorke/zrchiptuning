using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Web;

namespace Utility
{
    public class Common
    {
        public string RemoveHTMLTags(string text)
        {
            return Regex.Replace(text, @"<[^>]+>|&nbsp;", "").Trim().Replace(@"\n\n", @"\n");
            //return Regex.Replace(noHTML, @"\s{2,}", "");
        }

        public static void AddUrlRewrite(string url, string page)
        {

        }

        public static void RemoveUrlRewrite(string url)
        {

        }

        public static bool SendMail(string heading, string email, string message)
        {
            using (MailMessage mail = new MailMessage())
            {
                try
                {
                    mail.From = new MailAddress("office@zrchiptuning.com");
                    mail.To.Add(new MailAddress(email));
                    mail.Subject = heading;
                    mail.Body = message;

                    SmtpClient smtp = getSmtp();
                    smtp.Send(mail);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private static SmtpClient getSmtp()
        {
            SmtpClient smtp = new SmtpClient();
            NetworkCredential networkCredentials = new NetworkCredential("office@zrchiptuning.com", "zrchiptuning");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = networkCredentials;
            smtp.Host = "mail.zrchiptuning.com";
            smtp.Port = 26;
            smtp.EnableSsl = false;

            return smtp;
        }

        public static void CreateSitemap()
        {
            
        }
    }
}
