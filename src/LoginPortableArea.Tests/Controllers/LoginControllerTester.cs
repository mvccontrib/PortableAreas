using System;
using LoginPortableArea.Controllers;
using LoginPortableArea.Models;
using MvcContrib.PortableAreas;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;

namespace LoginPortableArea.Tests.Controllers
{
	[TestFixture]
	public class LoginControllerTester
	{
		[Test]
		public void Index_should_render_the_default_view()
		{
			var controller = new LoginController();
			controller.Index()
				.AssertViewRendered()
				.ForView("");
		}

		[Test]
		public void Index_should_render_the_default_view_with_the_input()
		{
			PortableArea.Bus.Clear();
			PortableArea.Bus.Add( typeof(NullMessageHandler));

			var factory = MockRepository.GenerateStub<IMessageHandlerFactory>();
			factory.Stub(handlerFactory => handlerFactory.Create(null)).IgnoreArguments().Return(
				MockRepository.GenerateStub<IMessageHandler>());

			PortableArea.Bus.SetMessageHandlerFactory(factory);

			var controller = new LoginController();

			controller.Index(new LoginInput())
				.AssertViewRendered()
				.ForView("")
				.WithViewData<LoginInput>();
		}
	}

	public class NullMessageHandler:IMessageHandler
	{
		private bool _handled;

		public void Handle(object message)
		{
			_handled = true;
		}

		public bool CanHandle(Type type)
		{
			return true;
		}
	}
}