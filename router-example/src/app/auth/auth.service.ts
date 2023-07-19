import { Injectable } from '@angular/core';
import { Observable, delay, of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;

  // store the URL so we can redirect after logging in
  redirectUrl: string | null = null;
  constructor() { }

  login(): Observable<boolean>{
    return of(true).pipe(
      delay(1000),
      tap(()=> this.isLoggedIn = true)
    );
  }

  logOut(): void{
    this.isLoggedIn = false;
  }
}
