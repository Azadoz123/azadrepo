import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';

import { Photo } from '../models/photo';
import { AlertifyService } from '../services/alertify.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.css']
})
export class PhotoComponent implements OnInit {

  constructor( 
    private authService: AuthService,
    private alertifyService: AlertifyService,
    private activatedRoute: ActivatedRoute,

    ) { }

    photos: Photo[] = []; 
    uploader!: FileUploader;
    hasBaseDropZoneOver = false;
    baseUrl = 'https://localhost:7175/api/';
    currentMain!: Photo;
    currentCity:any;
    hasAnotherDropZoneOver!: boolean;
    response!: string;

  ngOnInit( ) {
    this.activatedRoute.params.subscribe(params => {
      this.currentCity = params['cityId']});
      console.log(this.currentCity + '***************')
    this.initializeUploader();
  }

  initializeUploader(){
    this.uploader = new FileUploader({
      url: this.baseUrl + 'cities/' + this.currentCity + '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      autoUpload: false,
      removeAfterUpload: true,
      maxFileSize: 10*1024*1024
    });
    this.uploader.onBeforeUploadItem = (item) => {
      item.withCredentials = false;
    }
    this.uploader.onSuccessItem = (item, response, status, headers) =>{
      if(response){
        const res: Photo = JSON.parse(response); 
        const photo = {
          id: res.id,
          url: res.url,
          description: res.description,
          dateAdded: res.dateAdded,
          isMain: res.isMain,
          cityId: res.cityId
        }
         this.photos.push(photo);
      }
    }
  }
}