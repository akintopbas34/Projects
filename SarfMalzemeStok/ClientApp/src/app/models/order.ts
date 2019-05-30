import { CompanyMaterial } from './companyMaterial';

export class Order {
    id: number;
    companyMaterialId: number;
    siparisVerilmeZamani: Date;
    siparisinGerceklesmeDurumu: boolean;
    siparisTamamlanmaZamani: Date;
    siparisVermeMaliyeti: number;
    companyMaterial: CompanyMaterial;
}
