using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.RefusalInformations.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.RefusalInformations
{
    public class RefusalInformationService : ApplicationService, IRefusalInformationService
    {
        private readonly IRepository<RefusalInformation> _refusalInformationRepository;
        public RefusalInformationService(IRepository<RefusalInformation> refusalInformationRepository)
        {
            _refusalInformationRepository = refusalInformationRepository;
        }

        public IEnumerable<RefusalInformationDto> GetRefusalInformation()
        {
            return _refusalInformationRepository.GetAll().Select(x => ObjectMapper.Map<RefusalInformationDto>(x)).ToList();
        }

        public RefusalInformationDto GetRefusalInformationByOrder(int orderId)
        {
            return _refusalInformationRepository.GetAllIncluding(x => x.order).Select(x => ObjectMapper.Map<RefusalInformationDto>(x)).Where(x => x.OrderId == orderId).FirstOrDefault();
        }
    }
}
