using System.ComponentModel.DataAnnotations;

namespace WebRole1.Models
{
    public class UserData
    {
		[Key]
		public string UserId { get; set; }
		public string UserName { get; set; }
		public int NumberOfWins { get; set; }
		public int NumberOfDefaeats { get; set; }
		public int NumberOfDraws { get; set; }

        public override string ToString()
        {
            return UserId;
        }

    }
}