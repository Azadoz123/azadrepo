import { Injectable } from '@angular/core';
import { LoginUser } from '../models/loginUser';
import {HttpClient, HttpHeaders } from '@angular/common/http'
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { AlertifyService } from './alertify.service';
import { RegisterUser } from '../models/registerUser';
import { Value } from '../models/value';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(
  private httpClient: HttpClient, 
  private router: Router,
  private alertifyService: AlertifyService
  ) { }

path="https://localhost:7175/api/auth/";
userToken: any
decodedToken: any;
jwtHelper: JwtHelperService = new JwtHelperService();
TOKEN_KEY ="token";
azad: string ="";
obje!: String;

login(loginUser: LoginUser){

let headers = new HttpHeaders();
headers = headers.append("Content-Type","application/json");

// this.httpCient.post<any>(this.path + "login",loginUser,{headers:headers})
// this.httpClient.post<string>(this.path + "login",loginUser)
// this.httpClient.post<Value>(this.path + "login",loginUser,{headers:headers})
this.httpClient.post<string>(this.path + "login",loginUser,{headers:headers})
.subscribe(data =>{
  //  this.saveData(data["tokenString"]);
  // this.userToken = data['tokenString'];
  // this.decodedToken = this.jwtHelper.decodeToken(data['tokenString']);
  console.log(data);
   this.saveData(data);
  this.userToken = data;
  this.decodedToken = this.jwtHelper.decodeToken(data);
  // console.log(data);
  //  this.obje=  JSON.parse(data)
  //  console.log(this.obje["name"])
  //  console.log(data['name']); 
  // console.log(data['tokenString']);
  // console.log(this.decodedToken);
  this.alertifyService.success("Sisteme giriş yapıldı.")
  this.router.navigateByUrl('city')
  console.log("selam");
  //  this.jwtHelper.decodeToken(data)
  // this.azad=data;
})
}

register( registerUser: RegisterUser){
  let headers = new HttpHeaders();
  headers = headers.append("Content-Type","application/json");
  this.httpClient.post(this.path + "register", registerUser)
  .subscribe(data=> {

  });
}
    saveData(token: any){
  //  saveData(token: string){
    localStorage.setItem(this.TOKEN_KEY, token);
    console.log("aaaaa" + token  )
    console.log(this.TOKEN_KEY);
    
  }

  logOut(){
    localStorage.removeItem(this.TOKEN_KEY);
    this.alertifyService.error("Sistemden çıkış yapıldı.")
  }

  loggedIn(){
    console.log(this.TOKEN_KEY);
    console.log("azad");
    return this.jwtHelper.isTokenExpired(localStorage.getItem(this.TOKEN_KEY));
   
    //  return this.jwtHelper.isTokenExpired(this.azad);
  }

  get token(){
    return localStorage.getItem(this.TOKEN_KEY);
  }
  getCurrentUserId(){
    return this.jwtHelper.decodeToken(this.token as string).nameid
  }
}
