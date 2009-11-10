using System.Collections.Generic;
using MvcContrib.PortableAreas;
using UserManagementPortableArea.Models;

namespace UserManagementPortableArea.Messages
{
	public class UserDisplayQuery : ICommandMessage<IEnumerable<UserDisplay>>
	{
		public IEnumerable<UserDisplay> Result { get; set; }
	}
}