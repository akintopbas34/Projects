import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CompanyMaterial } from "../models/companyMaterial";

@Injectable({
  providedIn: "root"
})
export class CompanyMaterialService {
  constructor(private httpClient: HttpClient) {}
  path = "http://localhost:52072/api/";
  companyId: number;
  setCompanyId(Id: number) {
    this.companyId = Id;
  }
  getCompanyId():number{
    return this.companyId;
  }
  getCompanyMaterials(Id: number): Observable<CompanyMaterial[]> {
    return this.httpClient.get<CompanyMaterial[]>(
      this.path + "CompanyMaterial/GetCompanyMaterialsByMaterial/" + Id
    );
  }
  getCompanyMaterial(materialId: number,companyId: number): Observable<CompanyMaterial> {
    return this.httpClient.get<CompanyMaterial>(
      this.path +"CompanyMaterial/GetCompanyMaterialById/" +
        materialId + "/" + companyId
    );
  }
}
