import { TestBed } from '@angular/core/testing';

import { MaterialListService } from './material-list.service';

describe('MaterialListService', () => {
  let service: MaterialListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
