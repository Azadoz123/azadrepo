import { Component, Input, OnInit } from '@angular/core';
import { Customer } from './customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor() { 
    
  }

  customers!: Customer[];
  selectedCustomer!: Customer;
  @Input() city!: string;
  
  ngOnInit(): void {
    this.customers =[
    { id:1 ,firstName: "azad", lastName :"özkaynak", age: 20 },
    { id:2 ,firstName: "mehmet", lastName :"al", age: 30 },
    { id:3 ,firstName: "ali", lastName :"mavi", age: 40 }
    ]
  }
  
  selectCustomer(customer:Customer){
    this.selectedCustomer =customer;
  }
}
