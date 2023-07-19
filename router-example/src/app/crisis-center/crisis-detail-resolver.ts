import { ActivatedRouteSnapshot, ResolveFn, Router } from '@angular/router';
import { Crisis } from './crisis';
import { inject } from '@angular/core';
import { CrisisService } from './crisis.service';
import { EMPTY, mergeMap, of } from 'rxjs';

export const crisisDetailResolver: ResolveFn<Crisis> = (route: ActivatedRouteSnapshot) => {
  const router = inject(Router);
  const cs = inject(CrisisService);
  const id = route.paramMap.get('id')!;

  return cs.getCrisis(id).pipe(mergeMap(crisis => {
    if(crisis) {
      return of(crisis);
    }else {
      router.navigate(['/crisis-center']);
      return EMPTY;
    }
  }))
};
