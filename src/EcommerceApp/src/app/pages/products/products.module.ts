import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { CategoriesComponent } from './categories/categories.component';
import { GridModule } from '@progress/kendo-angular-grid';


@NgModule({
  imports: [
    CommonModule, GridModule,
    ProductsRoutingModule
  ],
  declarations: [CategoriesComponent]
})
export class ProductsModule { }
