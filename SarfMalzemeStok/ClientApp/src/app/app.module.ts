import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialComponent } from './material/material.component';
import { HttpClientModule } from '@angular/common/http';
import { MaterialService } from './services/material.service';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MaterialStockComponent } from './materialStock/materialStock.component';
import { OrderComponent } from './order/order.component';
import { ProductInformationComponent } from './productInformation/productInformation.component';
import { CompanyMaterialComponent } from './companyMaterial/companyMaterial.component';
import { ReportsComponent } from './reports/reports.component';
import { DemandForecastingComponent } from './demandForecasting/demandForecasting.component';

import { AccordionModule } from 'primeng/accordion';     //accordion and accordion tab
import { MenuItem, MessageService } from 'primeng/api';                 //api

import { ChartModule } from 'primeng/chart';
import { ToastModule } from 'primeng/toast';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
   declarations: [
      AppComponent,
      MaterialComponent,
      CompanyMaterialComponent,
      MaterialStockComponent,
      OrderComponent,
      ProductInformationComponent,
      ReportsComponent,
      DemandForecastingComponent
   ],
   imports: [
      AccordionModule,
      BrowserModule,
      BrowserAnimationsModule,
      ChartModule,
      AppRoutingModule,
      HttpClientModule,
      RouterModule,
      FormsModule,
      SweetAlert2Module,
      NgxSpinnerModule,
      ToastModule

   ],
   providers: [
      MaterialService,
      MessageService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
