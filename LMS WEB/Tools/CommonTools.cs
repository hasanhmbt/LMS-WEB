using System.Net.Mail;
using System.Net;
using System.Text;

namespace  LMS_Web.Tools
{
    internal class CommonTools
    {

        public static string GenerateRandomPassword(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

        public static void SendEmail(string to, string subject, string body)
        {

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("ordermanagemetsystem@gmail.com", "llcglgasuiyqqvkp");
                //password: l!br@ry!@#$%
                MailMessage message = new MailMessage();
                message.To.Add(to.Trim());
                message.From = new MailAddress("ordermanagemetsystem@gmail.com");
                message.Subject = subject.Trim();
                message.Body = body.Trim();

                client.Send(message);
            }

        }
    }
}
