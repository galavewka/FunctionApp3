using System;
using System.IO;

using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.ComponentModel;
using MimeKit;
using FunctionApp3.Helpers;

namespace FunctionApp3
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([BlobTrigger("samples-workitems/{name}", Connection = "conn")]Stream myBlob, string name, ILogger log)
        {
          


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Azure Yaroslav Kopetsky Blob Trigger", "sallyrider@ukr.net"));
            message.To.Add(new MailboxAddress(EmailHelper.ParseEmailFormFileName(name), EmailHelper.ParseEmailFormFileName(name)));
            message.Subject = "Azure Blob Storrage Tirgger";

            message.Body = new TextPart("plain")
            {
                Text = @"Link: https://storage1blobyaroslavkop.blob.core.windows.net/samples-workitems/" + name
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.ukr.net", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("sallyrider@ukr.net", "XZWjL8qDfksBXK93");

                client.Send(message);
                client.Disconnect(true);
            }

            //laahnilnptfthzpc


            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }

       
    }
}
