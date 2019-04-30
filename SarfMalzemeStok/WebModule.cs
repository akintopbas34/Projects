using Abp.Modules;
using SarfMalzemeStok.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SarfMalzemeStok
{
    [DependsOn(typeof(ServiceModule))]
    public class WebModule : AbpModule
    {

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
