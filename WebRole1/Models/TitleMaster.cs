using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    public class TitleMaster
    {
		[Key]
		public string TitleId { get; set; }
		public string TitleName { get; set; }
		public int NumberOfWins { get; set; }

		//public string TitleId { get; set; } // fkey
		//[ForeignKey("TitleId")]
		//public virtual TitleData TitleData { get; set; }

		//public override string ToString()
		//{
		//	return "[" + UserId + " - " + UserName + " - " + RankPoints + "]";
		//}
	}
}