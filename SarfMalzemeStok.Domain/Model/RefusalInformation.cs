using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class RefusalInformation: Entity
    {
        public int OrderId { get; set; }
        public string IadeNedeni { get; set; }
        public DateTime IadeTarihi { get; set; }
        public int IadeMiktari { get; set; }

        public Order order { get; set; }
    }
}
