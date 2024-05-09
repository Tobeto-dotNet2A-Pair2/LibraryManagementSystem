import { TestBed } from '@angular/core/testing';

import { MaterialListHomeService } from './material-list-home.service';

describe('MaterialListHomeService', () => {
  let service: MaterialListHomeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialListHomeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
