using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BirthdayGreetings.Out
{
    public class ConsoleSendGreetings : ISendGreetings
    {
        public void SendGreetings(List<Friend> friends)
        {
            foreach (Friend f in friends)
            {
                Console.WriteLine("Greetings sent to " + f.Email);
            }
        }
    }
}
