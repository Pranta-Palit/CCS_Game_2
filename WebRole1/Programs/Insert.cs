using System;
using System.Collections.Generic;
using System.Linq;
using WebRole1.Models;
using Westwind.Utilities;
using System.IO;

namespace WebRole1.Programs
{
    public class Insert
    {
		

		public static void GenerateUserData(int NumberOfUsers)
        {
			GenerateLog.InitLogFile();
			GenerateLog.LogMethodCall(NumberOfUsers);

			var db = new GameContext();

			// this function will generate and insert 100 users data
			List<UserData> userList = new List<UserData>();

			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			for (int i = 0; i < NumberOfUsers; i++)
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

		public static void InsertMasterTitle(string id, string name, int wins)
		{
			GenerateLog.LogMethodCall(id,name,wins);

			var db = new GameContext();

			var model = new TitleMaster()
			{
				TitleId = id,
				TitleName = name,
				NumberOfWins = wins,
			};

			db.TitleMasters.Add(model);
			db.SaveChanges();
		}

		public static void InsertTitleData(UserData player)
		{
			GenerateLog.LogMethodCall($"Adding to Title Data: \n UserId: {player.UserId}\n");

			GameContext db = new GameContext();

			List<TitleMaster> titles = (from t in db.TitleMasters
										select t)
										.ToList();

			if (player.NumberOfWins >= titles[0].NumberOfWins)
			{
				if (db.TitleDatas.Find(player.UserId) == null)
				{
					db.TitleDatas.Add
					(
						new TitleData()
						{
							UserId = player.UserId,
							TitleId = titles[0].TitleId
						}
					);
					db.SaveChanges();
				}
			}
		}
	}
}