import { TestBed } from '@angular/core/testing';

import { MaterialCopyService } from './material-copy.service';

describe('MaterialCopyService', () => {
  let service: MaterialCopyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialCopyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
