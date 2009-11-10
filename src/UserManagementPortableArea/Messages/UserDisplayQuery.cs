using System.Collections.Generic;
using MvcContrib.PortableAreas;
using UserManagementPortableArea.Models;

namespace UserManagementPortableArea.Messages
{
	public class UserDisplayQuery : IQueryMessage<IEnumerable<UserDisplay>>
	{
		public IEnumerable<UserDisplay> Result { get; set; }
	}
}