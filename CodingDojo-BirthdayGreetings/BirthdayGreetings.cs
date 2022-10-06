using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BirthdayGreetings
{
    public class BirthdayGreetings
    {
        private IFriendDao FriendDao { get; set; }
        private ISendGreetings Sender { get; set; }
        public BirthdayGreetings(IFriendDao dao, ISendGreetings sender)
        {
            FriendDao = dao;
            Sender = sender;
        }

        public void FindSearchAndSend(DateOnly day)
        {
            List<Friend> friends = FriendDao.GetFriends().Where(x => x.DateOfBirth.Month == day.Month && x.DateOfBirth.Day == day.Day).ToList();
            if (friends.Count > 0)
            {
                Sender.SendGreetings(friends);
                foreach (Friend f in friends)
                {
                    Console.WriteLine("Greetings sent to "+f.Email);
                }
            }
            else
            {
                Console.WriteLine("No birthday today");
            }
        }

    }
}
