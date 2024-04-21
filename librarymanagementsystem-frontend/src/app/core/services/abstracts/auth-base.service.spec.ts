import { TestBed } from '@angular/core/testing';

import { AuthBaseService } from './auth-base.service';

describe('AuthBaseService', () => {
  let service: AuthBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
