﻿

using CodingDojo_BirthdayGreetings;
using CodingDojo_BirthdayGreetings.Out;
using System.Security;

Console.WriteLine("Hello");
DateOnly today = DateOnly.FromDateTime(DateTime.Now);
Console.WriteLine("Today is "+today);

Console.Write("Password of your google account :");
SecureString pass = EmailSendGreetings.GetPassword();

EmailSendGreetings sender = new EmailSendGreetings("smtp.gmail.com", "hure.j@sfeir.com", "hure.j@sfeir.com", pass);

BirthdayGreetings bg = new BirthdayGreetings(new TextFileFriendDao("C:\\Users\\hure.j\\source\\repos\\CodingDojo-BirthdayGreetings\\myfriends.txt"), sender);
bg.FindSearchAndSend(new DateOnly(2022, 6, 16));