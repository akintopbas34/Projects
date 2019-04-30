using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.Materials;
using SarfMalzemeStok.Service.Materials.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MaterialController : AbpController
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public IEnumerable<MaterialDto> GetMaterials()
        {
            return _materialService.GetMaterial();
        }

        [HttpGet("{Id}")]
        public MaterialDto GetMaterialById(int Id)
        {
            return _materialService.GetMaterialById(Id);
        }
    }
}