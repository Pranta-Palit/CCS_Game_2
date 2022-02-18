using WebRole1.Models;

namespace WebRole1.Programs
{
    public class InsertMasterTitle
    {
        public static void addTitle(string id, string name, int wins)
        {
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
    }
}