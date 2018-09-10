import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../categories.service';


@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  constructor(private categoriesService: CategoriesService) { }
  categories: any[] = [];
  filteredData: any[] = [];
  renderedData: any[] = [];
  displayedColumns: string[] = ['id', 'name', 'parentId', 'skuPrefix', 'actions'];


  ngOnInit() {
    this.getCategories();
  }
  getCategories(): void{
    this.categoriesService.getCategories()
      .subscribe(categories => {this.categories = categories; console.log(this.categories)});
  }
  refresh(){}

}
