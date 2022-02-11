using System;
using System.Collections.Generic;
using System.Linq;
using WebRole1.Models;
using Westwind.Utilities;

namespace WebRole1.Programs
{
    public class Insert
    {
		public static void GenerateData()
        {
			var db = new GameContext();

			// this function will generate and insert 100 users data
			List<UserData> userList = new List<UserData>();

			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			for (int i = 0; i < 100; i++)
			{
				userList.Add(new UserData
				{
					UserId = DataUtils.GenerateUniqueId(10),
					UserName = new string(Enumerable.Repeat(chars, 8)
									.Select(s => s[random.Next(s.Length)]).ToArray()),
					NumberOfWins = 0,
					NumberOfDefaeats = 0,
					NumberOfDraws = 0
				});
			}
			db.UserDatas.AddRange(userList);
			db.SaveChanges();
		}
    }
}