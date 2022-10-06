using Castle.Components.DictionaryAdapter.Xml;
using CodingDojo_BirthdayGreetings;
using Moq;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void TestNoBirthdayToday()
        {
            List<Friend> friends = new List<Friend>() { new Friend("a", "b", new DateOnly(1960, 1, 1), "a.b@gmail.com") };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2022, 10, 6));
            senderMock.Verify(x => x.SendGreetings(It.IsAny<List<Friend>>()), Times.Never);
        }

        [Fact]
        public void TestBirthday()
        {
            List<Friend> friends = new List<Friend>() { new Friend("a", "b", new DateOnly(1960, 5, 3), "a.b@gmail.com") };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2022, 5, 3));
            senderMock.Verify(x => x.SendGreetings(It.Is<List<Friend>>(x => x.Contains(friends[0]) && x.Count == 1)), Times.Once);
        }
    }
}