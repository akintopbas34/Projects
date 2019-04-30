using Abp.Application.Services;
using SarfMalzemeStok.Service.AlternativeMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.AlternativeMaterials
{
    public interface IAlternativeMaterialService : IApplicationService
    {
        IEnumerable<AlternativeMaterialDto> GetAlternativeMaterial();
        IEnumerable<AlternativeMaterialDto> GetAlternativeMaterialById(int materialId);
    }
}
