import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { City } from 'src/app/models/city';
import { CityService } from 'src/app/services/city.service';
import { Photo } from 'src/app/models/photo';
import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';


@Component({
  selector: 'app-city-detail',
  templateUrl: './city-detail.component.html',
  styleUrls: ['./city-detail.component.css'],
  providers: [CityService]
})
export class CityDetailComponent implements OnInit {
  constructor(
    private activatedRoute : ActivatedRoute, 
    private cityService : CityService
  ) { }

  city!: City;
  photos: Photo[] =[];

  galleryOptions!: NgxGalleryOptions[];
  galleryImages!: NgxGalleryImage[];
  ngOnInit() {
    this.activatedRoute.params.subscribe(params =>{
      this.getCityById(params["cityId"]);
     
      console.log(params);
      console.log(params);

      this.getPhotosByCity(params["cityId"])
    });
  }

  getCityById(cityId :number){
    console.log(cityId);
   
    this.cityService.getCityById(cityId).subscribe(data=>{
      this.city =data;
        // console.log(this.city.name);
         console.log(data);
      // this.setGallery();
    })
    // this.getPhotosByCity(cityId);
  } 

  getPhotosByCity(cityId :number){
    this.cityService.getPhotosById(cityId).subscribe(data=>{
      this.photos = data;
      console.log(this.photos[0].url);
     
       this.setGallery();
    })
  }

  getImages(){
    const imageUrls= [] ;
    //  console.log(this.city.photo[0].url);
     console.log(this.photos[0].url);
    // for (let i = 0; i < this.city.photo.length; i++) {
    //   imageUrls.push({
    //     small: this.city.photo[i].url,
    //     medium: this.city.photo[i].url,
    //     big: this.city.photo[i].url
    //   })
    // }

    for (let i = 0; i < this.photos.length; i++) {
      imageUrls.push({
        small: this.photos[i].url,
        medium: this.photos[i].url,
        big: this.photos[i].url
      })
    }
    return imageUrls;
  }
  setGallery(){
    this.galleryOptions = [
      {
        width: '600px',
        height: '400px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
        breakpoint: 800,
        width: '100%',
        height: '600px',
        imagePercent: 80,
        thumbnailsPercent: 20,
        thumbnailsMargin: 20,
        thumbnailMargin: 20
      },
      // max-width 400
      {
        breakpoint: 400,
        preview: false
      }
    ];

    this.galleryImages = this.getImages() ;
  }
}
