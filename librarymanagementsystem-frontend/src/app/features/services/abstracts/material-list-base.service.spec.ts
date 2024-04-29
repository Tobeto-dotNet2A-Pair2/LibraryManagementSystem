import { TestBed } from '@angular/core/testing';

import { MaterialListBaseService } from './material-list-base.service';

describe('MaterialListBaseService', () => {
  let service: MaterialListBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialListBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
