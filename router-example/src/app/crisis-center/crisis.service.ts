import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Crisis } from './crisis';
import { CRISES } from './mock-crisis'
import { MessageService } from '../message.service';

@Injectable({
  providedIn: 'root'
})
export class CrisisService {
  static nextCrisisId = 100;
  private crises$: BehaviorSubject<Crisis[]> = new BehaviorSubject<Crisis[]>(CRISES);

  constructor(private messageService: MessageService) { }

  getCrises(){ return this.crises$;}

  getCrisis(id: number | string){
    return this.getCrises().pipe(
      map(crises => crises.find( crisis => crisis.id === +id)!)
    );
  }
}
