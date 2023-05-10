import { Injectable } from '@angular/core';
import { Post } from './post';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';


@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(
    private http:HttpClient
  ) { }

  path:string = "https://jsonplaceholder.typicode.com/"

  getPosts(userid?: string) : Observable< Post[]>{
    //  debugger; 
    if(userid){
      let newPath = this.path + "posts?userId="+userid;
     return this.http.get<Post[]>(newPath);
    }else{
     return this.http.get<Post[]>(this.path + "posts");
    }
   
  }
}
