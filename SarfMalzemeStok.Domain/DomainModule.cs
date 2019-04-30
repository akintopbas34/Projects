using Abp.AspNetCore;
using Abp.AutoMapper;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SarfMalzemeStok.Domain.Context;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SarfMalzemeStok.Domain
{
    [DependsOn(typeof(AbpAspNetCoreModule),
               typeof(AbpEntityFrameworkCoreModule),
               typeof(AbpCastleLog4NetModule),
               typeof(AbpAutoMapperModule)
               )]
    public class DomainModule : AbpModule
    {
        private IConfiguration _configuration;
        public DomainModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void PreInitialize()
        {
            var constr = _configuration.GetConnectionString("SarfMalzemeStok");

            Configuration.Modules.AbpEfCore().AddDbContext<SarfMalzemeStokContext>(options =>
            {
                options.DbContextOptions.UseSqlServer(constr);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
