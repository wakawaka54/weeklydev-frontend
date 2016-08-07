using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models.Infrastructure
{
    public enum ApplicationMessageType
    {
        Info, Success, Danger, Warning
    }

    public class ApplicationMessage
    {
        public ApplicationMessageType MessageType { get; set; }
        public string Message { get; set; }
    }
}
