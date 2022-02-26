using System;
using System.Collections.Generic;
using System.Linq;
using WebRole1.Models;
using System.IO;

namespace WebRole1.Programs
{
    public class PVP
    {
        public static List<UserData> participants = new List<UserData>();
        public static void GamePlay()
        {
            GenerateLog.LogMethodCall("Player vs Player Game Play");

            GameContext db = new GameContext();
            Random random = new Random();

            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\Programs\Output\";

            List<UserData> players = (from t in db.UserDatas
                                    select t)
                                    .ToList();

            UserData self = players[random.Next(0, 100)];
            participants.Add(self);

            List<UserData> opponents = new List<UserData>();
            for(int i=0; i<10; ++i)
            {
                int index = random.Next(0, 100);
                if(self != players[index] && !opponents.Contains(players[index]))
                {
                    opponents.Add(players[index]);
                    participants.Add(players[index]);
                }
                else
                {
                    --i;
                }
            }

            File.WriteAllText(path+"player.txt", "Self = " + self + "\nOpponents = [" + String.Join(Environment.NewLine, opponents)+ "]");
            
            if (File.Exists(path + "results.txt"))
            {
                File.Delete(path + "results.txt");
            }

            foreach (UserData x in opponents)
            {
                // -1 : loss, 0 : draw, 1 : win
                int self_win_state = random.Next(-1, 2);
                
                switch (self_win_state)
                {
                    case -1:
                        var p1 = db.UserDatas.Find(self.UserId);
                        p1.NumberOfDefaeats = ++self.NumberOfDefaeats;
                        db.SaveChanges();

                        var p2 = db.UserDatas.Find(x.UserId);
                        p2.NumberOfWins = ++x.NumberOfWins;
                        db.SaveChanges();

                        Insert.InsertTitleData(x);
                        break;
                    case 1:
                        var q1 = db.UserDatas.Find(self.UserId);
                        q1.NumberOfWins = ++self.NumberOfWins;
                        db.SaveChanges();

                        var q2 = db.UserDatas.Find(x.UserId);
                        q2.NumberOfDefaeats = ++x.NumberOfDefaeats;
                        db.SaveChanges();

                        Insert.InsertTitleData(self);
                        break;
                    case 0:
                        var r1 = db.UserDatas.Find(self.UserId);
                        r1.NumberOfDraws = ++self.NumberOfDraws;
                        db.SaveChanges();

                        var r2 = db.UserDatas.Find(x.UserId);
                        r2.NumberOfDraws = ++x.NumberOfDraws;
                        db.SaveChanges();
                        break;
                }


                File.AppendAllText(path + "results.txt", "[Self Win State:"+self_win_state+"]\nPlayer1 = " + self + " win="+self.NumberOfWins + " loss=" + self.NumberOfDefaeats + " draw=" + self.NumberOfDraws 
                                                                                 +"\nPlayer2 = " + x + " win="+ x.NumberOfWins + " loss=" + x.NumberOfDefaeats + " draw=" + x.NumberOfDraws + "\n\n");
            }


        }
    }
}