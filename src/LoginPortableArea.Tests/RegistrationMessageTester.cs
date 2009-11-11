using LoginPortableArea.Messages;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace LoginPortableArea.Tests
{
	[TestFixture]
	public class RegistrationMessageTester
	{
		[Test]
		public void Message_should_return_its_message_in_tostring()
		{
			var message = new RegistrationMessage("foo");
			message.ToString().ShouldBe("foo");
		}
	}
}