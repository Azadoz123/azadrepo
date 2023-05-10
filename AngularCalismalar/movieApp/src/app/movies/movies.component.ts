import { Component } from "@angular/core";
import { Movie } from "../movie";
import { MovieService } from "../movie.service";


@Component({
    selector: 'movies',
    templateUrl: './movies.component.html'
})
export class MoviesComponent {
    title: string = 'Movie List';
    movies!: Movie[];
    selectedMovie: Movie = new Movie;

    constructor(private movieService: MovieService) { }

    ngOnInit(): void {
        this.getMovies();
    }

    onSelect(movie: Movie): void {
        this.selectedMovie = movie;
    }

    getMovies(): void {
        this.movieService.getMovies()
            .subscribe(movies => {
                this.movies = movies;
            });
    }
    add(name:string, imageUrl:string, description:string): void {
        // console.log(name);
        // console.log(imageUrl);
        // console.log(description);
        this.movieService.add({
            name,
            imageUrl,
            description
        } as Movie).subscribe(movie => this.movies.push(movie));
    }

    delete(movie: Movie): void{
        this.movies = this.movies.filter(m => m !== movie);
        this.movieService.delete(movie).subscribe();
    }
}