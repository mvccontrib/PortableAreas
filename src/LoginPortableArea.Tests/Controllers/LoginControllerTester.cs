using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LoginPortableArea.Controllers;
using LoginPortableArea.Messages;
using LoginPortableArea.Models;
using MvcContrib;
using MvcContrib.PortableAreas;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace LoginPortableArea.Tests.Controllers
{
	[TestFixture]
	public class LoginControllerTester
	{
		[Test]
		public void Forgot_Password_should_render_the_default_view()
		{
			var controller = new LoginController();
			controller.ForgotPassword()
				.AssertViewRendered()
				.ForView("");
		}

		[Test]
		public void Forgot_password_should_render_the_default_view_with_the_input()
		{
			bool handlerWasCalled = false;
			Bus.Instance = new MockApplicationBus<ForgotPasswordInputMessage>(message =>
			                                                                  	{
			                                                                  		message.Result.Success = false;
			                                                                  		handlerWasCalled = true;
			                                                                  	}
				);

			var controller = new LoginController();

			var input = new ForgotPasswordInput();
			controller.ForgotPassword(input)
				.AssertViewRendered()
				.ForView("")
				.WithViewData<ForgotPasswordInput>().ShouldEqual(input, "");

			Assert.That(handlerWasCalled, Is.True);
		}

		[Test]
		public void Forgot_password_should_render_the_sent_message_view()
		{
			Bus.Instance = new MockApplicationBus<ForgotPasswordInputMessage>(message =>
			                                                                  message.Result.Success = true);

			var controller = new LoginController();

			var input = new ForgotPasswordInput();
			controller.ForgotPassword(input)
				.AssertViewRendered()
				.ForView("forgotpasswordsent");
		}


		[Test]
		public void Index_should_render_the_view_with_loginInput()
		{
			bool handlerWasCalled = false;
			Bus.Instance = new MockApplicationBus<LoginInputMessage>(message =>
			                                                         	{
			                                                         		message.Result.Success = false;
			                                                         		handlerWasCalled = true;
			                                                         	}
				);

			var controller = new LoginController();

			var input = new LoginInput();
			controller.Index(input)
				.AssertViewRendered()
				.ForView("")
				.WithViewData<LoginInput>().ShouldBe(input);

			handlerWasCalled.ShouldBe(true);
		}

		[Test]
		public void Index_should_call_forms_auth_login()
		{
			bool handlerWasCalled = false;
			Bus.Instance = new MockApplicationBus<LoginInputMessage>(message =>
			                                                         	{
			                                                         		message.Result.Success = true;
			                                                         		handlerWasCalled = true;
			                                                         	}
				);

			var controller = new LoginController();

			var input = new LoginInput();
			ActionResult result = controller.Index(input);

			Assert.IsAssignableFrom<LoginActionResult>(result);

			handlerWasCalled.ShouldBe(true);
		}

		[Test]
		public void Index_should_render_the_default_view()
		{
			var controller = new LoginController();
			controller.Index()
				.AssertViewRendered()
				.ForView("");
		}

		[Test]
		public void logout_should_redirect_to_the_site_root()
		{
			var controller = new LoginController();
			ActionResult result = controller.Logout();
			Assert.IsAssignableFrom<LogoutActionResult>(result);
		}


		public class MockApplicationBus<T> : List<Type>, IApplicationBus where T : IEventMessage
		{
			private readonly Action<T> _sendCallback;

			public MockApplicationBus(Action<T> sendCallback)
			{
				_sendCallback = sendCallback;
			}

			public void Send(IEventMessage eventMessage)
			{
				_sendCallback((T) eventMessage);
			}

			public void SetMessageHandlerFactory(IMessageHandlerFactory factory)
			{
				throw new NotImplementedException();
			}
		}

		public class MockApplicationBus : MockApplicationBus<IEventMessage>
		{
			public MockApplicationBus(Action<IEventMessage> sendCallback) : base(sendCallback)
			{
			}
		}
	}

	public class FakeMessageHandler : IMessageHandler
	{
		public bool Handled;
		private readonly bool _canHandle;
		public object Message { get; set; }

		public FakeMessageHandler(bool canHandle)
		{
			_canHandle = canHandle;
		}

		public void Handle(object message)
		{
			Message = message;
			Handled = true;
		}

		public bool CanHandle(Type type)
		{
			return _canHandle;
		}
	}
}