import { Component, OnInit, Input, KeyValueDiffers, OnChanges, SimpleChanges } from "@angular/core";
import { CompanyMaterial } from "../models/companyMaterial";
import { CompanyMaterialService } from "../services/companyMaterial.service";
import { MaterialService } from "../services/material.service";
import { MessageService } from 'primeng/api';
import { DemandForecastingService } from '../services/demandForecasting.service';
import { ProductInformationService } from '../services/productInformation.service';
import { ProductInformation } from '../models/productInformation';
import { MaterialStock } from '../models/materialStock';
import { MaterialStockService } from '../services/materialStock.service';
import Swal from 'sweetalert2';
import { ReportsService } from '../services/reports.service';
import { ProductGroupConsumptionReport } from '../models/productGroupConsumptionReport';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  // tslint:disable-next-line:component-selector
  selector: "app-companyMaterial",
  templateUrl: "./companyMaterial.component.html",
  styleUrls: ["./companyMaterial.component.css"]
})

export class CompanyMaterialComponent implements OnChanges, OnInit {

  @Input() materialId: number;
  differ: any;
  companyMaterial: CompanyMaterial;
  companies: CompanyMaterial[];
  companyId = 0;
  basitDemandChart: any;
  ustelDemandChart: any;
  agirlikliDemandChart: any;
  demandValues2018: number[];
  demandValues2019: number[];
  demandUstelValues2018: number[];
  demandUstelValues2019: number[];
  demandAgirlikliValues2018: number[];
  demandAgirlikliValues2019: number[];
  basitOptions: any;
  ustelOptions: any;
  agirlikliOptions: any;
  values2018: number[];
  oldMaterialId: number;
  guvenAraligi = 0;
  stokTasimaOrani: number;
  dipToplam: number;
  simpleDemandSum: number;
  weightedDemandSum: number;
  exponentialDemandSum: number;
  emniyetStok: number;
  standardDeviation: number;
  siparisMiktari: number;
  productInformation: ProductInformation;
  materialStock: MaterialStock;
  emniyetStokDipToplam: number[];
  yenidenSiparisSeviyesi: number;
  EOQ: number;
  siparisSayisi: number;
  productGroupConsumptionReports: ProductGroupConsumptionReport[];
  toplamTutar: number;

  constructor(private demandForecastingService: DemandForecastingService,
    private companyMaterialService: CompanyMaterialService,
    private productInformationService: ProductInformationService,
    private materialStockService: MaterialStockService,
    private productGroupConsumptionReportService: ReportsService,
    private messageService: MessageService,
    private spinner: NgxSpinnerService) {
    this.oldMaterialId = this.materialId;
    this.basitOptions = {
      title: {
        display: true,
        text: 'Simple Moving Average',
        fontSize: 16
      },
      legend: {
        position: 'bottom'
      }
    };
    this.agirlikliOptions = {
      title: {
        display: true,
        text: 'Weighted Moving Average',
        fontSize: 16
      },
      legend: {
        position: 'bottom'
      }
    };
    this.ustelOptions = {
      title: {
        display: true,
        text: 'Exponential Moving Average',
        fontSize: 16
      },
      legend: {
        position: 'bottom'
      }
    };
  }

  ngOnInit() {
    this.EOQ = 0;
    this.siparisSayisi = 0;
    this.toplamTutar = 0;
    this.productGroupConsumptionReportService.GetProductGroupConsumptionReportsByMaterial(this.materialId).subscribe(val => {
      this.productGroupConsumptionReports = val["result"];
    });
    
    this.materialStockService.getMaterialStocksByMaterial(this.materialId).subscribe(val => {
      this.materialStock = val["result"];
    });

    this.productInformationService.GetProductInformationsByMaterial(this.materialId).subscribe(val => {
      this.productInformation = val["result"];
    });
    
    this.companyMaterialService
      .getCompanyMaterials(this.materialId)
      .subscribe(data => {
        this.companies = data["result"];
      });
    this.basitDemandChart = {
      labels: ['Jan 18', 'Feb 18', 'Mar 18', 'Apr 18', 'May 18', 'June 18', 'July 18', 'Aug 18', 'Sep 18', 'Oct 18', 'Nov 18', 'Dec 18',
        'Jan 19', 'Feb 19', 'Mar 19', 'Apr 19', 'May 19', 'June 19', 'July 19', 'Aug 19', 'Sep 19', 'Oct 19', 'Nov 19', 'Dec 19'],
      datasets: [
        {
          label: 'Simple Demand Forecasting',
          data: [],
          fill: false,
          borderColor: '#4bc0c0'
        },
        {
          label: '2018 Consumption Values',
          data: [],
          fill: false,
          borderColor: '#565656'
        }
      ]
    }
    this.agirlikliDemandChart = {
      labels: ['Jan 18', 'Feb 18', 'Mar 18', 'Apr 18', 'May 18', 'June 18', 'July 18', 'Aug 18', 'Sep 18', 'Oct 18', 'Nov 18', 'Dec 18',
        'Jan 19', 'Feb 19', 'Mar 19', 'Apr 19', 'May 19', 'June 19', 'July 19', 'Aug 19', 'Sep 19', 'Oct 19', 'Nov 19', 'Dec 19'],
      datasets: [
        {
          label: 'Weighted Demand Forecasting',
          data: [],
          fill: false,
          borderColor: '#4bc0c0'
        },
        {
          label: '2018 Consumption Values',
          data: [],
          fill: false,
          borderColor: '#565656'
        }
      ]
    }
    this.ustelDemandChart = {
      labels: ['Jan 18', 'Feb 18', 'Mar 18', 'Apr 18', 'May 18', 'June 18', 'July 18', 'Aug 18', 'Sep 18', 'Oct 18', 'Nov 18', 'Dec 18',
        'Jan 19', 'Feb 19', 'Mar 19', 'Apr 19', 'May 19', 'June 19', 'July 19', 'Aug 19', 'Sep 19', 'Oct 19', 'Nov 19', 'Dec 19'],
      datasets: [
        {
          label: 'Exponential Demand Forecasting',
          data: [],
          fill: false,
          borderColor: '#4bc0c0'
        },
        {
          label: '2018 Consumption Values',
          data: [],
          fill: false,
          borderColor: '#565656'
        }
      ]
    }
  }

  ngOnChanges(changes: SimpleChanges) {

    if (changes['materialId']) {
      this.companyMaterialService
        .getCompanyMaterial(this.materialId, this.companyId)
        .subscribe(data => {
          this.companyMaterial = data["result"];
        });

      this.productInformationService.GetProductInformationsByMaterial(this.materialId).subscribe(val => {
        this.productInformation = val["result"];
      });

      this.materialStockService.getMaterialStocksByMaterial(this.materialId).subscribe(val => {
        this.materialStock = val["result"];
      });

      this.productGroupConsumptionReportService.GetProductGroupConsumptionReportsByMaterial(this.materialId).subscribe(val => {
        this.productGroupConsumptionReports = val["result"];
      });
      this.update();
    }

  }

  selectData(event) {
    this.messageService.add({ severity: 'info', summary: 'Data Selected', 'detail': this.basitDemandChart.datasets[event.element._datasetIndex].data[event.element._index] });
  }

  update() {
    function delay(ms: number) {
      return new Promise(resolve => setTimeout(resolve, ms));
    }

    this.companyMaterialService
      .getCompanyMaterials(this.materialId)
      .subscribe(data => {
        this.companies = data["result"];
      });

    if (this.oldMaterialId != this.materialId) {
      this.demandValues2018 = [];
      this.demandValues2019 = [];
      this.demandAgirlikliValues2018 = [];
      this.demandAgirlikliValues2019 = [];
      this.demandUstelValues2018 = [];
      this.demandUstelValues2019 = [];


      (async () => {

        this.demandForecastingService.getBasitDemandForecastBy2019(this.materialId).subscribe(val => {
          this.demandValues2019 = val["result"];
        });

        await delay(500);
        this.demandForecastingService.getBasitDemandForecastBy2018(this.materialId).subscribe(val => {
          this.demandValues2018 = val["result"];
          this.basitDemandChart.datasets[0].data = this.demandValues2018.concat(this.demandValues2019);
          this.basitDemandChart.update();
        });

        await delay(200);

        this.demandForecastingService.getCurrentConsumption2018(this.materialId).subscribe(val => {
          this.values2018 = val["result"];
          this.basitDemandChart.datasets[1].data = this.values2018;
          this.ustelDemandChart.datasets[1].data = this.values2018;
          this.agirlikliDemandChart.datasets[1].data = this.values2018;
          this.basitDemandChart.update();
          this.ustelDemandChart.update();
          this.agirlikliDemandChart.update();
        });

        await delay(200);

        this.demandForecastingService.getUstelDemandForecastBy2019(this.materialId).subscribe(val => {
          this.demandUstelValues2019 = val["result"];
        });

        await delay(200);

        this.demandForecastingService.getUstelDemandForecastBy2018(this.materialId).subscribe(val => {
          this.demandUstelValues2018 = val["result"];
          this.ustelDemandChart.datasets[0].data = this.demandUstelValues2018.concat(this.demandUstelValues2019);
          this.ustelDemandChart.update();
        });

        await delay(200);

        this.demandForecastingService.getAgirlikliDemandForecastBy2019(this.materialId).subscribe(val => {
          this.demandAgirlikliValues2019 = val["result"];
        });

        await delay(200);
        
        this.demandForecastingService.getAgirlikliDemandForecastBy2018(this.materialId).subscribe(val => {
          this.demandAgirlikliValues2018 = val["result"];
          this.agirlikliDemandChart.datasets[0].data = this.demandAgirlikliValues2018.concat(this.demandAgirlikliValues2019);
          this.agirlikliDemandChart.update();
        });

        this.oldMaterialId = this.materialId;
      })();

    }
  }

  changeCompany() {
    this.companyMaterialService.setCompanyId(this.companyId);

    this.companyMaterialService
      .getCompanyMaterial(this.materialId, this.companyId)
      .subscribe(data => {
        this.companyMaterial = data["result"];
      });

    this.update();
  }

  forecastChanged(event: any) {

    function delay(ms: number) {
      return new Promise(resolve => setTimeout(resolve, ms));
    }

    if (event.target.value == "1") {

      (async () => {
        this.demandForecastingService.getDipToplam(this.materialId, this.companyMaterial.tedarikSuresi, this.guvenAraligi, event.target.value).subscribe(val => {
          this.emniyetStokDipToplam = val["result"];
          this.dipToplam = this.emniyetStokDipToplam[1];
          this.emniyetStok = this.emniyetStokDipToplam[0];
        });

        await delay(500);

        this.demandForecastingService.getSiparisMiktari(this.materialId, this.productInformation.acikSATMiktari).subscribe(val => {
          this.siparisMiktari = val["result"];
        });

        await delay(300);

        this.demandForecastingService.getYenidenSiparisSeviyesi(this.materialId,
          this.productInformation.acikSATMiktari,
          this.companyMaterial.tedarikSuresi,
          this.guvenAraligi,
          event.target.value
        ).subscribe(val => {
          this.yenidenSiparisSeviyesi = val["result"];
        });

      })();

    }
    else if (event.target.value == "2") {

      (async () => {
        this.demandForecastingService.getDipToplam(this.materialId, this.companyMaterial.tedarikSuresi, this.guvenAraligi, event.target.value).subscribe(val => {
          this.emniyetStokDipToplam = val["result"];
          this.dipToplam = this.emniyetStokDipToplam[1];
          this.emniyetStok = this.emniyetStokDipToplam[0];
        });

        await delay(500);

        this.demandForecastingService.getSiparisMiktari(this.materialId, this.productInformation.acikSATMiktari).subscribe(val => {
          this.siparisMiktari = val["result"];
        });

        await delay(300);

        this.demandForecastingService.getYenidenSiparisSeviyesi(this.materialId,
          this.productInformation.acikSATMiktari,
          this.companyMaterial.tedarikSuresi,
          this.guvenAraligi,
          event.target.value
        ).subscribe(val => {
          this.yenidenSiparisSeviyesi = val["result"];
        });

      })();

    }
    else if (event.target.value == "3") {

      (async () => {
        this.demandForecastingService.getDipToplam(this.materialId, this.companyMaterial.tedarikSuresi, this.guvenAraligi, event.target.value).subscribe(val => {
          this.emniyetStokDipToplam = val["result"];
          this.dipToplam = this.emniyetStokDipToplam[1];
          this.emniyetStok = this.emniyetStokDipToplam[0];
        });

        await delay(500);

        this.demandForecastingService.getSiparisMiktari(this.materialId, this.productInformation.acikSATMiktari).subscribe(val => {
          this.siparisMiktari = val["result"];
        });

        await delay(300);

        this.demandForecastingService.getYenidenSiparisSeviyesi(this.materialId,
          this.productInformation.acikSATMiktari,
          this.companyMaterial.tedarikSuresi,
          this.guvenAraligi,
          event.target.value
        ).subscribe(val => {
          this.yenidenSiparisSeviyesi = val["result"];
        });

      })();

    }
  }

  calculateEOQ(stokTasima: string) {
    this.EOQ = Math.sqrt((2 * 2 * this.siparisMiktari) / (Number.parseFloat(stokTasima) * this.companyMaterial.birimMaliyet));
    this.siparisSayisi = Math.floor(this.siparisMiktari / this.EOQ);
    this.toplamTutar = this.companyMaterial.birimMaliyet * this.siparisSayisi;

  }

  showMessages() {
    if (this.materialStock.stokMiktari < this.yenidenSiparisSeviyesi) {
      Swal.fire(
        'Bilgilendirme Mesajı!',
        'Eldeki stok miktarı yeniden sipariş seviyesinden düşük durumdadır!',
        'info'
      )
    }

  }

  /*
  showInformation() {
    let message = this.companyMaterial.material.malzemeAdi + " malzemesinden "
      + (this.productGroupConsumptionReports[0].terminMiktari - this.materialStock.atolyedekiMiktar)
      + " adet bulunmaktadır ve bu malzemenin "
      + this.productGroupConsumptionReports[0].asgariKalanSure
      + " ay asgari süresi vardır.";
    Swal.fire(
      'Bilgilendirme Mesajı!',
      message,
      'info'
    );
  }
  */

}
