import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Crisis } from '../crisis';
import { Observable } from 'rxjs';
import { DialogService } from 'src/app/dialog.service';

@Component({
  selector: 'app-crisis-detail',
  templateUrl: './crisis-detail.component.html',
  styleUrls: ['./crisis-detail.component.css']
})
export class CrisisDetailComponent implements OnInit {
  crisis!: Crisis;
  editname = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dialogService: DialogService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      const crisis : Crisis = data['crisis'];
      this.editname = crisis.name;
      this.crisis = crisis;
    })
  }

  cancel(){
    this.gotoCrises();
  }

  save(){
    this.crisis.name = this.editname;
    this.gotoCrises();
  }

  canDeactive(): Observable<boolean> | boolean {
    // Allow synchronous navigation (`true`) if no crisis or the crisis is unchanged
    if(!this.crisis || this.crisis.name === this.editname){
      return true;
    }
    // Otherwise ask the user with the dialog service and return its
    // observable which resolves to true or false when the user decides
    return this.dialogService.confirm('Discard changes?');
  }

  gotoCrises() {
    const crisisId = this.crisis ? this.crisis.id : null;
    // Pass along the crisis id if available
    // so that the CrisisListComponent can select that crisis.
    // Add a totally useless `foo` parameter for kicks.
    // Relative navigation back to the crises
    this.router.navigate(['../', { id: crisisId, foo: 'foo' }], { relativeTo: this.route });
  }
}
