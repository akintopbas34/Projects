using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class HistoryInformationReport: Entity
    {
        public int MaterialId { get; set; }
        public string Process{ get; set; }
        public string PartNumber{ get; set; }
        public string DescPart{ get; set; }
        public string Operation{ get; set; }
        public string WorkStation{ get; set; }
        public string Consumable{ get; set; }
        public string OlcuBirimi{ get; set; }
        public string UPP{ get; set; }
        public string UPPDegisiklik{ get; set; }
        public string DegisiklikYapan{ get; set; }

        public Material material { get; set; }
    }
}
