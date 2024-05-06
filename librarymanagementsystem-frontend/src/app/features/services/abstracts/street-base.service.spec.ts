import { TestBed } from '@angular/core/testing';

import { StreetBaseService } from './street-base.service';

describe('StreetBaseService', () => {
  let service: StreetBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StreetBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
