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
            
        }

    }
}
