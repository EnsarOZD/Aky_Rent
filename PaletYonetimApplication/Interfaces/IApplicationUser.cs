using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Interfaces
{
	public interface IApplicationUser
	{
		string Id { get; }
		string FirstName { get; }
		string LastName { get; }
		string Email { get; }
		string FullName { get; }
		DateTime CreatedTime { get; }
		DateTime? UpdatedTime { get; }
	}
}
