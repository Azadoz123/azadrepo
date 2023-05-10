import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { Router, RouterModule } from '@angular/router';
import { ProductComponent } from './product.component';
import { SummaryPipe } from './summary.pipe';
import { Product2Component } from './product2/product2.component';
import { InputEmailDirective } from './input-email.directive';
import { AdminProductsComponent } from './admin-products/admin-products.component';



@NgModule({
  declarations: [	
    ProductComponent,
    SummaryPipe,
      Product2Component,
      InputEmailDirective,
      AdminProductsComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [ProductComponent]
})
export class AppModule { }
