import { TestBed } from '@angular/core/testing';

import { MaterialManagementBaseService } from './material-management-base.service';

describe('MaterialManagementBaseService', () => {
  let service: MaterialManagementBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialManagementBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
