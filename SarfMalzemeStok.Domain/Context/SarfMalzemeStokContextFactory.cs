using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SarfMalzemeStok.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Context
{
    public class SarfMalzemeStokContextFactory : IDesignTimeDbContextFactory<SarfMalzemeStokContext>
    {
        public SarfMalzemeStokContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SarfMalzemeStokContext>();
            builder.UseSqlServer(DbConfiguration.GetConnectionString("SarfMalzemeStok"));
            return new SarfMalzemeStokContext(builder.Options);
        }
    }
}
