import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderItemsComponent } from './header-items.component';

describe('HeaderItemsComponent', () => {
  let component: HeaderItemsComponent;
  let fixture: ComponentFixture<HeaderItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HeaderItemsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HeaderItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
