import { Component, OnInit, DoCheck, KeyValueDiffers, Input } from '@angular/core';
import { ReportsService } from '../services/reports.service';
import { HistoryInformationReport } from '../models/historyInformationReport';
import { ProductGroupConsumptionReport } from '../models/productGroupConsumptionReport';
import { ProcessingTimeReport } from '../models/processingTimeReport';
import { BenchStandbyReport } from '../models/benchStandbyReport';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements DoCheck {

  @Input() materialId: number;
  historyInformationReports: HistoryInformationReport[];
  productGroupConsumptionReports : ProductGroupConsumptionReport[];
  processingTimeReports : ProcessingTimeReport[];
  benchStandbyReports : BenchStandbyReport[];

  differ: any;
  
  constructor(private reportService: ReportsService, private differs: KeyValueDiffers) {
    this.differ = differs.find({}).create();
  }

  ngDoCheck(): void {

    const selectChanges = this.differ.diff({
      material: this.materialId
    });

    if(selectChanges)
    {
      this.reportService
        .GetBenchStandbyReportsByMaterial(this.materialId)
        .subscribe(data => {
          this.benchStandbyReports = data["result"];
        });
      this.reportService
        .GetHistoryInformationReportsByMaterial(this.materialId)
        .subscribe(data => {
          this.historyInformationReports = data["result"];
        });
      this.reportService
        .GetProcessingTimeReportsByMaterial(this.materialId)
        .subscribe(data => {
          this.processingTimeReports = data["result"];
        });
      this.reportService
        .GetProductGroupConsumptionReportsByMaterial(this.materialId)
        .subscribe(data => {
          this.productGroupConsumptionReports = data["result"];
        });
    }

  }



}
