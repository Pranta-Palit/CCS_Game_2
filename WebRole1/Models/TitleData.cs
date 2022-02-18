using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    public class TitleData
    {
        [Key]
        public string UserId { get; set; } // fkey
        [ForeignKey("UserId")]
        public virtual UserData UserData { get; set; }

        public string TitleId { get; set; } // fkey
        [ForeignKey("TitleId")]
        public virtual TitleMaster TitleMaster { get; set; }

        

        //public override string ToString()
        //{
        //	return "[" + UserId + " - " + UserName + " - " + RankPoints + "]";
        //}
    }
}