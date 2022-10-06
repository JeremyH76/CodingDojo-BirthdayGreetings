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
        private bool Reminder { get; }
        public EmailSendGreetings(string smtp, string myEmail, string user, SecureString password, bool reminder)
        {
            MyEmail = myEmail;
            SmtpClient = new SmtpClient(smtp)
            {
                Port = 587,
                Credentials = new NetworkCredential(user, password),
                EnableSsl = true
            };
            Reminder = reminder;
        }
        public void SendGreetings(List<Friend> friends)
        {
            bool sent = true;
            foreach (Friend f in friends)
            {
                try
                {
                    string message = "Best wishes on your Birthday " + f.FirstName + " ! :)";
                    if (Reminder && friends.Count > 1)
                    {
                        message += "\n\nToday is ";
                        List<string> friendsNames = new List<string>();
                        foreach (Friend otherFriend in friends.Where(x => !f.Equals(x)))
                        {
                            friendsNames.Add(otherFriend.FirstName + " " + otherFriend.LastName);
                        }
                        if (friendsNames.Count > 1)
                        {
                            message += String.Join(", ", friendsNames.GetRange(0, friendsNames.Count - 1));
                            message += " and " + friendsNames[friendsNames.Count - 1] + "'s birthday too.\nDon't forget to send them a message !";
                        }
                        else
                        {
                            message += friendsNames[0] + "'s birthday too.\nDon't forget to send him a message !";
                        }
                    }
                    SmtpClient.Send(MyEmail, f.Email, "Happy Birthday !", message );
                }
                catch (Exception e)
                {
                    sent = false;
                    Console.Error.WriteLine(e.Message);
                }
            }
            if (sent) { new ConsoleSendGreetings().SendGreetings(friends); }
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
