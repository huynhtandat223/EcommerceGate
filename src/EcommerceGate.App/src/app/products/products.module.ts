import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { CategoriesComponent } from './categories/categories.component';
import { MatTableModule, MatIconModule, MatToolbarModule, MatFormFieldModule, MatPaginatorModule } from '@angular/material';

@NgModule({
  imports: [
    CommonModule, MatTableModule, MatIconModule, MatToolbarModule, MatFormFieldModule, MatPaginatorModule,
    ProductsRoutingModule
  ],
  declarations: [CategoriesComponent]
})
export class ProductsModule { }
