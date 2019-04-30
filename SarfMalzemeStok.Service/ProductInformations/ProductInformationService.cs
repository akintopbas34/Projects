using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SarfMalzemeStok.Domain.Context;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.ProductInformations.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.ProductInformations
{
    public class ProductInformationService: ApplicationService, IProductInformationService
    {
        private readonly IRepository<ProductInformation> _productInformationRepository;

        public ProductInformationService(IRepository<ProductInformation> productInformationRepository)
        {
            _productInformationRepository = productInformationRepository;
        }

        public IEnumerable<ProductInformationDto> GetProductInformation()
        {
            return _productInformationRepository.GetAll().Select(x => ObjectMapper.Map<ProductInformationDto>(x)).ToList();
        }

        public ProductInformationDto GetProductInformationByMaterial(int materialId)
        {
            return _productInformationRepository.GetAllIncluding(x => x.material).Select(x => ObjectMapper.Map<ProductInformationDto>(x)).Where(x => x.MaterialId == materialId).FirstOrDefault();
        }
    }
}
