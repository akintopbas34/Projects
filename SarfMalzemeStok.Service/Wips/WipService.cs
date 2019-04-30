using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.Wips.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.Wips
{
    public class WipService : ApplicationService, IWipService
    {
        private readonly IRepository<Wip> _wipRepository;
        public WipService(IRepository<Wip> wipRepository)
        {
            _wipRepository = wipRepository;
        }

        public IEnumerable<WipDto> GetWip()
        {
            return _wipRepository.GetAll().Select(x => ObjectMapper.Map<WipDto>(x)).ToList();
        }

        public WipDto GetWipByMaterial(int materialId)
        {
            return _wipRepository.GetAllIncluding(x=>x.material).Select(x => ObjectMapper.Map<WipDto>(x)).FirstOrDefault(x => x.MaterialId == materialId);
        }
    }
}
