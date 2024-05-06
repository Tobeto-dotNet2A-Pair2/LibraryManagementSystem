import { TestBed } from '@angular/core/testing';

import { MaterialGetbyidService } from './material-getbyid.service';

describe('MaterialGetbyidService', () => {
  let service: MaterialGetbyidService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialGetbyidService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
