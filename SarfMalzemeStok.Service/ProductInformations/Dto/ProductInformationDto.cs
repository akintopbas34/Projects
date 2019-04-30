using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.ProductInformations.Dto
{
    [AutoMap(typeof(ProductInformation))]
    public class ProductInformationDto: EntityDto
    {
        public int MaterialId { get; set; }
        public int MalGirisiIslemeSuresi { get; set; }
        public double ToplamAcikSiparisMiktari { get; set; }
        public double AcikSATMiktari { get; set; }
        public DateTime ImalataSonVerilisTarihi { get; set; }
        public int DahiliUretimSuresi { get; set; }
        public double ToplamAcikSiparisTutari { get; set; }

        public Material material { get; set; }
    }
}
