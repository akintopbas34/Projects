using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class Company:Entity
    {
        public string FirmaKodu { get; set; }
        public string FirmaAdi { get; set; }
    }
}
