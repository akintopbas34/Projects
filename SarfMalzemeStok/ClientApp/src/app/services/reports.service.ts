import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CompanyMaterial } from '../models/companyMaterial';
import { HistoryInformationReport } from '../models/historyInformationReport';
import { ProductGroupConsumptionReport } from '../models/productGroupConsumptionReport';
import { ProcessingTimeReport } from '../models/processingTimeReport';
import { BenchStandbyReport } from '../models/benchStandbyReport';

@Injectable({
  providedIn: 'root'
})
export class ReportsService {

  constructor(private httpClient: HttpClient) { }

  path = "http://localhost:52072/api/";

  GetHistoryInformationReportsByMaterial(materialId: number): Observable<HistoryInformationReport> {
    return this.httpClient.get<HistoryInformationReport>(
      this.path + "Reports/GetHistoryInformationReportsByMaterial/"+ materialId
    );
  }

  GetProductGroupConsumptionReportsByMaterial(materialId: number): Observable<ProductGroupConsumptionReport> {
    return this.httpClient.get<ProductGroupConsumptionReport>(
      this.path + "Reports/GetProductGroupConsumptionReportsByMaterial/"+ materialId
    );
  }

  GetProcessingTimeReportsByMaterial(materialId: number): Observable<ProcessingTimeReport> {
    return this.httpClient.get<ProcessingTimeReport>(
      this.path + "Reports/GetProcessingTimeReportsByMaterial/"+ materialId
    );
  }

  GetBenchStandbyReportsByMaterial(materialId: number): Observable<BenchStandbyReport> {
    return this.httpClient.get<BenchStandbyReport>(
      this.path + "Reports/GetBenchStandbyReportsByMaterial/"+ materialId
    );
  }

}
