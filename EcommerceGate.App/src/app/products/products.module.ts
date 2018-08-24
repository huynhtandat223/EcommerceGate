import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { CategoriesComponent } from './categories/categories.component';
import { MatTableModule } from '@angular/material';
@NgModule({
  imports: [
    CommonModule, MatTableModule
    ProductsRoutingModule
  ],
  declarations: [CategoriesComponent]
})
export class ProductsModule { }
