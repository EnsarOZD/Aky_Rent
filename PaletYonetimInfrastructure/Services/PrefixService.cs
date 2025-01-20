using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimInfrastructure.Services
{
	public class PrefixService :IPrefixService
	{
		private readonly IApplicationDbContext _context;

		public PrefixService(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<string> GetPrefixAsync(CancellationToken cancellationToken)
		{
			var prefixSetting = await _context.ConfigurationSettings
				.FirstOrDefaultAsync(c => c.Key == "DefaultPrefix", cancellationToken);

			return prefixSetting?.Value ?? "PLT"; // Varsayılan değer
		}

		public async Task UpdatePrefixAsync(string newPrefix, CancellationToken cancellationToken)
		{
			var prefixSetting = await _context.ConfigurationSettings
				.FirstOrDefaultAsync(c => c.Key == "DefaultPrefix", cancellationToken);

			if (prefixSetting != null)
			{
				prefixSetting.Value = newPrefix;
			}
			else
			{
				_context.ConfigurationSettings.Add(new ConfigurationSetting
				{
					Key = "DefaultPrefix",
					Value = newPrefix
				});
			}

			var pallets = await _context.Pallets.ToListAsync(cancellationToken);
			
			foreach (var pallet in pallets)
			{
				pallet.PalletName = $"{newPrefix}-{pallet.PalletID:D3}";
			}

			await _context.SaveChangesAsync(cancellationToken);
		}

	}
}
