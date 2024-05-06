import { TestBed } from '@angular/core/testing';

import { MaterialManagementService } from './material-management.service';

describe('MaterialManagementService', () => {
  let service: MaterialManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
