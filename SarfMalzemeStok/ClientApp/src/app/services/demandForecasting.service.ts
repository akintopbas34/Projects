import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, ObservableInput } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DemandForecastingService {

  constructor(private httpClient: HttpClient) { }
  path = "http://localhost:52072/api/";
  materialId: number;

  getBasitDemandForecastBy2018(Id: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/getSimpleDemandForecasting/" + Id + "/" + 2017
    );
  }
  getBasitDemandForecastBy2019(Id: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/getSimpleDemandForecasting/" + Id + "/" + 2018
    );
  }
  getCurrentConsumption2018(Id: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/GetCurrentConsumptionValuesByYear/" + Id + "/" + 2018
    );
  }
  getUstelDemandForecastBy2018(Id: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/getExponentialDemandForecasting/" + Id + "/" + 2017
    );
  }
  getUstelDemandForecastBy2019(Id: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/getExponentialDemandForecasting/" + Id + "/" + 2018
    );
  }
  getAgirlikliDemandForecastBy2018(Id: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/getWeightedDemandForecasting/" + Id + "/" + 2017
    );
  }
  getAgirlikliDemandForecastBy2019(Id: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/getWeightedDemandForecasting/" + Id + "/" + 2018
    );
  }

  getDipToplam(materialId: number, tedarikSuresi: number, guvenSeviyesi: number, choose: number): Observable<number[]> {
    return this.httpClient.get<number[]>(
      this.path + "DemandForecast/GetDipToplam/" + materialId + "/" + tedarikSuresi + "/" + guvenSeviyesi + "/" + choose
    );
  }
  getSiparisMiktari(materialId: number, acikSATMiktari: number): Observable<number> {
    return this.httpClient.get<number>(
      this.path + "DemandForecast/GetSiparisMiktari/" + materialId + "/" + acikSATMiktari
    );
  }
  getYenidenSiparisSeviyesi(materialId: number, acikSATMiktari: number, terminSuresi: number, guvenSeviyesi: number, choose: number): Observable<number> {
    return this.httpClient.get<number>(
      this.path + "DemandForecast/getYenidenSiparisSeviyesi/" + materialId + "/" + acikSATMiktari + "/" + terminSuresi + "/" + guvenSeviyesi + "/" + choose
    );
  }
}
