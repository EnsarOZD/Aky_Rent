﻿using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<CustomerEntity> Customers { get; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
