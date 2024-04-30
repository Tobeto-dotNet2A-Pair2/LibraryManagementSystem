import { TestBed } from '@angular/core/testing';

import { MemberGetbyidService } from './member-getbyid.service';

describe('MemberGetbyidService', () => {
  let service: MemberGetbyidService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MemberGetbyidService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
