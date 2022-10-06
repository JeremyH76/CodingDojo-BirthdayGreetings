using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BirthdayGreetings
{
    public class Friend
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }

        public Friend(string lastName, string firstName, DateOnly dateOfBirth, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Friend f2 = (Friend)obj;
                return (f2.Email == this.Email && f2.FirstName == this.FirstName && f2.LastName == this.LastName && f2.DateOfBirth == this.DateOfBirth);
            }
            return false;
        }
    }
}
