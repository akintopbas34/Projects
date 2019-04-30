using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SarfMalzemeStok.Domain.Context;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.MaterialStocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.MaterialStocks
{
    public class MaterialStockService : ApplicationService, IMaterialStockService
    {
        private readonly IRepository<MaterialStock> _materialStockRepository;
        public MaterialStockService(IRepository<MaterialStock> materialStockRepository)
        {
            _materialStockRepository = materialStockRepository;
        }

        public IEnumerable<MaterialStockDto> GetMaterialStock() => _materialStockRepository.GetAll().Select(x => ObjectMapper.Map<MaterialStockDto>(x)).ToList();

        public MaterialStockDto GetMaterialStockByMaterial(int materialId)
        {
            return _materialStockRepository.GetAllIncluding(x=>x.material).Select(x => ObjectMapper.Map<MaterialStockDto>(x)).FirstOrDefault(x => x.MaterialId == materialId);
        }
    }
}
