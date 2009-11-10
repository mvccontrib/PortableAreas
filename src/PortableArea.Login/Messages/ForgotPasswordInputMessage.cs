using LoginPortableArea.Models;
using MvcContrib.PortableAreas;

namespace LoginPortableArea.Messages
{
	public class ForgotPasswordInputMessage : ICommandMessage<ForgotPasswordResult>
	{
		public ForgotPasswordInput Input { get; set; }
		public ForgotPasswordResult Result { get; set; }
	}
}