import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { CategoriesComponent } from './categories/categories.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ProductoptionsComponent } from './productoptions/productoptions.component';
import { ProductoptionvaluedefaultComponent } from './productoptions/productoptionvaluedefault/productoptionvaluedefault.component';

@NgModule({
  imports: [
    CommonModule, GridModule, DropDownsModule,
    ProductsRoutingModule, FormsModule, ReactiveFormsModule
  ],
  declarations: [CategoriesComponent, ProductoptionsComponent, ProductoptionvaluedefaultComponent]
})
export class ProductsModule { }
