import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  productAddForm!: FormGroup ;
  // constructor() { }

  ngOnInit(): void {
    this.createProductAddForm();
  }
  
  constructor(private formBuilder: FormBuilder,
    private productService: ProductService,
    private toastrService: ToastrService) {
    
  }

  createProductAddForm(){
    this.productAddForm = this.formBuilder.group({
      productName: ["", Validators.required],
      unitPrice: ["", Validators.required],
      unitsInStock: ["", Validators.required],
      categoryId: ["",Validators.required]
    })
  }

  add() {
    if(this.productAddForm.valid){
      let productModel = Object.assign({}, this.productAddForm.value) ;
    console.log(productModel);
    this.productService.add(productModel).subscribe(response=>{
      // console.log(response);
      this.toastrService.success(response.message, "Başarılı");
    },responseError=>{
       console.log(responseError.error);
      if(responseError.error.Errors.length>0){
        console.log(responseError.error.Errors);
        for (let i = 0; i < responseError.error.Errors.length; i++) {
          this.toastrService.error(responseError.error.Errors[i].ErrorMessage, "Doğrulama Hatası");
          
        }
        
      }
      else{

      }
    });
    
    }else{
      this.toastrService.error("Formunuz eksik.","Dikkat");
    }
    

  }
}
