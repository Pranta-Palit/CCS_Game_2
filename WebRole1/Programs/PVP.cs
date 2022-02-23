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
        public static List<UserData> participants = new List<UserData>();
        public static void GamePlay()
        {
            GameContext db = new GameContext();
            Random random = new Random();
            string path = @"F:\Visual Studio Workstation\Game Workspace\CCS Game Task 2\WebRole1\Programs\Output\";

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
            File.WriteAllText(path+"player.txt", "Self = "+ self + "\n Opponents = [" + String.Join(Environment.NewLine, opponents)+ "]");

            foreach(UserData x in opponents)
            {
                // -1 : loss, 0 : draw, 1 : win
                int self_win_state = random.Next(-1, 2);
                //int self_win = 0, opponent_win = 0, self_loss = 0, opponent_loss = 0, self_draw = 0, opponent_draw = 0;

                switch (self_win_state)
                {
                    case -1:
                        //self_loss = ++self.NumberOfDefaeats;
                        //opponent_win = ++x.NumberOfWins;

                        var p1 = db.UserDatas.Find(self.UserId);
                        p1.NumberOfDefaeats = ++self.NumberOfDefaeats;
                        db.SaveChanges();

                        var p2 = db.UserDatas.Find(x.UserId);
                        p2.NumberOfWins = ++x.NumberOfWins;
                        db.SaveChanges();

                        InsertTitleData.addData(x);
                        break;
                    case 1:
                        //self_win = ++self.NumberOfWins;
                        //opponent_loss = ++x.NumberOfDefaeats;

                        var q1 = db.UserDatas.Find(self.UserId);
                        q1.NumberOfWins = ++self.NumberOfWins;
                        db.SaveChanges();

                        var q2 = db.UserDatas.Find(x.UserId);
                        q2.NumberOfDefaeats = ++x.NumberOfDefaeats;
                        db.SaveChanges();

                        InsertTitleData.addData(self);
                        break;
                    case 0:
                        //self_draw = ++self.NumberOfDraws;
                        //opponent_draw = ++x.NumberOfDraws;

                        var r1 = db.UserDatas.Find(self.UserId);
                        r1.NumberOfDraws = ++self.NumberOfDraws;
                        db.SaveChanges();

                        var r2 = db.UserDatas.Find(x.UserId);
                        r2.NumberOfDraws = ++x.NumberOfDraws;
                        db.SaveChanges();
                        break;
                }


                //var p1 = db.UserDatas.Find(self.UserId);
                //p1.NumberOfWins = self_win;
                //p1.NumberOfDefaeats = self_loss;
                //p1.NumberOfDraws = self_draw;
                //db.SaveChanges();

                //var p2 = db.UserDatas.Find(x.UserId);
                //p2.NumberOfWins = opponent_win;
                //p2.NumberOfDefaeats = opponent_loss;
                //p2.NumberOfDraws = opponent_draw;
                //db.SaveChanges();

                File.AppendAllText(path + "results.txt", "[Self Win State:"+self_win_state+"]\nPlayer1 = " + self + " win="+self.NumberOfWins + " loss=" + self.NumberOfDefaeats + " draw=" + self.NumberOfDraws 
                                                                                 +"\nPlayer2 = " + x + " win="+ x.NumberOfWins + " loss=" + x.NumberOfDefaeats + " draw=" + x.NumberOfDraws + "\n\n");
                //File.Appe(path + "player.txt", "Player = " + self + "\n "  +"]");

            }


        }
    }
}