using PaletYonetimDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class ConfigurationSetting 
	{
		public int Id { get; set; }
		public string Key { get; set; } // Örneğin: "DefaultPrefix"
		public string Value { get; set; } // Örneğin: "PRS"
	}
}
