import { Material } from './material';

export class ProductGroupConsumptionReport {
    id:number;
    materialId:number;
    kod:string;
    tanim:string;
    siparisNo:string;
    terminTarihi:Date;
    terminMiktari:number;
    batchNo:string;
    asgariKalanSure:number;
    teslimatTarihi:Date;
    kaliteKontrolTarihi:Date;
    inspector:string;
    durum:string;

    material:Material;
}
