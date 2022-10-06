using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingDojo_BirthdayGreetings.In;
using CodingDojo_BirthdayGreetings.Out;

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
            List<Friend> friends;
            if (day.Month == 2 && day.Day == 28 && day.AddDays(1).Day != 29)
            {
                friends = FriendDao.GetFriends().Where(x => x.DateOfBirth.Month == 2 && (x.DateOfBirth.Day == 28 || x.DateOfBirth.Day == 29)).ToList();
            }
            else
            {
                friends = FriendDao.GetFriends().Where(x => x.DateOfBirth.Month == day.Month && x.DateOfBirth.Day == day.Day).ToList();
            }
            if (friends.Count > 0)
            {
                Sender.SendGreetings(friends);
            }
            else
            {
                Console.WriteLine("No birthday today");
            }
        }

    }
}
