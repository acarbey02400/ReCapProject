using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.EmailService.Abstract
{
   public interface IEmailService
    {
        public bool SendEmail(string body,string to, string subject,string file);
    }
}
