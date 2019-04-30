using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class Order:Entity
    {
        public int CompanyMaterialId { get; set; }
        public DateTime SiparisVerilmeZamani { get; set; }
        public bool SiparisinGerceklesmeDurumu { get; set; }
        public DateTime SiparisTamamlanmaZamani { get; set; }
        public double SiparisVermeMaliyeti { get; set; }

        public CompanyMaterial companyMaterial { get; set; }
    }
}
