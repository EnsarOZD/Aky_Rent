using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Interfaces
{
	public interface IPrefixService
	{
		Task<string> GetPrefixAsync(CancellationToken cancellationToken);
		Task UpdatePrefixAsync(string newPrefix, CancellationToken cancellationToken);
	}
}
