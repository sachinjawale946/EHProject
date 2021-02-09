using System;
using System.Collections.Generic;
using System.Text;

namespace EH.Assessment.Models
{
    public class ErrorLogModel
    {
        public Int64 ErrorLogId { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Application { get; set; }
        public Boolean EmailSent { get; set; }

        public bool CookiesEnabled { get; set; }
        public bool JSEnabled { get; set; }
        public bool WIN16 { get; set; }
        public bool WIN32 { get; set; }
        public DateTime Time { get; set; }
        public string ExceptionDetails { get; set; }
        public string BrowserType { get; set; }
        public string BrowserVersion { get; set; }
        public string ClientOperatingSystem { get; set; }
        public string HTTPHost { get; set; }
        public string HTTPUserAgent { get; set; }
        public string QueryString { get; set; }
        public string RemoteAddress { get; set; }
        public string RemoteHost { get; set; }
        public string RequestMethod { get; set; }
        public string ServerName { get; set; }
        public string URL { get; set; }
    }
}
