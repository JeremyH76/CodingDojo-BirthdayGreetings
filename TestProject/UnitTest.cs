using Castle.Components.DictionaryAdapter.Xml;
using CodingDojo_BirthdayGreetings;
using CodingDojo_BirthdayGreetings.In;
using CodingDojo_BirthdayGreetings.Out;
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
            senderMock.Verify(x => x.SendGreetings(It.Is<List<Friend>>(x => x.Count == 1 && friends[0].Equals(x[0]))), Times.Once);
        }

        [Fact]
        public void TestNoBirthdayInLotOfFriends()
        {
            List<Friend> friends = new List<Friend>() {
                new Friend("a", "b", new DateOnly(1960, 5, 3), "a.b@gmail.com"),
                new Friend("g", "a", new DateOnly(1972, 2, 20), "g.a@gmail.com"),
                new Friend("z", "r", new DateOnly(1961, 12, 9), "z.r1212@gmail.com")
            };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2022, 5, 4));
            senderMock.Verify(x => x.SendGreetings(It.IsAny<List<Friend>>()), Times.Never);
        }

        [Fact]
        public void TestBirthdayInLotOfFriends()
        {
            List<Friend> friends = new List<Friend>() {
                new Friend("a", "b", new DateOnly(1960, 5, 3), "a.b@gmail.com"),
                new Friend("g", "a", new DateOnly(1972, 2, 20), "g.a@gmail.com"),
                new Friend("z", "r", new DateOnly(1961, 12, 9), "z.r1212@gmail.com")
            };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2022, 2, 20));
            senderMock.Verify(x => x.SendGreetings(It.Is<List<Friend>>(x => x.Count == 1 && friends[1].Equals(x[0]))), Times.Once);
        }

        [Fact]
        public void TestTwoBirthdayToday()
        {
            List<Friend> friends = new List<Friend>() {
                new Friend("a", "b", new DateOnly(1960, 5, 3), "a.b@gmail.com"),
                new Friend("g", "a", new DateOnly(1972, 2, 20), "g.a@gmail.com"),
                new Friend("z", "r", new DateOnly(1961, 12, 9), "z.r1212@gmail.com"),
                new Friend("m", "j", new DateOnly(1963, 2, 20), "m.j@gmail.com")
            };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2022, 2, 20));
            senderMock.Verify(x => x.SendGreetings(It.Is<List<Friend>>(x => x.Count == 2 && friends[1].Equals(x[0]) && friends[3].Equals(x[1]))), Times.Once);
        }

        [Fact]
        public void Test29_02_NotToday()
        {
            List<Friend> friends = new List<Friend>() {
                new Friend("a", "b", new DateOnly(1988, 2, 29), "a.b@gmail.com"),
                new Friend("g", "a", new DateOnly(1972, 3, 9), "g.a@gmail.com"),
                new Friend("z", "r", new DateOnly(1961, 12, 9), "z.r1212@gmail.com"),
                new Friend("m", "j", new DateOnly(1963, 6, 20), "m.j@gmail.com")
            };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2022, 3, 20));
            senderMock.Verify(x => x.SendGreetings(It.IsAny<List<Friend>>()), Times.Never);
        }

        [Fact]
        public void Test29_02_Today()
        {
            List<Friend> friends = new List<Friend>() {
                new Friend("a", "b", new DateOnly(1988, 2, 29), "a.b@gmail.com"),
                new Friend("g", "a", new DateOnly(1972, 3, 9), "g.a@gmail.com"),
                new Friend("z", "r", new DateOnly(1961, 12, 9), "z.r1212@gmail.com"),
                new Friend("m", "j", new DateOnly(1963, 6, 20), "m.j@gmail.com")
            };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2024, 2, 29));
            senderMock.Verify(x => x.SendGreetings(It.Is<List<Friend>>(x => x.Count == 1 && friends[0].Equals(x[0]))), Times.Once);
        }

        [Fact]
        public void Test29_02_Tomorrow()
        {
            List<Friend> friends = new List<Friend>() {
                new Friend("a", "b", new DateOnly(1988, 2, 29), "a.b@gmail.com"),
                new Friend("g", "a", new DateOnly(1972, 3, 9), "g.a@gmail.com"),
                new Friend("z", "r", new DateOnly(1961, 12, 9), "z.r1212@gmail.com"),
                new Friend("m", "j", new DateOnly(1963, 6, 20), "m.j@gmail.com")
            };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2024, 2, 28));
            senderMock.Verify(x => x.SendGreetings(It.IsAny<List<Friend>>()), Times.Never);
        }

        [Fact]
        public void Test29_02_TomorrowButImpossible()
        {
            List<Friend> friends = new List<Friend>() {
                new Friend("a", "b", new DateOnly(1988, 2, 29), "a.b@gmail.com"),
                new Friend("g", "a", new DateOnly(1972, 3, 9), "g.a@gmail.com"),
                new Friend("z", "r", new DateOnly(1961, 12, 9), "z.r1212@gmail.com"),
                new Friend("m", "j", new DateOnly(1963, 6, 20), "m.j@gmail.com")
            };
            Mock<IFriendDao> friendDao = new Mock<IFriendDao>();
            friendDao.Setup(x => x.GetFriends()).Returns(friends);
            Mock<ISendGreetings> senderMock = new Mock<ISendGreetings>();
            senderMock.Setup(x => x.SendGreetings(It.IsAny<List<Friend>>()));
            BirthdayGreetings bg = new BirthdayGreetings(friendDao.Object, senderMock.Object);
            bg.FindSearchAndSend(new DateOnly(2023, 2, 28));
            senderMock.Verify(x => x.SendGreetings(It.Is<List<Friend>>(x => x.Count == 1 && friends[0].Equals(x[0]))), Times.Once);
        }
    }
}