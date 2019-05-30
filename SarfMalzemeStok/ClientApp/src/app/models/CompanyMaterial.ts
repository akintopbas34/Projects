import { Material } from './material';
import { Company } from './company';

export class CompanyMaterial {
    id: number;
    companyId: number;
    materialId: number;
    birimMaliyet: number;
    tedarikSuresi: number;
    asgariPartiBuyuklugu: number;
    material: Material;
    company: Company;
    
}
