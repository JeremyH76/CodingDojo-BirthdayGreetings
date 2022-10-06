using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BirthdayGreetings.In
{
    public interface IFriendDao
    {
        public List<Friend> GetFriends();
    }
}
