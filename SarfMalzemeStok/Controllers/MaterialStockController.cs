using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.MaterialStocks;
using SarfMalzemeStok.Service.MaterialStocks.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialStockController : AbpController
    {
        private readonly IMaterialStockService _materialStockService;
        public MaterialStockController(IMaterialStockService materialStockService)
        {
            _materialStockService = materialStockService;
        }

        [HttpGet]
        public IEnumerable<MaterialStockDto> GetMaterialStocks()
        {
            return _materialStockService.GetMaterialStock();
        }

        [HttpGet("{materialId}")]
        public MaterialStockDto GetMaterialStocksByMaterial(int materialId)
        {
            return _materialStockService.GetMaterialStockByMaterial(materialId);
        }
    }
}