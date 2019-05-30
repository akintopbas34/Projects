import { Material } from './material';

export class BenchStandbyReport {

    id:number;
    materialId:number;
    workCenter:string;
    masrafYeri:string;
    parca:string;
    operation:string;
    yakaNo:string;
    talepNumarasi:string;
    beklemeSuresi:string;

    material:Material;
}
