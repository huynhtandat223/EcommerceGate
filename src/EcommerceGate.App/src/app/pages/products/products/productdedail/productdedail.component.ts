import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../../services/product.service';

@Component({
  selector: 'app-productdedail',
  templateUrl: './productdedail.component.html',
  styleUrls: ['./productdedail.component.css']
})
export class ProductdedailComponent implements OnInit {
  product: any = null;
  constructor(private productService: ProductService) { 

  }

  ngOnInit() {
    
  }

}
