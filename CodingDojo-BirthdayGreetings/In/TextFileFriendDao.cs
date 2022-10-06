using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BirthdayGreetings.In
{
    public class TextFileFriendDao : IFriendDao
    {
        private string FilePath { get; set; }

        public TextFileFriendDao(string filePath)
        {
            FilePath = filePath;
        }

        public List<Friend> GetFriends()
        {
            List<Friend> friends = new List<Friend>();
            List<string> lines = File.ReadLines(FilePath).ToList();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();
                }

                friends.Add(new Friend(parts[0], parts[1], new DateOnly(int.Parse(parts[2].Split('/')[0]), int.Parse(parts[2].Split('/')[1]), int.Parse(parts[2].Split('/')[2])), parts[3]));
            }
            return friends;
        }
    }
}
