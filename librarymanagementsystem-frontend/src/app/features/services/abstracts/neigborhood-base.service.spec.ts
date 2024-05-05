import { TestBed } from '@angular/core/testing';

import { NeigborhoodBaseService } from './neigborhood-base.service';

describe('NeigborhoodBaseService', () => {
  let service: NeigborhoodBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NeigborhoodBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
