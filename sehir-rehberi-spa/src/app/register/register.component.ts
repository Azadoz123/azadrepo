import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder 
    ) { }

    registerForm!: FormGroup;
    registerUser: any = {}
  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ["", Validators.required]
    },
    {validator: this.passwordMatchValidator}
    )
  }

  passwordMatchValidator(g:FormGroup){
   var val =  g.get('password')?.value === g.get('confirmPassword')?.value ? null : {misMatch: true}
  console.log(val);
  return val;
  }

  register(){
    if(this.registerForm.valid){
      this.registerUser = Object.assign({},this.registerForm.value);
      this.authService.register(this.registerUser);
    }
  }
}
