import { Material } from './material';

export class MaterialStock {
    id: number;
    materialId: number;
    dapodakiMiktar: number;
    atolyedekiMiktar: number;
    tedarikAsamasindakiMiktar: number;
    stokMiktari: number;
    material: Material;
}
