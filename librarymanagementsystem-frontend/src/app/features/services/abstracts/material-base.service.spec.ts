import { TestBed } from '@angular/core/testing';

import { MaterialBaseService } from './material-base.service';

describe('MaterialBaseService', () => {
  let service: MaterialBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
