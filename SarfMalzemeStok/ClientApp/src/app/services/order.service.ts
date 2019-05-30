import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private httpClient: HttpClient) { }
  path = 'http://localhost:52072/api/';

  GetOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(this.path + 'Order/GetOrders');
  }
  GetOrdersByMaterial(materialId: number,companyId:number): Observable<Order> {
    return this.httpClient.get<Order>(this.path + 'Order/GetOrdersByMaterial/' + materialId + '/' + companyId);
  }
}
