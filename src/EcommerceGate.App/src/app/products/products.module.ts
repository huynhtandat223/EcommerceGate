import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { CategoriesComponent } from './categories/categories.component';
import { MatSelectModule , MatDialogModule, MatTableModule, MatIconModule, MatInputModule, MatToolbarModule, MatFormFieldModule, MatPaginatorModule } from '@angular/material';
import { CategoryDialogComponent } from './dialogs/category-dialog/category-dialog.component';

@NgModule({
  imports: [
    CommonModule, MatSelectModule, MatTableModule, MatIconModule, MatToolbarModule, MatFormFieldModule, MatPaginatorModule, MatInputModule, MatDialogModule,
    ProductsRoutingModule
  ],
  declarations: [CategoriesComponent, CategoryDialogComponent],
  entryComponents:[
    CategoryDialogComponent
  ]
})
export class ProductsModule { }
