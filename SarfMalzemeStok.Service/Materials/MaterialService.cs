using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Context;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.Materials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.Materials
{
    public class MaterialService : ApplicationService, IMaterialService
    {
        private readonly IRepository<Material> _materialRepository;
        public MaterialService(IRepository<Material> materialRepository, SarfMalzemeStokContext dbContext)
        {
            _materialRepository = materialRepository;
        }

        public IEnumerable<MaterialDto> GetMaterial() => _materialRepository
            .GetAll()
            .Select(x => ObjectMapper.Map<MaterialDto>(x))
            .ToList();

        public MaterialDto GetMaterialById(int Id)
        {
            return ObjectMapper.Map<MaterialDto>(_materialRepository.Get(Id));
        }
    }
}
