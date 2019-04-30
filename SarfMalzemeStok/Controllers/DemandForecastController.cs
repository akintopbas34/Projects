using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.Consumptions;
using SarfMalzemeStok.Service.Consumptions.Dto;
using SarfMalzemeStok.Service.MaterialStocks;
using SarfMalzemeStok.Service.MaterialStocks.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DemandForecastController : AbpController
    {
        Dictionary<string, double> guvenSeviyeleri = new Dictionary<string, double>()
        {
            { "90", 1.645 },
            { "95", 1.96 },
            { "99", 2.58 },
        };

        private int year;
        private static double emniyetStogu;
        private double average;
        private double standardDeviation;
        private static double siparisMiktari;
        private static double EOQ;
        private List<double> ustelDemandForecast = new List<double>(12);
        private List<double> basitDemandForecast = new List<double>(12);
        private List<double> agirlikliDemandForecast = new List<double>(12);
        private static double dipToplam;

        private readonly IConsumptionService _consumptionService;
        private readonly IMaterialStockService _materialStocksService;

        public DemandForecastController(IConsumptionService consumptionService,IMaterialStockService materialStockService)
        {
            _consumptionService = consumptionService;
            _materialStocksService = materialStockService;
        }

        private double StandardDeviation(List<double> demandForecasting)
        {
            double result = 0;

            double average = demandForecasting.Average();
            double sumOfSquaresOfDifferences = demandForecasting.Select(val => (val - average) * (val - average)).Sum();
            result = Math.Sqrt(sumOfSquaresOfDifferences / (demandForecasting.Count - 1));

            return result;
        }

        private List<double> getConsumptions(int materialId, int year)
        {
            List<double> consumption = new List<double>();
            IEnumerable<ConsumptionDto> consumptions = _consumptionService.GetConsumptionByYear(materialId, year);

            foreach (var item in consumptions)
            {
                consumption.Add(item.TuketimMiktari);
            }

            return consumption;
        }

        private List<double> CalculateSimpleDemandForecasting(int materialId, int year)
        {
            List<double> consumptionValues = getConsumptions(materialId, year);

            for (int i = 0; i < basitDemandForecast.Capacity; i++)
            {
                if (i == 0)
                    basitDemandForecast.Add(consumptionValues.Average());
                else
                    basitDemandForecast.Add((consumptionValues.Skip(i).Sum() + basitDemandForecast.Sum()) / 12);
            }
     
            return basitDemandForecast;

        }

        private List<double> CalculateExponentialDemandForecasting(int materialId, int year)
        {
            List<double> consumptionValues = getConsumptions(materialId, year);

            for (int i = 0; i < ustelDemandForecast.Capacity; i++)
            {
                if (i == 11)
                    ustelDemandForecast.Add(consumptionValues[i] + (0.3 * (ustelDemandForecast[0] - consumptionValues[i])));
                else
                    ustelDemandForecast.Add(consumptionValues[i] + (0.3 * (consumptionValues[i + 1] - consumptionValues[i])));
            }

            return ustelDemandForecast;
        }

        private List<double> CalculateWeightedDemandForecasting(int materialId, int year)
        {
            List<double> consumptionValues = getConsumptions(materialId, year);

            agirlikliDemandForecast = consumptionValues;

            for (int i = 0; i < agirlikliDemandForecast.Count; i++)
            {
                agirlikliDemandForecast[i] = agirlikliDemandForecast[(11 + i) % 12] * 0.5 + agirlikliDemandForecast[(11 + i - 1) % 12] * 0.3 + agirlikliDemandForecast[(11 + i - 2) % 12] * 0.2;
            }

            return agirlikliDemandForecast;
        }

        private double calculateStandardDeviation(int choose)
        {
            double result=0;
            if (choose == 1 && basitDemandForecast.Count != 0)
            {
                //result = StandardDeviation(basitDemandForecast);
                average = basitDemandForecast.Average();
                double sumOfSquaresOfDifferences = basitDemandForecast.Select(val => (val - average) * (val - average)).Sum();
                result = Math.Sqrt(sumOfSquaresOfDifferences / (basitDemandForecast.Count - 1));
            }
            else if (choose == 2 && ustelDemandForecast.Count != 0)
            {
                //result = StandardDeviation(ustelDemandForecast);
                average = ustelDemandForecast.Average();
                double sumOfSquaresOfDifferences = ustelDemandForecast.Select(val => (val - average) * (val - average)).Sum();
                result = Math.Sqrt(sumOfSquaresOfDifferences / (ustelDemandForecast.Count - 1));
            }
            else if (choose == 3 && agirlikliDemandForecast.Count != 0)
            {
                //result = StandardDeviation(agirlikliDemandForecast);
                average = agirlikliDemandForecast.Average();
                double sumOfSquaresOfDifferences = agirlikliDemandForecast.Select(val => (val - average) * (val - average)).Sum();
                result = Math.Sqrt(sumOfSquaresOfDifferences / (agirlikliDemandForecast.Count - 1));
            }

            return result;
        }

        private double calculateSiparisMiktari(int materialId, double acikSATMiktari)
        {
            MaterialStockDto materialStockDto = _materialStocksService.GetMaterialStockByMaterial(materialId);
            double stokMiktari = materialStockDto.StokMiktari;
            if (dipToplam != 0)
                return dipToplam - stokMiktari - acikSATMiktari;
            return 0;
        }

        private double yenidenSiparisSeviyesi(int materialId,double acikSATMiktari,int terminSuresi,double guvenSeviyesi,int choose)
        {
            double standardDeviation = calculateStandardDeviation(choose);
            double siparisMiktari = calculateSiparisMiktari(materialId, acikSATMiktari);
            double yenidenSiparisSeviyesi = (siparisMiktari * terminSuresi) + (guvenSeviyesi * standardDeviation * Math.Sqrt(terminSuresi));

            return yenidenSiparisSeviyesi;
        }

        [HttpGet("{materialId}/{acikSATMiktari}/{terminSuresi}/{guvenSeviyesi}/{choose}")]
        public double getYenidenSiparisSeviyesi(int materialId, double acikSATMiktari,int terminSuresi, double guvenSeviyesi, int choose)
        {
            return yenidenSiparisSeviyesi(materialId, acikSATMiktari, terminSuresi, guvenSeviyesi, choose);
        }

        [HttpGet("{materialId}/{terminSuresi}/{guvenSeviyesi}/{choose}")]
        public List<double> GetDipToplam(int materialId, int terminSuresi, double guvenSeviyesi, int choose)
        {
            double emniyetStok = 0;
            List<double> emniyetStokDipToplam = new List<double>();
            basitDemandForecast = CalculateSimpleDemandForecasting(materialId, 2018);
            ustelDemandForecast = CalculateExponentialDemandForecasting(materialId, 2018);
            agirlikliDemandForecast = CalculateWeightedDemandForecasting(materialId, 2018);

            double standardDeviation = calculateStandardDeviation(choose);
            emniyetStok = guvenSeviyesi * standardDeviation * Math.Sqrt(terminSuresi);

            emniyetStokDipToplam.Add(emniyetStok);
            dipToplam = 0;

            if(choose == 1)
            {
                dipToplam = emniyetStok + basitDemandForecast.Sum();
            }
            else if(choose == 2)
            {
                dipToplam = emniyetStok + ustelDemandForecast.Sum();
            }
            else if(choose == 3)
            {
                dipToplam = emniyetStok + agirlikliDemandForecast.Sum();
            }

            emniyetStokDipToplam.Add(dipToplam);

            return emniyetStokDipToplam;
        }

        [HttpGet("{materialId}/{acikSATMiktari}")]
        public double GetSiparisMiktari(int materialId, double acikSATMiktari)
        {
            return calculateSiparisMiktari(materialId, acikSATMiktari);
        }

        [HttpGet("{materialId}/{year}")]
        public List<double> getSimpleDemandForecasting(int materialId,int year)
        {
            return CalculateSimpleDemandForecasting(materialId, year);
        }

        [HttpGet("{materialId}/{year}")]
        public List<double> getWeightedDemandForecasting(int materialId, int year)
        {
            return CalculateWeightedDemandForecasting(materialId, year);
        }

        [HttpGet("{materialId}/{year}")]
        public List<double> getExponentialDemandForecasting(int materialId, int year)
        {
            return CalculateExponentialDemandForecasting(materialId, year);
        }

        [HttpGet("{materialId}/{year}")]
        public List<double> GetCurrentConsumptionValuesByYear(int materialId, int year)
        {
            IEnumerable<ConsumptionDto> consumption = _consumptionService.GetCurrentConsumptionYear(materialId, year);
            List<double> currentConsumption = new List<double>(12);
            foreach (var item in consumption)
            {
                currentConsumption.Add(item.TuketimMiktari);
            }
            return currentConsumption;
        }

        //private void Initializer(int materialId, int year)
        //{
        //    getConsumptionValues(materialId, year);
        //    CalculateStandardDeviation(materialId);
        //}
        //private void getConsumptionValues(int materialId, int year)
        //{
        //    IEnumerable<ConsumptionDto> consumptions = _consumptionService.GetConsumptionByYear(materialId, year);

        //    foreach (var item in consumptions)
        //    {
        //        consumptionValues.Add(item.TuketimMiktari);
        //    }

        //    ustelDemandForecast = new List<double>(12);

        //    for (int i = 0; i < ustelDemandForecast.Capacity; i++)
        //    {
        //        if (i == 11)
        //            ustelDemandForecast.Add(consumptionValues[i] + (0.3 * (ustelDemandForecast[0] - consumptionValues[i])));
        //        else
        //            ustelDemandForecast.Add(consumptionValues[i] + (0.3 * (consumptionValues[i + 1] - consumptionValues[i])));
        //    }

        //    basitDemandForecast = new List<double>(12);

        //    for (int i = 0; i < basitDemandForecast.Capacity; i++)
        //    {
        //        if (i == 0)
        //            basitDemandForecast.Add(consumptionValues.Average());
        //        else
        //            basitDemandForecast.Add((consumptionValues.Skip(i).Sum() + basitDemandForecast.Sum()) / 12);
        //    }

        //    agirlikliDemandForecast = consumptionValues;

        //    for (int i = 0; i < agirlikliDemandForecast.Count; i++)
        //    {
        //        agirlikliDemandForecast[i] = agirlikliDemandForecast[(11 + i) % 12] * 0.5 + agirlikliDemandForecast[(11 + i - 1) % 12] * 0.3 + agirlikliDemandForecast[(11 + i - 2) % 12] * 0.2;
        //    }

        //}
        //private void CalculateStandardDeviation(int choose)
        //{
        //    average = 0;
        //    if(choose == 1 && basitDemandForecast.Count != 0)
        //    {
        //        average = basitDemandForecast.Average();
        //        double sumOfSquaresOfDifferences = basitDemandForecast.Select(val => (val - average) * (val - average)).Sum();
        //        standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / (basitDemandForecast.Count - 1));
        //    }
        //    else if (choose == 2 && ustelDemandForecast.Count != 0)
        //    {
        //        average = ustelDemandForecast.Average();
        //        double sumOfSquaresOfDifferences = ustelDemandForecast.Select(val => (val - average) * (val - average)).Sum();
        //        standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / (ustelDemandForecast.Count - 1));
        //    }
        //    else if (choose == 3 && agirlikliDemandForecast.Count != 0)
        //    {
        //        average = agirlikliDemandForecast.Average();
        //        double sumOfSquaresOfDifferences = agirlikliDemandForecast.Select(val => (val - average) * (val - average)).Sum();
        //        standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / (agirlikliDemandForecast.Count - 1));
        //    }            
        //}

        //[HttpGet("{demandForecast}")]
        //public double CalculateStandardDeviationConsumption([FromBody] List<double> demandForecast)
        //{
        //    double result;
        //    average = 0;
        //    average = demandForecast.Average();
        //    double sumOfSquaresOfDifferences = demandForecast.Select(val => (val - average) * (val - average)).Sum();
        //    result = Math.Sqrt(sumOfSquaresOfDifferences / (demandForecast.Count - 1));

        //    return result;
        //}
        //private double calculateDipToplam(int choose ,double guvenSeviyesi,int terminSuresi)
        //{
        //    CalculateStandardDeviation(choose);
        //    emniyetStogu = standardDeviation * guvenSeviyesi * terminSuresi;
        //    dipToplam = consumptionValues.Sum() + emniyetStogu;
        //    return dipToplam;

        //}
        //[HttpGet("{materialId}/{guvenSeviyesi}/{terminSuresi}")]
        //public double GetEmniyetStok(int materialId, string guvenSeviyesi, int terminSuresi)
        //{
        //    Initializer(materialId, year);
        //    //emniyetStogu = standardDeviation * guvenSeviyeleri.FirstOrDefault(x => x.Key == guvenSeviyesi).Value * terminSuresi;
        //    emniyetStogu = standardDeviation * guvenSeviyeleri[guvenSeviyesi] * terminSuresi;

        //    return emniyetStogu;
        //}

        //private double calculateSiparisMiktari(int materialId, double stokMiktari, double acikSATMiktari)
        //{
        //    siparisMiktari = dipToplam - stokMiktari - acikSATMiktari;

        //    return siparisMiktari;
        //}

        //[HttpGet("{materialId}/{stokMiktari}/{acikSATMiktari}")]
        //public double GetSiparisMiktari(int materialId, double stokMiktari, double acikSATMiktari)
        //{
        //    Initializer(materialId,year);
        //    return calculateSiparisMiktari(materialId, stokMiktari, acikSATMiktari);
        //}

        //[HttpGet("{materialId}/{birimMaliyet}/{siparisVermeMaliyeti}")]
        //public double GetEOQ(int materialId, int birimMaliyet, double siparisVermeMaliyeti)
        //{
        //    Initializer(materialId,year);
        //    double stoktaTasimaOrani = 0.2;

        //    EOQ = Math.Sqrt((2 * siparisVermeMaliyeti * siparisMiktari) / (stoktaTasimaOrani * birimMaliyet));
        //    return EOQ;
        //}

        //[HttpGet("{materialId}")]
        //public int GetSiparisSayisi(int materialId)
        //{

        //    Initializer(materialId,year);

        //    int siparisSayisi = Convert.ToInt32(Math.Floor(siparisMiktari / EOQ));

        //    return siparisSayisi;

        //}

        //[HttpGet("{materialId}/{terminSuresi}/{guvenSeviyesi}/{choose}")]
        //public double GetDipToplam(int materialId,int terminSuresi,double guvenSeviyesi,int choose)
        //{
        //    //year = 2019;
        //    //Initializer(materialId,year);
        //    return calculateDipToplam(choose,guvenSeviyesi, terminSuresi);
        //}

        //[HttpGet("{materialId}/{terminSuresi}/{guvenSeviyesi}")]
        //public double GetYenidenSiparisSeviyesi(int materialId, int terminSuresi, string guvenSeviyesi)
        //{
        //    Initializer(materialId,year);

        //    double yenidenSiparisSeviyesi = (siparisMiktari * terminSuresi) + (guvenSeviyeleri.FirstOrDefault(x => x.Key == guvenSeviyesi).Value * standardDeviation * Math.Sqrt(terminSuresi));

        //    return yenidenSiparisSeviyesi;

        //}

        //[HttpGet("{materialId}/{year}")]
        //public List<double> GetUstelDemandForecast(int materialId,int year)
        //{
        //    Initializer(materialId,year);

        //    /*
        //    ustelDemandForecast = new List<double>(12);

        //    for (int i = 0; i < ustelDemandForecast.Capacity; i++)
        //    {
        //        if (i == 11)
        //            ustelDemandForecast.Add(consumptionValues[i] + (0.3 * (ustelDemandForecast[0] - consumptionValues[i])));
        //        else
        //            ustelDemandForecast.Add(consumptionValues[i] + (0.3 * (consumptionValues[i + 1] - consumptionValues[i])));
        //    }
        //    */
        //    return ustelDemandForecast;
        //}

        //[HttpGet("{materialId}/{year}")]
        //public List<double> GetBasitDemandForecast(int materialId,int year)
        //{
        //    Initializer(materialId,year);
        //    /*
        //    basitDemandForecast = new List<double>(12);

        //    for (int i = 0; i < basitDemandForecast.Capacity; i++)
        //    {
        //        if (i == 0)
        //            basitDemandForecast.Add(consumptionValues.Average());
        //        else
        //            basitDemandForecast.Add((consumptionValues.Skip(i).Sum() + basitDemandForecast.Sum()) / 12);
        //    }
        //    */
        //    return basitDemandForecast;
        //}



        //[HttpGet("{materialId}/{year}")]
        //public List<double> GetAgirlikliDemandForecast(int materialId,int year)
        //{
        //    Initializer(materialId,year);
        //    /*
        //    agirlikliDemandForecast = consumptionValues;

        //    for (int i = 0; i < agirlikliDemandForecast.Count; i++)
        //    {
        //        agirlikliDemandForecast[i] = agirlikliDemandForecast[(11 + i) % 12] * 0.5 + agirlikliDemandForecast[(11 + i - 1) % 12] * 0.3 + agirlikliDemandForecast[(11 + i - 2) % 12] * 0.2;
        //    }
        //    */
        //    return agirlikliDemandForecast;
        //}
    }
}