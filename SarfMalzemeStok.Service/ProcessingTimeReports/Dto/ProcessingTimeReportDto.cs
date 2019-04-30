using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.ProcessingTimeReports.Dto
{
    [AutoMap(typeof(ProcessingTimeReport))]
    public class ProcessingTimeReportDto:EntityDto
    {
        public int MaterialId { get; set; }
        public string Tanim { get; set; }
        public string SiparisNo { get; set; }
        public int Termin { get; set; }
        public DateTime TeslimatTarih { get; set; }
        public DateTime KaliteKontrolTarihi { get; set; }
        public string Durum { get; set; }
        public string Inspector { get; set; }
        public DateTime TahditsizTarih { get; set; }
        public int InspectionSuresi { get; set; }

        public Material material { get; set; }
    }
}
