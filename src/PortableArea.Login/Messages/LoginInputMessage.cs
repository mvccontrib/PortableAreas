using System.ComponentModel.DataAnnotations;
using LoginPortableArea.Models;
using MvcContrib.PortableAreas;

namespace LoginPortableArea.Messages
{
	public class LoginInputMessage : ICommandMessage<LoginResult>
	{
		[Required]
		public LoginResult Result { get; set; }

		[Required]
		public LoginInput Input { get; set; }
	}
}