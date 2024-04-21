import { TestBed } from '@angular/core/testing';

import { AddressBaseService } from './address-base.service';

describe('AddressBaseService', () => {
  let service: AddressBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddressBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
