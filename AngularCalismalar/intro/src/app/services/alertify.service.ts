import { Injectable } from '@angular/core';
declare let  alertify : any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  success(mesagge :string){
    alertify.success(mesagge)
  }

  error(mesagge :string){
    alertify.error(mesagge)
  }

  warning(mesagge :string){
    alertify.warning(mesagge)
  }
  message(mesagge :string){
    alertify.success(mesagge)
  }
}
