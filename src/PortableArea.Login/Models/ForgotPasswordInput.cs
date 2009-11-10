using System.ComponentModel.DataAnnotations;

namespace LoginPortableArea.Models
{
	public class ForgotPasswordInput
	{
		[Required]
		public string Username { get; set; }
	}
}