import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MaterialStock } from '../models/materialStock';

@Injectable({
  providedIn: 'root'
})
export class MaterialStockService {

  constructor(private httpClient: HttpClient) { }
  path = 'http://localhost:52072/api/';

  getMaterialStocks(): Observable<MaterialStock[]> {
    return this.httpClient.get<MaterialStock[]>(this.path + 'MaterialStock/GetMaterialStocks');
  }
  getMaterialStocksByMaterial(Id: number): Observable<MaterialStock> {
    return this.httpClient.get<MaterialStock>(this.path + 'MaterialStock/GetMaterialStocksByMaterial/' + Id);
  }
}
