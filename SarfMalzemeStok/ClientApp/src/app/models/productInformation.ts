import { Material } from './material';

export class ProductInformation {
    id: number;
    materialId: number;
    malGirisiIslemeSuresi: number;
    toplamAcikSiparisMiktari: number;
    acikSATMiktari: number;
    imalataSonVerilisTarihi: Date;
    dahiliUretimSuresi: number;
    toplamAcikSiparisTutari: number;
    material: Material;
}
