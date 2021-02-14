import { IProduct } from './../shared/models/product';
import { ShopPrams } from './../shared/models/ShopPrams';
import { IPagination } from './../shared/models/pagination';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import {IType} from '../shared/models/productTypes';
import {IBrand} from '../shared/models/productBrand';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';

  
  constructor(private http: HttpClient) { }

   getProducts(shopPrams: ShopPrams) {
      let params = new HttpParams();

      if(shopPrams.typeId !==0) {
         params = params.append('typeId',shopPrams.typeId.toString());
      }
      if(shopPrams.brandId !==0) {
         params = params.append('brandId', shopPrams.brandId.toString());
      }

      if(shopPrams.search){

         params = params.append('search',shopPrams.search);
      }
     
      params = params.append('sort',shopPrams.sort);
      params = params.append('pageIndex', shopPrams.pageNumber.toString());
      params = params.append('pageSize', shopPrams.pageSize.toString());

      return this.http.get<IPagination>(this.baseUrl + 'products', {observe:'response', params})
      .pipe(
        map(response =>{
           return response.body;
        })
      );
   }

   getProduct(id: number){

      return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
   }

   getTypes() {

      return this.http.get<IType[]>(this.baseUrl + 'products/types'); 
   }

   getBrands() {

    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands'); 

 }
}
