using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace lv_Common
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class SendEmail
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="title">邮件标题</param>
        /// <param name="content">邮件内容</param>
        /// <param name="toEmail">收件邮箱</param>
        /// <param name="fromEmail">发件邮箱</param>
        /// <param name="emailPwd">发件邮箱密码</param>
        /// <param name="emailSmtp">发件箱smtp服务器</param>
        public static void Send(string title, string content, string toEmail, string fromEmail, string emailPwd, string emailSmtp)
        {
            try
            {

                DateTime nowTime = DateTime.Now;
                DateTime nextTime = nowTime;
                string errorLog = "";
                string smtp_Account = fromEmail; //发件邮箱
                string smtp_Password = emailPwd; //邮箱密码
                bool smtp_SmtpSsl = false;
                string smtp_SmtpPort = "25";
                string smtp_SmtpHost = emailSmtp;
                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; //指定电子邮件发送方式
                    smtpClient.Host = smtp_SmtpHost;
                    if (smtp_SmtpSsl)
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.Port = Convert.ToInt32(smtp_SmtpPort);
                    }
                    smtpClient.Credentials = new System.Net.NetworkCredential(smtp_Account, smtp_Password);     //用户名和密码

                    string fromEmails = smtp_Account;
                    //string toEmail = "zackwrj@126.com";//email.Email;
                    MailMessage mailMessage = new MailMessage(fromEmails, toEmail);

                    mailMessage.Subject = title;   //主题
                    mailMessage.Body = content;    //内容
                    mailMessage.BodyEncoding = System.Text.Encoding.UTF8;   //正文编码
                    mailMessage.IsBodyHtml = true;                          //设置为HTML格式
                    mailMessage.Priority = MailPriority.High;               //优先级

                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    errorLog = ex.Message;
                }
            }
            catch
            {
            }
        }
    }
}
