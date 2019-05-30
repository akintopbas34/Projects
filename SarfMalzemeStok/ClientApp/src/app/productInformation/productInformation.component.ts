import { Component, OnInit, DoCheck, Input, KeyValueDiffers, OnChanges, SimpleChanges } from "@angular/core";
import { ProductInformationService } from "../services/productInformation.service";
import { ProductInformation } from "../models/productInformation";
import { MaterialService } from "../services/material.service";
import { CompanyMaterialService } from "../services/companyMaterial.service";
import { ReportsService } from '../services/reports.service';
import { ProductGroupConsumptionReport } from '../models/productGroupConsumptionReport';
import { async } from '@angular/core/testing';

@Component({
  // tslint:disable-next-line:component-selector
  selector: "app-productInformation",
  templateUrl: "./productInformation.component.html",
  styleUrls: ["./productInformation.component.css"]
})
export class ProductInformationComponent implements OnChanges, OnInit {
  productInformation: ProductInformation;
  @Input() materialId: number;
  differ: any;
  companyId: number;
  productGroupConsumptionReports: ProductGroupConsumptionReport[];

  constructor(
    private productInformationService: ProductInformationService,
    private companyMaterialService: CompanyMaterialService,
    private differs: KeyValueDiffers,
    private productGroupConsumptionReportService: ReportsService,
  ) {
    this.differ = differs.find({}).create();
  }

  ngOnChanges(changes: SimpleChanges) {

    function delay(ms: number) {
      return new Promise(resolve => setTimeout(resolve, ms));
    }

    if (changes['materialId']) {

      (async () => {

        this.productInformationService
          .GetProductInformationsByMaterial(this.materialId)
          .subscribe(data => {
            this.productInformation = data["result"];
          });

        await delay(300);
        
        this.productGroupConsumptionReportService.GetProductGroupConsumptionReportsByMaterial(this.materialId).subscribe(val => {
          this.productGroupConsumptionReports = val["result"];
        });

      })();

    }
  }

  ngOnInit() {

    this.productInformationService
      .GetProductInformationsByMaterial(this.materialId)
      .subscribe(data => {
        this.productInformation = data["result"];
      });

    this.productGroupConsumptionReportService.GetProductGroupConsumptionReportsByMaterial(this.materialId).subscribe(val => {
      this.productGroupConsumptionReports = val["result"];
    });
  }

  /*
  ngDoCheck() {
    this.companyId = this.companyMaterialService.getCompanyId();
    const materialChanges = this.differ.diff({ number: this.materialId });

    if (materialChanges) {
      this.productInformationService
        .GetProductInformationsByMaterial(this.materialId)
        .subscribe(data => {
          this.productInformation = data["result"];
        });
    }
  }
  */

}
