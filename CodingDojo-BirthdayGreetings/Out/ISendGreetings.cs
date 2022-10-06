using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BirthdayGreetings.Out
{
    public interface ISendGreetings
    {
        public void SendGreetings(List<Friend> friends);
    }
}
