using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientProjectHandle_Entities.Global
{
    public class MailServer
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool DefaultCredentials { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Timeout { get; set; }
        public string? DefaultFromMail { get; set; }
        public string? DefaultFromName { get; set; }
    }
    public class MailModel
    {
        public string? To { get; set; } = string.Empty;
        public string? Cc { get; set; } = string.Empty;
        public string? Bcc { get; set; } = string.Empty;
        public string? Subject { get; set; } = string.Empty;
        public string? Body { get; set; } = string.Empty;
        public List<AttachmentModel>? Attachments { get; set; }
    }
    public class AttachmentModel
    {
        public byte[]? ByteArray { get; set; }
        public string? AttachmentName { get; set; }
    }
}
