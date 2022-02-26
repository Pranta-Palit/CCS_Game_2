using WebRole1.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;

namespace WebRole1.Programs
{
    public class CreateRank
    {
        public string RankUserName;
        public int WinRate;
        public static double Percentage(int x, int y, int z)
        {
            if((x+y+z) == 0)
            {
                return 0;
            }
            return (x / (double)(x + y + z)) * 100;
        }
        public static void print(string result)
        {
            GenerateLog.LogMethodCall(result);
        }
        public static void GenerateRank()
        {
            GenerateLog.LogMethodCall("Generating Rank");

            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\Programs\Output\";
            
            GameContext db = new GameContext();

            List<CreateRank> ranking = new List<CreateRank>();
            foreach(UserData x in PVP.participants)
            {
                var obj = db.UserDatas.Find(x.UserId);
                ranking.Add(
                    new CreateRank
                    {
                        RankUserName = obj.UserName,
                        WinRate = Convert.ToInt32(Percentage(obj.NumberOfWins,obj.NumberOfDefaeats,obj.NumberOfDraws))
                    });
            }

            var finalRank = ranking.OrderByDescending(x => x.WinRate)
                            .ThenBy(x => x.RankUserName)
                            .Take(10)
                            .ToList();
            int i = 0;
            string Rank = "";
            foreach (var x in finalRank)
            {
                Rank += $"[{++i} - {x.RankUserName} - {x.WinRate}%]\n";
            }

            File.WriteAllText(path+"rank.txt", Rank);

            print(Rank);
        }
    }
}