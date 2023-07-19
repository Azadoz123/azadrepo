import { TestBed } from '@angular/core/testing';
import { ModuleService } from './services/module.service';
import { RestService } from '@abp/ng.core';

describe('ModuleService', () => {
  let service: ModuleService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(ModuleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
