import { ShopPrams } from './../shared/models/ShopPrams';
import { IBrand } from './../shared/models/productBrand';
import { IType } from './../shared/models/productTypes';
import { ShopService } from './shop.service';
import { IProduct } from './../shared/models/product';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search', {static: true}) searchTerm: ElementRef;  
  products: IProduct[];
  types: IType[];
  brands: IBrand[];
  shopPrams = new ShopPrams();
  totalCount: number;
  sortOptions=[
    {name: 'Alphabatically', value: 'name'},
    {name: 'price: low to high', value: 'priceAsc'},
    {name: 'price: high to low', value: 'priceDesc'}
  ];
  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getTypes();
    this.getBrands();
    
  }

  getProducts() {
      this.shopService.getProducts(this.shopPrams).subscribe(response => {
      this.products = response.data;
      this.shopPrams.pageSize = response.pageSize;
      this.shopPrams.pageNumber = response.pageIndex;
      this.totalCount = response.count;
  }, error => {
       console.log(error); 
      });
  }

  getTypes() {

    this.shopService.getTypes().subscribe(response =>{
      this.types = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  getBrands() {

    this.shopService.getBrands().subscribe(response =>{
      this.brands = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });

  }

  onTypeSelected(typeId: number) {
    this.shopPrams.typeId = typeId;
    this.shopPrams.pageNumber = 1;
    this.getProducts();  
  }

  onBrandSelectes(brandId: number) {
     this.shopPrams.brandId = brandId;
     this.shopPrams.pageNumber = 1;
     this.getProducts();
  }

  onSort(sort: string) {
        this.shopPrams.sort= sort;
        this.getProducts();
  }

  onPageChange(event: any){
    if(this.shopPrams.pageNumber !== event) {
      this.shopPrams.pageNumber = event;
      this.getProducts();
    }
   
  }

  onSearch(){
     this.shopPrams.search = this.searchTerm.nativeElement.value;
     this.shopPrams.pageNumber = 1;
     this.getProducts();
  }

  onReset(){

     this.searchTerm.nativeElement.value = '';
     this.shopPrams = new ShopPrams();
     this.getProducts();
  }

}
