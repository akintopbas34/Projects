using Abp.Application.Services;
using SarfMalzemeStok.Service.Materials.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Materials
{
    public interface IMaterialService : IApplicationService
    {
        IEnumerable<MaterialDto> GetMaterial();
        MaterialDto GetMaterialById(int Id);
    }
}
