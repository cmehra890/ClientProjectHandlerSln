using ClientProjectHandle_Entities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_Utilities
{
    public static class Mailer
    {
        private static SmtpClient _smtpClient;
        private static string? _defaultFromMail;
        private static string? _defaultFromName;

        static Mailer()
        {
            MailServer mailServer = AppSettingsConfiguration.GetConfig<MailServer>("MailServer");
            _smtpClient = new SmtpClient()
            {
                Host = mailServer.Host,
                Port = mailServer.Port,
                EnableSsl = mailServer.UseSSL,
                UseDefaultCredentials = mailServer.DefaultCredentials,
                Credentials = new NetworkCredential(mailServer.Username, mailServer.Password),
                Timeout = mailServer.Timeout
            };

            _defaultFromMail = mailServer.DefaultFromMail;
            _defaultFromName = mailServer.DefaultFromName;
        }

        public static async Task<ErrorModel> SendMail(MailModel? mail)
        {
            try
            {
                MailMessage message = new();

                message.From = new MailAddress(_defaultFromMail, _defaultFromName);

                if (mail.To is not null)
                    foreach (string item in mail.To.Split(','))
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (Validations.IsValidMail(item))
                            {
                                message.To.Add(item);
                            }
                        }
                    }
                if (mail.Cc is not null)
                    foreach (string item in mail.Cc.Split(','))
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (Validations.IsValidMail(item))
                            {
                                message.CC.Add(item);
                            }
                        }
                    }
                if (mail.Bcc is not null)
                    foreach (string item in mail.Bcc.Split(','))
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (Validations.IsValidMail(item))
                            {
                                message.Bcc.Add(item);
                            }
                        }
                    }

                message.Subject = mail.Subject;
                if (mail.Attachments is not null)
                    foreach (AttachmentModel item in mail.Attachments)
                    {
                        if (item is not null)
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                stream.Write(item.ByteArray, 0, item.ByteArray.Length);
                                stream.Position = 0;

                                Attachment attachment = new Attachment(stream, item.AttachmentName);

                                message.Attachments.Add(attachment);
                            }
                        }
                    }

                message.Body = mail.Body;
                message.IsBodyHtml = true;

                await _smtpClient.SendMailAsync(message);

                return new ErrorModel
                {
                    ErrorCode = "0",
                    ErrorDescription = "Mail Send Done!"
                };
            }
            catch (Exception ex)
            {
                return new ErrorModel() { ErrorCode = "-1", ErrorDescription = ex.Message };
            }
        }

    }
}
