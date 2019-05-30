import { Component, OnInit, DoCheck, Input, KeyValueDiffers, SimpleChanges, OnChanges } from '@angular/core';
import { MaterialStockService } from '../services/materialStock.service';
import { MaterialStock } from '../models/materialStock';
import { MaterialService } from '../services/material.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-materialStock',
  templateUrl: './materialStock.component.html',
  styleUrls: ['./materialStock.component.css']
})
export class MaterialStockComponent implements OnChanges, OnInit {

  materialStock: MaterialStock;
  @Input() materialId: number;
  differ: any;

  constructor(
    private materialStockService: MaterialStockService,
    private differs: KeyValueDiffers
  ) {
    this.differ = differs.find({}).create();
  }

  ngOnInit() {
    this.materialStockService.getMaterialStocksByMaterial(this.materialId).subscribe(data => {
      this.materialStock = data['result'];
    });
  }

  ngOnChanges(changes: SimpleChanges) {

    if (changes['materialId']) {
      this.materialStockService.getMaterialStocksByMaterial(this.materialId).subscribe(data => {
        this.materialStock = data['result'];
      });
    }

  }
  
/*
  ngDoCheck() {

    const materialChanges = this.differ.diff({ 'number': this.materialId });

    if (materialChanges) {
      this.materialStockService.getMaterialStocksByMaterial(this.materialId).subscribe(data => {
        this.materialStock = data['result'];
      });
    }
  }
  */

}
