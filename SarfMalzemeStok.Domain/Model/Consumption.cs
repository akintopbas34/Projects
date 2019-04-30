using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class Consumption: Entity
    {
        public int MaterialId { get; set; }
        public DateTime KullanimTarihi { get; set; }
        public int TuketimMiktari { get; set; }
        public string Birim { get; set; }

        public Material material { get; set; }
    }
}
