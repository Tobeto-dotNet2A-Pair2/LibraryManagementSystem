import { TestBed } from '@angular/core/testing';

import { BorrowMaterialService } from './borrow-material.service';

describe('BorrowMaterialService', () => {
  let service: BorrowMaterialService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BorrowMaterialService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
