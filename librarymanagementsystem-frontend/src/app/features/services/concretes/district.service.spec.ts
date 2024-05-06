import { TestBed } from '@angular/core/testing';

import { DistrictService } from './district.service';

describe('DistrictService', () => {
  let service: DistrictService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DistrictService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
