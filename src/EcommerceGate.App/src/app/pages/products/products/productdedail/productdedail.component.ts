import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../../../../services/product.service';
import { FormGroup, FormControl } from '@angular/forms';
import { DetailComponent } from '../../../detail.component';

@Component({
  selector: 'app-productdedail',
  templateUrl: './productdedail.component.html',
  styleUrls: ['./productdedail.component.css']
})
export class ProductdedailComponent extends DetailComponent {

  constructor(private productService: ProductService) { 
    super(productService, dataItem => new FormGroup(
      {
        'Id': new FormControl(dataItem.Id),
        'Name': new FormControl(dataItem.Name),
        'SKU': new FormControl(dataItem.SKU),
        'RegularPrice': new FormControl(dataItem.RegularPrice),
        'QtyOnHand': new FormControl(dataItem.QtyOnHand),
        'IsInStock': new FormControl(dataItem.IsInStock),
        'Weight': new FormControl(dataItem.Weight)
      }), 
      { 
        Id: 0, Name: '', SKU: '', RegularPrice: 0, QtyOnHand: 0, IsInStock: false, Weight: 0
      });
  }

}