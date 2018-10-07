import { Component, OnInit } from '@angular/core';
import { CommonComponent } from '../../core/common.component';
import { ProductService } from '../../../services/product.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Router, Route } from '@angular/router';
import { RoutingInfomation } from '../../../constants';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent extends CommonComponent {

  constructor(private productService: ProductService, private router: Router) { 
    super(productService, dataItem => new FormGroup(
      {
        'Name': new FormControl(dataItem.Name),
        'SKU': new FormControl(dataItem.SKU),
        'RegularPrice': new FormControl(dataItem.RegularPrice),
        'QtyOnHand': new FormControl(dataItem.QtyOnHand),
        'IsInStock': new FormControl(dataItem.IsInStock),
        'Weight': new FormControl(dataItem.Weight)
      }), 
      { 
        Name: '', SKU: '', RegularPrice: 0, QtyOnHand: 0, IsInStock: false, Weight: 0
      });
  }

  public goToUrl(){
    this.router.navigate(['/products/addnew'], {queryParams: {returnUrl: this.router.url}});
  }
}
