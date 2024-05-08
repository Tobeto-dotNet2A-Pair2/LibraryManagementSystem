import { TestBed } from '@angular/core/testing';

import { MaterialListHomeBaseService } from './material-list-home-base.service';

describe('MaterialListHomeBaseService', () => {
  let service: MaterialListHomeBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialListHomeBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
