import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { City } from '../models/city';
import { Photo } from '../models/photo';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root'
})
export class CityService {

constructor(
  private httpClient: HttpClient,
  private alertifyService: AlertifyService,
  private router: Router
  ) { }

path="https://localhost:7175/api/";

getCities(): Observable<City[]> {
  return this.httpClient.get<City[]>(this.path+"Cities")
}

getCityById(cityId: number):Observable<City>{
  return this.httpClient.get<City>(this.path+"cities/detail?id="+cityId)
}
getPhotosById(cityId :number):Observable<Photo[]>{
  return this.httpClient.get<Photo[]>(this.path +"cities/photos?cityId="+cityId)
}
add(city: City){
  console.log(city)
  this.httpClient.post<City>(this.path + "cities/add",city).subscribe(data =>{
    this.alertifyService.success("Şehir başarıyla eklendi.");
    // this.router.navigateByUrl('/citydetail/'+ data["id"])
    this.router.navigateByUrl('/cityDetail/'+ data.id)
  });
  
}
}