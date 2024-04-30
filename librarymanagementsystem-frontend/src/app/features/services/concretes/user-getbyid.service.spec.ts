import { TestBed } from '@angular/core/testing';

import { UserGetbyidService } from './user-getbyid.service';

describe('UserGetbyidService', () => {
  let service: UserGetbyidService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserGetbyidService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
