using Core.Utilities.EmailService.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using Core.Entity;
using System.Net.Mail;
using System.Diagnostics;

namespace Core.Utilities.EmailService.Concrete
{
   public class GMailServices: IEmailService
      
        
    {
       
        public bool SendEmail(string body, string to, string subject, string file)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress("acarwoody01@gmail.com");
            if (file!= "openFileDialog1")
            {
                string attDocument = file;
                mail.Attachments.Add(new Attachment(attDocument));
            }
            mail.To.Add(new MailAddress(to));
            MimeKit.MimeMessage mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);
            mimeMessage.Prepare(MimeKit.EncodingConstraint.SevenBit);
            Message message = new Message();
            message.Raw = Base64UrlEncode(mimeMessage.ToString());
           
            try
            {
                string[] Scopes = { GmailService.Scope.GmailSend };
                string[] Scope = { GmailService.Scope.GmailModify };
                UserCredential credential;
                using (var stream = new FileStream(
                    "./client_secret.json",
                    FileMode.Open,
                    FileAccess.Read
                ))
                {
                    string credPath = System.Environment.GetFolderPath(
            System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart2.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                 GoogleClientSecrets.FromStream(stream).Secrets,
                                  Scopes,
                                  "user",
                                  CancellationToken.None,
                                  new FileDataStore(credPath, true)).Result;
                    //Console.WriteLine("Credential file saved to: " + credPath);
                }
                // Create Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "IEEE E-posta Hizmeti",
                });
                //Parsing HTML 

                var newMsg = new Google.Apis.Gmail.v1.Data.Message();
                newMsg.Raw = this.Base64UrlEncode(message.ToString());
                
                Message response = service.Users.Messages.Send(message, "me").Execute();
                

                if (response != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    
}
}
