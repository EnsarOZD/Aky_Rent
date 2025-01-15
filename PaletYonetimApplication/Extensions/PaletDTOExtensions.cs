using PaletYonetimApplication.DTO;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Extensions
{
	public static class PaletDTOExtensions
	{
		public static PaletDto ToDTO(this PalletEntity palet)
		{
			return new PaletDto
			{
				PaletNo = palet.PaletNo,
				Address = $"Koridor: {palet.RackAddress.CorridorNumber},Yön:{palet.RackAddress.CorridorSide}, Sıra: {palet.RackAddress.RowNumber}, Kat: {palet.RackAddress.Level}",
				AddressId=palet.AddressId,
				CustomerName = palet.Customer?.Name ?? "Bilinmiyor",
				CustomerId=palet.CustomerId,
				Situation = palet.Situation,
				EnteryDate = palet.EnteryDate,
				ExitDate = palet.ExitDate
			};
		}

		public static PalletEntity ToEntity(this PaletDto dto,int addressId , int customerId)
		{
			return new PalletEntity
			{
				PaletNo = dto.PaletNo,
				AddressId = addressId,
				CustomerId = customerId,
				Situation = dto.Situation,
				EnteryDate = dto.EnteryDate,
				ExitDate = dto.ExitDate
			};
		}
	}
}
