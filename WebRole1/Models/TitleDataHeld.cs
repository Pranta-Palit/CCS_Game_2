using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    public class TitleDataHeld
    {
		[Key]
		public string TitleId { get; set; }

        public string UserId { get; set; } // fkey
        [ForeignKey("UserId")]
        public virtual UserData UserData { get; set; }

        //public override string ToString()
        //{
        //	return "[" + UserId + " - " + UserName + " - " + RankPoints + "]";
        //}
    }
}