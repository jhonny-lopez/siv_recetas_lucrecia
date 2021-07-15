using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Configuration
{
    public class SMSProviderOptions
    {
        public const string SectionName = "General:SMSProvider";
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
    }

    public class MailProviderOptions
    {
        public const string SectionName = "General:MailProvider";
        public string Name { get; set; }
        public string Url { get; set; }
        public int SMTPPort { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class GeneralOptions
    {
        public const string SectionName = "General";
        public string WebAPIUrl { get; set; }
        public bool IsBillingEnabled { get; set; }
        public int DefaultPort { get; set; }
        public SMSProviderOptions SMSProvider { get; set; }
        public MailProviderOptions MailProvider { get; set; }
    }
}
