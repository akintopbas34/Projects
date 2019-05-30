import { Material } from './material';

export class ProcessingTimeReport {

    id:number;
    materialId:number;
    tanim:string;
    siparisNo:string;
    termin:number;
    teslimatTarih:Date;
    kaliteKontrolTarihi:Date;
    durum:string;
    inspector:string;
    tahditsizTarih:Date;
    inspectionSuresi:number;

    material:Material;
    
}
