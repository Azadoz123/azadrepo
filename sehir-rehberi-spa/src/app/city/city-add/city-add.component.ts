import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Route } from '@angular/router';
import { City } from 'src/app/models/city';
import { AlertifyService } from 'src/app/services/alertify.service';
import { CityService } from 'src/app/services/city.service';
import { Editor } from 'ngx-editor';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-city-add',
  templateUrl: './city-add.component.html',
  styleUrls: ['./city-add.component.css'],
  providers: [CityService]
})
export class CityAddComponent implements OnInit {
  editor!: Editor;
  constructor(
    private cityService: CityService, 
    private formBuilder: FormBuilder,
    private authService: AuthService
    ) { }

    city!: City;
    cityAddForm!: FormGroup;

    createCityForm(){
      this.cityAddForm = this.formBuilder.group({
        name: ["", Validators.required],
        description: ["", Validators.required]
      })
      // this.formBuilder.group<
    }
  ngOnInit() {
    this.createCityForm();
    
  }
  add(){
    if(this.cityAddForm.valid){
      this.city = Object.assign({},this.cityAddForm.value);
      this.city.userId =this.authService.getCurrentUserId();
      this.cityService.add(this.city);
      // this.alertifyService.success("Şehir başarıyla eklendi.");
    }
  }
}
