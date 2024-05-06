import { TestBed } from '@angular/core/testing';

import { StreetService } from './street.service';

describe('StreetService', () => {
  let service: StreetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StreetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
