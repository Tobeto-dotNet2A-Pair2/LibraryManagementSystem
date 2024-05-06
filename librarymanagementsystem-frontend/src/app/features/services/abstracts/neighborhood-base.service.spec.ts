import { TestBed } from '@angular/core/testing';

import { NeighborhoodBaseService } from './neighborhood-base.service';

describe('NeighborhoodBaseService', () => {
  let service: NeighborhoodBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NeighborhoodBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
