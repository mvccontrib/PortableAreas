using MvcContrib.PortableAreas;

namespace LoginPortableArea.Messages
{
	public class ForgotPasswordResult:ICommandResult
	{
		public bool Success { get; set; }

		public string Message { get; set; }
	}
}