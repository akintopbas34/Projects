using Abp.Modules;
using SarfMalzemeStok.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SarfMalzemeStok.Service
{
    [DependsOn(typeof(DomainModule))]
    public class ServiceModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
