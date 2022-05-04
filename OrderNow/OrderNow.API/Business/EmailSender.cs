using Controllers;
using System;
using System.Net.Http;
using System.Net.Mail;

namespace WebApi.Business
{
    public class EmailSender : IEmailSender
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient.send?view=net-6.0
        public void SendEmail(string emailto, string emailfrom, string subject, string body)
        {

            if (emailto == null)
                return;
            else
            {
               
                    string to = emailto;
                    string from = emailfrom;
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = subject;
                    message.Body = @body;
                    SmtpClient client = new SmtpClient("server");
                    // Credentials are necessary if the server requires the client
                    // to authenticate before it will send email on the client's behalf.
                    client.UseDefaultCredentials = true;

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                            ex.ToString());
                    }
               

            }

        
        
        }
    }
}
