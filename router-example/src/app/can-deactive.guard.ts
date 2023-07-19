import { CanDeactivateFn } from '@angular/router';
import { Observable } from 'rxjs';

export interface CanComponentDeactive{
  canDeactive?: () => Observable<boolean> | Promise<boolean> | boolean;
}

export const canDeactiveGuard: CanDeactivateFn<CanComponentDeactive> =
 (component: CanComponentDeactive) => component.canDeactive ? component.canDeactive() : true;
