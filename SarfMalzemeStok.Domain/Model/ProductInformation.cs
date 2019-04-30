using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class ProductInformation: Entity
    {
        public int MaterialId { get; set; }
        public int MalGirisiIslemeSuresi { get; set; }
        public double ToplamAcikSiparisMiktari { get; set; }
        public double AcikSATMiktari { get; set; }
        public DateTime ImalataSonVerilisTarihi { get; set; }
        public int DahiliUretimSuresi { get; set; }
        public double ToplamAcikSiparisTutari { get; set; }

        public Material material { get; set; }

    }
}
