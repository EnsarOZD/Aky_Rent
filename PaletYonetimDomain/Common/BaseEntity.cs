using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Common
{
	public abstract class BaseEntity
	{
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }

	}
}
