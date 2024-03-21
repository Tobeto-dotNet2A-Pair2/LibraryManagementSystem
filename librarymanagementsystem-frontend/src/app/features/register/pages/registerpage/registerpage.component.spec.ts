import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterpageComponent } from './registerpage.component';

describe('RegisterpageComponent', () => {
  let component: RegisterpageComponent;
  let fixture: ComponentFixture<RegisterpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterpageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegisterpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
