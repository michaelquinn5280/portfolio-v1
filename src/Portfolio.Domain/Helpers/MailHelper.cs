using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using Portfolio.Domain.Entities;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Portfolio.Domain.Helpers
{
    public static class MailHelper
    {
        private static ContactInfoRepository _contactInfoRepository = new ContactInfoRepository();

        public static bool SendMessage(ContactAttempt contactAttempt)
        {
            var telemetry = new TelemetryClient();
            bool success;
            try
            {
                var contactInfo = _contactInfoRepository.GetContactInfo(contactAttempt.ProfileId);
                MailMessage mailMessage = new MailMessage(contactAttempt.EmailAddress, contactInfo.EmailAddress, contactAttempt.Subject, contactAttempt.Message);

                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailUserName"], ConfigurationManager.AppSettings["MailPassword"]);
                client.Send(mailMessage);

                telemetry.TrackEvent("EmailSent", GetEmailSentTrackingProperties(contactAttempt, contactInfo));
                success = true;
            }
            catch(Exception ex)
            {
                telemetry.TrackException(ex);
                success = false;
            }
            return success;
        }

        private static Dictionary<string, string> GetEmailSentTrackingProperties(ContactAttempt contactAttempt, ContactInfo contactInfo)
        {
            return new Dictionary<string, string> {
                    { "profileId", contactInfo.ProfileId.ToString() },
                    { "toEmail", contactInfo.EmailAddress },
                    { "FromEmail", contactAttempt.EmailAddress },
                    { "toName", contactAttempt.Name },
                    { "subject", contactAttempt.EmailAddress }
            };
        }
    }
}
