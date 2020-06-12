using Send_Email_with_attached_CSV.Messages;
using System;
using System.Net;
using System.Net.Mail;

namespace Send_Email_with_attached_CSV.Core
{
    public class EmailController
    {
        public void sendMail(string emailSender, string emailPassword, string emailReceiver)
        {
            try
            {
                var fromAddress = new MailAddress(emailSender, OutputMessages.sendBy);
                var toAddress = new MailAddress(emailReceiver, OutputMessages.sendTo);
                string fromPassword = emailPassword;
                string subject = OutputMessages.emailTitle;
                string body = OutputMessages.emailBody;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    message.Attachments.Add(new Attachment(@"..\..\..\result.csv"));
                    smtp.Send(message);
                    Console.WriteLine(OutputMessages.successfullySend);
                }
                smtp.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
