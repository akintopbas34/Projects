using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class Wip: Entity
    {
        public int MaterialId { get; set; }
        public string  TezgahAdi { get; set; }

        public Material material { get; set; }
    }
}
