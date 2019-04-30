using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class Material : Entity
    {
        public string MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public string MaliyetSiniflandirmasi { get; set; }
        public int MalzemeninKullanimOmru { get; set; }
        public double EmniyetStok { get; set; }
        public double YenidenSiparisSeviyesi { get; set; }
        public string SabitPartiBuyuklugu { get; set; }
        public double YillikTasmaOrani { get; set; }
        public string MalzemeHakkindaNotlar { get; set; }
        public string TeknikResim { get; set; }

    }
}
