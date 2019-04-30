using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SarfMalzemeStok.Domain.Model;

namespace SarfMalzemeStok.Service.Materials.Dto
{
    [AutoMap(typeof(Material))]
    public class MaterialDto : EntityDto
    {
        public string MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public string MaliyetSiniflandirmasi { get; set; }
        public int MalzemeninKullanimOmru { get; set; }
        public double EmniyetStok { get; set; }
        public double YenidenSiparisSeviyesi { get; set; }
        public string SabitPartiBuyuklugu { get; set; }
        public double YillikTasmaOrani { get; set; }
        public string MalzemeHakkindaNotlar { get; set; }
        public string TeknikResim { get; set; }
    }
}
