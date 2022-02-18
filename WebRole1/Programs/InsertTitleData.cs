using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRole1.Models;

namespace WebRole1.Programs
{
    public class InsertTitleData
    {
        public static void addData(UserData player)
        {
            GameContext db = new GameContext();

            List<TitleMaster> titles = (from t in db.TitleMasters
                                        select t)
                                        .ToList();

            if (player.NumberOfWins >= titles[0].NumberOfWins)
            {
                if(db.TitleDatas.Find(player.UserId)==null)
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