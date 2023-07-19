import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CrisisListComponent } from './crisis-center/crisis-list/crisis-list.component';
//import { HeroListComponent } from './heroes/hero-list/hero-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HeroesModule } from './heroes/heroes.module';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CrisisCenterModule } from './crisis-center/crisis-center.module';
import { ComposeMessageComponent } from './compose-message/compose-message.component';
//import { AdminModule } from './admin/admin.module';
import { LoginComponent } from './auth/login/login.component';
import { AuthModule } from './auth/auth.module';
import { Router } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    CrisisListComponent,
  //  HeroListComponent,
    PageNotFoundComponent,
  ComposeMessageComponent,
  LoginComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HeroesModule,
    // CrisisCenterModule,
   // AdminModule,
    AuthModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  // Diagnostic only: inspect router configuration
  // constructor(router: Router){
  //   // Use a custom replacer to display function names in the route configs
  //   const replacer = (key: any, value: any) => (typeof value === 'function') ? value.name : value;

  //   console.log('Routes: ', JSON.stringify(router.config, replacer, 2));
  // }
}
