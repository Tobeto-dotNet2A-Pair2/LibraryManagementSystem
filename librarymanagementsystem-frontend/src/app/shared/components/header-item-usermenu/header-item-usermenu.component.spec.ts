import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderItemUsermenuComponent } from './header-item-usermenu.component';

describe('HeaderItemUsermenuComponent', () => {
  let component: HeaderItemUsermenuComponent;
  let fixture: ComponentFixture<HeaderItemUsermenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HeaderItemUsermenuComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HeaderItemUsermenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
