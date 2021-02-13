import { IProduct } from '../shared/models/product';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-shop-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct;

  constructor() { }

  ngOnInit() {
  }

}
