using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class ProductGroupConsumptionReport: Entity
    {
        public int MaterialId { get; set; }
        public string Kod { get; set; }
        public string Tanim { get; set; }
        public string SiparisNo { get; set; }
        public DateTime TerminTarihi { get; set; }
        public int TerminMiktari { get; set; }
        public string BatchNo { get; set; }
        public int AsgariKalanSure { get; set; }
        public DateTime TeslimatTarihi { get; set; }
        public DateTime KaliteKontrolTarihi{ get; set; }
        public string Inspector { get; set; }
        public string Durum { get; set; }

        public Material material { get; set; }
    }
}
