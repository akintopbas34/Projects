using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.ProductInformations;
using SarfMalzemeStok.Service.ProductInformations.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductInformationController : AbpController
    {
        private readonly IProductInformationService _productInformationService;
        public ProductInformationController(IProductInformationService productInformationService)
        {
            _productInformationService = productInformationService;
        }

        [HttpGet]
        public IEnumerable<ProductInformationDto> GetProductInformations()
        {
            return _productInformationService.GetProductInformation();
        }

        [HttpGet("{materialId}")]
        public ProductInformationDto GetProductInformationsByMaterial(int materialId)
        {
            return _productInformationService.GetProductInformationByMaterial(materialId);
        }
    }
}