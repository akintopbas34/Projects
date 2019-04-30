using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.AlternativeMaterials;
using SarfMalzemeStok.Service.AlternativeMaterials.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlternativeMaterialController : AbpController
    {
        private readonly IAlternativeMaterialService _alternativeMaterialService;
        public AlternativeMaterialController(IAlternativeMaterialService alternativeMaterialService)
        {
            _alternativeMaterialService = alternativeMaterialService;
        }

        [HttpGet]
        public IEnumerable<AlternativeMaterialDto> GetAlternativeMaterials()
        {
            return _alternativeMaterialService.GetAlternativeMaterial();
        }

        [HttpGet("{materialId}")]
        public IEnumerable<AlternativeMaterialDto> GetAlternativeMaterialById(int materialId)
        {
            return _alternativeMaterialService.GetAlternativeMaterialById(materialId);
        }
    }
}