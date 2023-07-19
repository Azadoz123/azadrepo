import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { ModuleComponent } from './components/module.component';
import { ModuleService } from '@allegory/module';
import { of } from 'rxjs';

describe('ModuleComponent', () => {
  let component: ModuleComponent;
  let fixture: ComponentFixture<ModuleComponent>;
  const mockModuleService = jasmine.createSpyObj('ModuleService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ModuleComponent],
      providers: [
        {
          provide: ModuleService,
          useValue: mockModuleService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
