import { Component, OnInit, Output } from "@angular/core";
import { MaterialService } from "../services/material.service";
import { Material } from "../models/material";
import { AlternativeMaterial } from "../models/alternativeMaterial";
import { MessageService } from 'primeng/api';
import { MaterialStockService } from '../services/materialStock.service';
import { MaterialStock } from '../models/materialStock';
import Swal from 'sweetalert2';

@Component({
  selector: "app-material",
  templateUrl: "./material.component.html",
  styleUrls: ["./material.component.css"]
})

export class MaterialComponent implements OnInit {
  materials: Material[];
  materialId = 0;
  teknikResim: string;
  materialById: Material;
  buttonClicked = false;
  alternativeMaterials: AlternativeMaterial[];
  materialStock: MaterialStock;

  constructor(private materialService: MaterialService, private materialStockService: MaterialStockService) {

  }
  ngOnInit() {
    this.materialService.getMaterials().subscribe(data => {
      this.materials = data["result"];
    });
  }
  Getir() {
    function delay(ms: number) {
      return new Promise(resolve => setTimeout(resolve, ms));
    }
    this.buttonClicked = true;
    this.materialService.setMaterialId(this.materialId);

    (async () => {
      this.materialService.getMaterialById(this.materialId).subscribe(data => {
        this.materialById = data["result"];
      });
      this.materialService
        .getAlternativeMaterials(this.materialId)
        .subscribe(data => {
          this.alternativeMaterials = data["result"];
        });
      this.materialStockService.getMaterialStocksByMaterial(this.materialId).subscribe(data => {
        this.materialStock = data['result'];
      })
      await delay(500);

      if (this.materialStock.atolyedekiMiktar == 0) {
        Swal.fire(
          'Bilgilendirme Mesajı!',
          'Bu malzeme statik stok durumundadır.',
          'info'
        );
      }
      else if (this.materialStock.atolyedekiMiktar < (this.materialStock.stokMiktari / 2)) {
        Swal.fire(
          'Bilgilendirme Mesajı!',
          'Bu malzeme slow stok durumundadır.',
          'info'
        );
      }
      else if (this.materialStock.atolyedekiMiktar > (this.materialStock.stokMiktari / 2)) {
        Swal.fire(
          'Bilgilendirme Mesajı!',
          'Bu malzeme fast stok durumundadır.',
          'info'
        );
      }

    })();

  }
  alternativeMaterialModal(resim: string) {
    this.teknikResim = resim;
  }
  materialModal() {
    this.teknikResim = this.materialById.teknikResim;
  }

  changeMaterial() {
    this.materialService.getMaterialById(this.materialId).subscribe(data => {
      this.materialById = data["result"];
    });
  }
}
