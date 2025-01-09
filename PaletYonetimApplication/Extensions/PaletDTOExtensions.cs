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
		public static PaletDto ToDTO(this PaletEntity palet)
		{
			return new PaletDto
			{
				PaletNo = palet.PaletNo,
				Address = $"Koridor: {palet.RackAddress.CorridorNumber}, Kat: {palet.RackAddress.Level}, Sıra: {palet.RackAddress.RowNumber}",
				AddressId=palet.AddressId,
				CustomerName = palet.Customer?.Name ?? "Bilinmiyor",
				CustomerId=palet.CustomerId,
				Situation = palet.Situation,
				EnteryDate = palet.EnteryDate,
				ExitDate = palet.ExitDate
			};
		}

		public static PaletEntity ToEntity(this PaletDto dto,int addressId , int customerId)
		{
			return new PaletEntity
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
