import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../categories.service';
import { MatDialog } from '@angular/material';
import { CategoryDialogComponent } from '../dialogs/category-dialog/category-dialog.component';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  constructor(private categoriesService: CategoriesService, public dialog: MatDialog) { }
  categories: any[] = [];
  filteredData: any[] = [];
  renderedData: any[] = [];
  displayedColumns: string[] = ['id', 'name', 'parentId', 'skuPrefix', 'actions'];


  ngOnInit() {
    this.getCategories();
  }
  getCategories(): void{
    this.categoriesService.getCategories()
      .subscribe(categories => this.categories = categories);
  }
  refresh(){
    this.getCategories();
  }

  addNew(category: any){
    const dialogRef = this.dialog.open(CategoryDialogComponent, {
      data: {category: category }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 1) {
        // After dialog is closed we're doing frontend updates
        // For add we're just pushing a new row inside DataService
        this.categoriesService.dataChange.value.push(this.categoriesService.dialogData);
        this.refreshTable();
      }
    });
  }
  startEdit(){}
  deleteItem(){}
   // If you don't need a filter or a pagination this can be simplified, you just use code from else block
   private refreshTable() {
   
  }
}
