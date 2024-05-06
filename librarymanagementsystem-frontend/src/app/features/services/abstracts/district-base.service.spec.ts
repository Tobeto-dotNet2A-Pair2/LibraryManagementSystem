import { TestBed } from '@angular/core/testing';

import { DistrictBaseService } from './district-base.service';

describe('DistrictBaseService', () => {
  let service: DistrictBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DistrictBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
