import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialListHomeComponent } from './material-list-home.component';

describe('MaterialListHomeComponent', () => {
  let component: MaterialListHomeComponent;
  let fixture: ComponentFixture<MaterialListHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MaterialListHomeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MaterialListHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
