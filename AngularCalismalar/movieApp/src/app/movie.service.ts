import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { LoggingService } from './logging.service';
import { Movie } from './movie';
import { Movies } from './movie.datasource';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private apiMoviesUrl = 'api/movies';

  constructor(
    private loggingService :LoggingService,
    private http : HttpClient
    ) { }

  getMovies(): Observable<Movie[]>{
    this.loggingService.add('MovieService: listing service');
    // return of(Movies);
    return this.http.get<Movie[]>(this.apiMoviesUrl);
  }

  getMovie(id:number): Observable<Movie  > {
    this.loggingService.add('MovieService: get detail by id='+id);
  //  return of(Movies.find(movie => movie.id === id) as Movie) ;
   return this.http.get<Movie>(this.apiMoviesUrl + '/' + id);
  }

  update(movie: Movie) : Observable<any>{
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.put(this.apiMoviesUrl, movie, httpOptions)
  }

  add(movie: Movie): Observable<Movie>{
    return this.http.post<Movie>(this.apiMoviesUrl, movie)
  }

  delete(movie: Movie): Observable<Movie>{
     return this.http.delete<Movie>(this.apiMoviesUrl+'/'+movie.id,)
  }
}
