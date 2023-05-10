import{ Component, OnInit} from "@angular/core"
import { Product } from "./product.model";
import { ProductRepository } from "./repository.model"

// @Component({
//     selector: "app",
//      templateUrl: "product.component.html",
//      styleUrls: ["product.component.css"]
    // template : `<input [(ngModel)]="email" (keyup.enter)="onKeyUp()"/>
    // <p> {{title}} </p>
    // <p> {{title | lowercase }} </p>
    // <p> {{title | uppercase }} </p>

    // <p> {{today | date }} </p>
    // <p> {{today | date: 'fullDate' }} </p>
    // <p> {{today | date: 'medium' }} </p>
    // <p> {{today | date: 'h:mm:ss' }} </p>

    // <p> {{students | number}} </p>
    // <p> {{price | number: '1.2-2'}} </p>

    // {{text | summary: 10 }}

    // <a routerLink="/path">
    // <br>
    // <a routerLink="/user/bob"> https://www.youtube.com/</a>

    // `
    
// })
@Component({
  selector: 'app',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
// @Component({
//   selector :'app',
//   templateUrl: './product.component.html',
//   styleUrls: ['./product2.component.css']
// })
export class ProductComponent{

  // text ='Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdi';

  //   today : number = Date.now();
  //   title : string = 'Angular Kursu';
  //   students : number =21536;
  //   price : number = 395.99;
  //   completed : number =0.26;

    model: ProductRepository = new ProductRepository();

    addProduct(){
      this.model.addProduct(new Product(6, "Samsung S10", "iyi telefon", "1.jpg", 6000));
    }

    deleteProduct(product: Product){
      this.model.deleteProduct(product);
    }

    updateProduct(product: Product){
      product.name = "updated"; 
    }
    // productName : string = this.model.getProductById(1).name as string;
    // disabled = false;


    // getClasses(id: number) :string {
    //   let product = this.model.getProductById(id);
    //  return (product.price as number <= 1000 ? "bg-info" : "bg-secondary")+" m-2 p-2" ;
    // }

    // getClassesMap(id:number): Object{
    //   let product = this.model.getProductById(id);
    //   return{
    //     "bg-info" : product.price as number <= 1000,
    //     "bg-secondary" : product.price as number > 1000,
    //     "text-center text-white" : product.name == "Samsung S6"
    //   }
    // }

    // color: string = this.model.getProductById(1).price as number <= 1000 ? "blue" : "red";
    // fontSize: string = "25px";

    // getStyles(id: number): Object{
    //     let product = this.model.getProductById(id);
    //     return{
    //         fontSize: "25px",
    //         color: product.price as Product<=1000 ? "blue" : "red"
    //     }

    // }
    // onSubmit(){
    //   console.log('button was clicked');
    // }
    //email = "email@sadikturan.com";

    // onKeyUp(email: any ){
    // onKeyUp( ){

    //     console.log(this.email);

    // }

}