

using CodingDojo_BirthdayGreetings;

Console.WriteLine("Hello");
DateOnly today = DateOnly.FromDateTime(DateTime.Now);
Console.WriteLine("Today is "+today);

BirthdayGreetings bg = new BirthdayGreetings(new TextFileFriendDao("C:\\Users\\hure.j\\source\\repos\\CodingDojo-BirthdayGreetings\\myfriends.txt"), new ConsoleSendGreetings());
bg.FindSearchAndSend(new DateOnly(2022, 10, 6));