using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BirthdayGreetings.Out
{
    public class EmailSendGreetings : ISendGreetings
    {
        private SmtpClient SmtpClient { get; }
        private string MyEmail { get; }
        public EmailSendGreetings(string smtp, string myEmail, string user, SecureString password)
        {
            MyEmail = myEmail;
            SmtpClient = new SmtpClient(smtp)
            {
                Port = 587,
                Credentials = new NetworkCredential(user, password),
                EnableSsl = true
            };
        }
        public void SendGreetings(List<Friend> friends)
        {
            foreach (Friend f in friends)
            {
                try
                {
                    SmtpClient.Send(MyEmail, f.Email, "Happy Birthday !", "Best wishes on your Birthday " + f.FirstName + " ! :)");
                    new ConsoleSendGreetings().SendGreetings(friends);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
        }

        public static SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
    }
}
