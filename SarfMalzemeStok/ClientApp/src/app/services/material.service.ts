import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Material } from '../models/material';
import { Observable } from 'rxjs';
import { AlternativeMaterial } from '../models/alternativeMaterial';

@Injectable()
export class MaterialService {
  constructor(private httpClient: HttpClient) { }
  path = 'http://localhost:52072/api/';
  materialId:number;
  getMaterialId():number{
    return this.materialId;
  }
  setMaterialId(Id:number){
    this.materialId=Id;
  }
  getMaterials(): Observable<Material[]> {
    return this.httpClient.get<Material[]>(this.path + 'Material/GetMaterials');
  }

  getMaterialById(Id: Number): Observable<Material> {
    return this.httpClient.get<Material>(this.path + 'Material/GetMaterialById/' + Id);
  }
  getAlternativeMaterials(Id: Number): Observable<AlternativeMaterial[]> {
    return this.httpClient.get<AlternativeMaterial[]>(this.path + 'AlternativeMaterial/GetAlternativeMaterialById/' + Id);
  }
}
