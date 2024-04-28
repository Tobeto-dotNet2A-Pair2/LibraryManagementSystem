import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberProfileComponent } from './member-profile.component';

describe('MemberProfileComponent', () => {
  let component: MemberProfileComponent;
  let fixture: ComponentFixture<MemberProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MemberProfileComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MemberProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
