import { Component, OnInit, DoCheck, Input, KeyValueDiffers } from "@angular/core";
import { OrderService } from "../services/order.service";
import { Order } from "../models/order";
import { MaterialService } from "../services/material.service";
import { CompanyMaterialComponent } from "../companyMaterial/companyMaterial.component";
import { CompanyMaterialService } from "../services/companyMaterial.service";
import { Variable } from '@angular/compiler/src/render3/r3_ast';

@Component({
  selector: "app-order",
  templateUrl: "./order.component.html",
  styleUrls: ["./order.component.css"]
})
export class OrderComponent implements DoCheck {
  order: Order;
  @Input() materialId: number;
  differ: any;
  companyId: number;
  siparisSayisi: string;
  constructor(
    private orderService: OrderService,
    private differs: KeyValueDiffers,
    private companyMaterialService: CompanyMaterialService
  ) {
    this.differ = differs.find({}).create();
  }

  ngDoCheck() {
    this.companyId = this.companyMaterialService.getCompanyId();
    const selectChanges = this.differ.diff({
      material: this.materialId,
      company: this.companyId
    });

    if (selectChanges) {
      this.orderService
        .GetOrdersByMaterial(this.materialId, this.companyId)
        .subscribe(data => {
          this.order = data["result"];
          this.siparisSayisi = (this.order.siparisVermeMaliyeti / this.order.companyMaterial.birimMaliyet).toFixed(2);
        });
    }

  }
}
