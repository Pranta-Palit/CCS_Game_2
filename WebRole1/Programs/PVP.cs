using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRole1.Models;
using System.IO;

namespace WebRole1.Programs
{
    public class PVP
    {
        public static void GamePlay()
        {
            Random random = new Random();
            string myFile = @"F:\Visual Studio Workstation\Game Workspace\CCS Game Task 2\WebRole1\Programs\Output\players.txt";

            GameContext db = new GameContext();
            List<UserData> players = (from t in db.UserDatas
                                    select t)
                                    .ToList();

            UserData self = players[random.Next(0, 100)];

            List<UserData> opponents = new List<UserData>();
            for(int i=0; i<10; ++i)
            {
                int index = random.Next(0, 100);
                if(self != players[index] && !opponents.Contains(players[index]))
                {
                    opponents.Add(players[index]);
                }
                else
                {
                    --i;
                }
            }
            File.WriteAllText(myFile, "Self = "+ self + "\n Opponents = [" + String.Join(Environment.NewLine, opponents)+ "]");

            
        }
    }
}