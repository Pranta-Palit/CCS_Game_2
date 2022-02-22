using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRole1.Models;

namespace WebRole1.Programs
{
    public class GlitchIssue
    {
        public static void FixGlitch()
        {
            GameContext db = new GameContext();

            var wins = (from title in db.TitleMasters
                                        where title.TitleId == "Noobie"
                                        select title.NumberOfWins
                       ).ToList()[0];

            List<UserData> users = (from t in db.UserDatas
                                      where t.NumberOfWins > 0
                                      select t
                                   )
                                   .ToList();


            foreach(UserData u in users)
            {
                if (db.TitleDatas.Find(u.UserId) != null)
                {
                    --u.NumberOfWins;
                    db.SaveChanges();

                    if(u.NumberOfWins < wins)
                    {
                        db.TitleDatas.Remove(db.TitleDatas.Find(u.UserId));
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}