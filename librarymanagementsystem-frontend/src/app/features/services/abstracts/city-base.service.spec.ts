import { TestBed } from '@angular/core/testing';

import { CityBaseService } from './city-base.service';

describe('CityBaseService', () => {
  let service: CityBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CityBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
