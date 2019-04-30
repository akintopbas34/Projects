using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.AlternativeMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.AlternativeMaterials
{
    public class AlternativeMaterialService : ApplicationService, IAlternativeMaterialService
    {
        private readonly IRepository<AlternativeMaterial> _alternativeMaterialRepository;
        public AlternativeMaterialService(IRepository<AlternativeMaterial> alternativeMaterialRepository)
        {
            _alternativeMaterialRepository = alternativeMaterialRepository;
        }
        public IEnumerable<AlternativeMaterialDto> GetAlternativeMaterial() => _alternativeMaterialRepository.GetAllIncluding(i=>i.material1, j => j.material2).Select(x => ObjectMapper.Map<AlternativeMaterialDto>(x)).ToList();

        public IEnumerable<AlternativeMaterialDto> GetAlternativeMaterialById(int materialId)
        {
            return _alternativeMaterialRepository.GetAllIncluding(x=>x.material2).Select(x => ObjectMapper.Map<AlternativeMaterialDto>(x)).Where(x => x.Material1Id == materialId).ToList();
        }
    }
}
