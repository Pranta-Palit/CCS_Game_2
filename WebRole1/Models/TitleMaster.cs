using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    public class TitleMaster
    {
		[Key]
		public string SchoolTitle { get; set; }
		public string TitleId { get; set; } // fkey
		[ForeignKey("TitleId")]
		public virtual TitleDataHeld TitleDataHeld { get; set; }
		public int NumberOfWins { get; set; }

		//public override string ToString()
		//{
		//	return "[" + UserId + " - " + UserName + " - " + RankPoints + "]";
		//}
	}
}