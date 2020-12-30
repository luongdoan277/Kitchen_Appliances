using Kitchen_Appliances.Models;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly MailSettings mailSettings;
        private readonly StoreDbContext context;

        private readonly ILogger<SendMailService> logger;


        // mailSetting được Inject qua dịch vụ hệ thống
        // Có inject Logger để xuất log
        public SendMailService(IOptions<MailSettings> _mailSettings, ILogger<SendMailService> _logger, StoreDbContext _context)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            context = _context;
        }

        // Gửi email, theo nội dung trong mailContent
        public async Task SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;


            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new SmtpClient();

            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);

                logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                logger.LogError(ex.Message);
            }

            smtp.Disconnect(true);

            logger.LogInformation("send mail to " + mailContent.To);

        }
        public async Task SendCheckoutEmailAsync(Order order)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Pages\\CheckoutCart.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            var name = order.Customer.CustomerName;
            var emailuser = order.Customer.CustomerEmail;
            var phone = order.Customer.CustomerPhone;
            var address = order.OrderAddress;
            var orderOPP = order.OrderOPP;
            var total = order.TotalPrice.ToString();
            var list = context.OrderItems.Where(l => l.OrderID == order.OrderID).FirstOrDefault();

            MailText = MailText.Replace("[username]", name)
                               .Replace("[email]", emailuser)
                               .Replace("[phone]", phone)
                               .Replace("[address]", address)
                               .Replace("[orderOpp]", orderOPP)
                               .Replace("[total]", total);
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(order.Customer.CustomerEmail));
            email.Subject = $"Welcome {order.Customer.CustomerName}";
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host,
                         mailSettings.Port,
                         SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Mail,
                              mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await SendMail(new MailContent()
            {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }
    }
}
