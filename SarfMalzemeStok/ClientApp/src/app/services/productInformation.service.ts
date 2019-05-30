import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductInformation } from '../models/productInformation';

@Injectable({
  providedIn: 'root'
})
export class ProductInformationService {

  constructor(private httpClient: HttpClient) { }
  path = 'http://localhost:52072/api/';

  acikSATMiktari: number;

  GetProductInformations(): Observable<ProductInformation[]> {
    return this.httpClient.get<ProductInformation[]>(this.path + 'ProductInformation/GetProductInformations');
  }
  GetProductInformationsByMaterial(Id: number): Observable<ProductInformation> {
    return this.httpClient.get<ProductInformation>(this.path + 'ProductInformation/GetProductInformationsByMaterial/' + Id);
  }
  setAcikSATMiktari(miktar: number) {
    this.acikSATMiktari = miktar;
  }
  getAcikSATMiktari():number{
    return this.acikSATMiktari;
  }
}
