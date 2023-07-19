import { Component, OnInit } from '@angular/core';
import { Observable, switchMap } from 'rxjs';
import { Crisis } from '../crisis';
import { CrisisService } from '../crisis.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-crisis-list',
  templateUrl: './crisis-list.component.html',
  styleUrls: ['./crisis-list.component.css']
})
export class CrisisListComponent implements OnInit{
  crises$?: Observable<Crisis[]>;
  selectedId = 0;

  constructor(
    private service: CrisisService,
    private route : ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.crises$ = this.route.firstChild?.paramMap.pipe(
      switchMap(params => {
        this.selectedId = parseInt(params.get('id')!, 10);
        return this.service.getCrises();
      })
    );
  }

}
