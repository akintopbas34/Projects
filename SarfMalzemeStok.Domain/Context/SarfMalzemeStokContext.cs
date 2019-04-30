using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Domain.Context
{
    public class SarfMalzemeStokContext : AbpDbContext
    {
        public DbSet<Material> Material { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyMaterial> CompanyMaterial { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<AlternativeMaterial> AlternativeMaterial { get; set; }
        public DbSet<BenchStandbyReport> BenchStandbyReport { get; set; }
        public DbSet<Consumption> Consumption { get; set; }
        public DbSet<HistoryInformationReport> HistoryInformationReport { get; set; }
        public DbSet<ProcessingTimeReport> ProcessingTimeReport { get; set; }
        public DbSet<MaterialStock> MaterialStock { get; set; }
        public DbSet<Wip> Wip { get; set; }
        public DbSet<RefusalInformation> RefusalInformation { get; set; }
        public DbSet<ProductGroupConsumptionReport> ProductGroupConsumptionReport { get; set; }
        public DbSet<ProductInformation> ProductInformation { get; set; }

        public SarfMalzemeStokContext(DbContextOptions<SarfMalzemeStokContext> options) : base(options)
        {

        }

        /*
         * DATA INITIALIZER AYARLANDI FAKAT MIGRATION YAPIP DATABASE GÜNCELLENMEDİ
         * EXCEL DOSYASINDAN VERİLERİ TEKRAR KONTROL ET EKSİK TABLOLARDAKİ VERİLERİ EKLEYİP
         * MIGRATION YAPIP VERİTABANINI GÜNCELLE
         */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().HasData(
            new Material
            {
                Id = 1,
                MalzemeAdi = "TK1745",
                MalzemeHakkindaNotlar = "Malzeme Kaliteli",
                MalzemeKodu = "1745",
                MaliyetSiniflandirmasi = "A",
                SabitPartiBuyuklugu = "1 Adet",
                YenidenSiparisSeviyesi = 75,
                MalzemeninKullanimOmru=0,
                EmniyetStok=50,
                YillikTasmaOrani=0.05
            },
            new Material
            {
                Id = 2,
                MalzemeAdi = "TKY60336",
                MalzemeHakkindaNotlar = "Malzeme kalitesiz",
                MalzemeKodu = "60336",
                MaliyetSiniflandirmasi = "B",
                SabitPartiBuyuklugu = "3 Adet",
                YenidenSiparisSeviyesi = 1,
                EmniyetStok=1,
                MalzemeninKullanimOmru=0,
                YillikTasmaOrani=0.05                
            },
            new Material
            {
                Id = 3,
                MalzemeAdi = "TKY30198",
                MalzemeHakkindaNotlar = "Malzeme orta kalitede",
                MalzemeKodu = "30198",
                MaliyetSiniflandirmasi = "C",
                SabitPartiBuyuklugu = "100 Adet",
                YenidenSiparisSeviyesi = 100,
                EmniyetStok = 75,
                MalzemeninKullanimOmru = 0,
                YillikTasmaOrani = 0.05
            }
            );

            modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                FirmaAdi = "Firma1",
                FirmaKodu = "F1"
            },
            new Company
            {
                Id = 2,
                FirmaAdi = "Firma2",
                FirmaKodu = "F2"
            }
            );

            modelBuilder.Entity<CompanyMaterial>().HasData(
            new CompanyMaterial
            {
                Id = 1,
                CompanyId = 1,
                MaterialId = 1,
                BirimMaliyet = 340,
                TedarikSuresi = 60,
                AsgariPartiBuyuklugu = 0
            },
            new CompanyMaterial
            {
                Id = 2,
                CompanyId = 2,
                MaterialId = 2,
                BirimMaliyet = 1340,
                TedarikSuresi = 42,
                AsgariPartiBuyuklugu = 3
            },
            new CompanyMaterial
            {
                Id = 3,
                CompanyId = 1,
                MaterialId = 2,
                BirimMaliyet = 1340,
                TedarikSuresi = 42,
                AsgariPartiBuyuklugu = 3
            },
            new CompanyMaterial
            {
                Id = 4,
                CompanyId = 1,
                MaterialId = 2,
                BirimMaliyet = 1340,
                TedarikSuresi = 42,
                AsgariPartiBuyuklugu = 3
            },
            new CompanyMaterial
            {
                Id = 5,
                CompanyId = 1,
                MaterialId = 3,
                BirimMaliyet = 1340,
                TedarikSuresi = 30,
                AsgariPartiBuyuklugu = 100
            }
            );

            modelBuilder.Entity<MaterialStock>().HasData(
            new MaterialStock
            {
                Id=1,
                MaterialId=1,
                AtolyedekiMiktar=0,
                DepodakiMiktar=0,
                TedarikAsamasindakiMiktar=0,
                StokMiktari=624.017
            },
            new MaterialStock
            {
                Id = 2,
                MaterialId = 2,
                AtolyedekiMiktar = 0,
                DepodakiMiktar = 0,
                TedarikAsamasindakiMiktar = 0,
                StokMiktari = 1
            },
            new MaterialStock
            {
                Id = 3,
                MaterialId = 3,
                AtolyedekiMiktar = 0,
                DepodakiMiktar = 0,
                TedarikAsamasindakiMiktar = 0,
                StokMiktari = 1580
            }
            );

            modelBuilder.Entity<ProductInformation>().HasData(
            new ProductInformation
            {
                Id=1,
                MaterialId=1,
                AcikSATMiktari=50,
                DahiliUretimSuresi=0,
                ToplamAcikSiparisMiktari=0,
                ToplamAcikSiparisTutari=0,
                MalGirisiIslemeSuresi=10
                
            },
            new ProductInformation
            {
                Id = 2,
                MaterialId = 2,
                AcikSATMiktari = 0,
                DahiliUretimSuresi = 0,
                ToplamAcikSiparisMiktari = 15,
                ToplamAcikSiparisTutari = 30,
                MalGirisiIslemeSuresi = 270
            },
            new ProductInformation
            {
                Id = 3,
                MaterialId = 3,
                AcikSATMiktari = 0,
                DahiliUretimSuresi = 0,
                ToplamAcikSiparisMiktari = 12000,
                ToplamAcikSiparisTutari = 5000,
                MalGirisiIslemeSuresi = 6
            }
            );

            
           modelBuilder.Entity<AlternativeMaterial>().HasData(
            new AlternativeMaterial
            {
                Id = 1,
                Material1Id = 1,
                Material2Id = 2
            },
            new AlternativeMaterial
            {
                Id = 2,
                Material1Id = 2,
                Material2Id = 1
            }
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}
