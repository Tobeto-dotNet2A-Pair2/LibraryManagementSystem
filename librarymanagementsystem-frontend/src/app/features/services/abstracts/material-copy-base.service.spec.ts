import { TestBed } from '@angular/core/testing';

import { MaterialCopyBaseService } from './material-copy-base.service';

describe('MaterialCopyBaseService', () => {
  let service: MaterialCopyBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialCopyBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
