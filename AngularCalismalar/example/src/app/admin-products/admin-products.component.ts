import { Component } from '@angular/core';
import { Product } from '../product.model';
import { ProductRepository } from '../repository.model';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent {

  products!: Product[];
   model!: ProductRepository;
  //  selectedProduct!: Product; 
   selectedProduct!: Product ; 
  constructor() {
   
    this.model = new ProductRepository();
    this.products = this.model.getProducts();
    this.selectedProduct = new Product();
    console.log( "selectedProduct : " + this.selectedProduct);
  }

  // getSelected(product:Product): boolean {
  //   return product.name == this.selectedProduct;
  // }
  getSelected(product:Product): boolean {
    return product == this.selectedProduct;
  }

  editProduct(product: Product){
    this.selectedProduct = product;
  }

  saveChanges(name: string, price: string, imageUrl: string, description: string){
    // const p = this.model.getProductById(this.selectedProduct.id)
    // p.name = name;
    // p.description= description;
    // p.imageUrl = imageUrl;
    // p.price = +price;
    // this.selectedProduct = null as any;
  }
} 
