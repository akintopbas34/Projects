import { Material } from './material';

export class Comnsumption {
    id: number;
    materialId: number;
    kullanimTarihi: Date;
    tuketimMiktari: number;
    birim: string;
    material: Material;
}
