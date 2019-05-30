import { Material } from './material';

export class HistoryInformationReport {
    id:number;
    materialId:number;
    process:string;
    partNumber:string;
    descPart:string;
    operation:string;
    workStation:string;
    consumable:string;
    olcuBirimi:string;
    upp:string;
    uppDegisiklik:string;
    degisiklikYapan:string;

    material:Material;
  
}
