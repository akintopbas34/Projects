using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class MaterialStock:Entity
    {
        public int MaterialId { get; set; }
        public double DepodakiMiktar { get; set; }
        public double AtolyedekiMiktar { get; set; }
        public double TedarikAsamasindakiMiktar { get; set; }
        public double StokMiktari { get; set; }

        public Material material{ get; set; }
    }
}
