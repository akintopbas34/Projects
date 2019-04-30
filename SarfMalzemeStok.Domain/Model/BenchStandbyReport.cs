using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class BenchStandbyReport: Entity
    {
        public int MaterialId { get; set; }
        public string WorkCenter{ get; set; }
        public string MasrafYeri { get; set; }
        public string Parca { get; set; }
        public string Operation { get; set; }
        public string YakaNo { get; set; }
        public string TalepNumarasi { get; set; }
        public string BeklemeSuresi { get; set; }

        public Material material { get; set; }
    }
}
