import { Component } from '@angular/core';
import { Model, TodoItems } from './model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  model = new Model();
  isDisplay:boolean =false;

    getName() {
      return this.model.user;
   }
 
    getItems():TodoItems[]{
      if(this.isDisplay){
       return this.model.items;
      }
      else{
        return this.model.items.filter(item=>!item.action);
      }
     
    }

    addItem(value:string){
    if(value!=""){
      this.model.items.push(new TodoItems(value,false))
    }
    }
}
