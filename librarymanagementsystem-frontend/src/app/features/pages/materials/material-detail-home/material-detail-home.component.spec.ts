import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialDetailHomeComponent } from './material-detail-home.component';

describe('MaterialDetailHomeComponent', () => {
  let component: MaterialDetailHomeComponent;
  let fixture: ComponentFixture<MaterialDetailHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MaterialDetailHomeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MaterialDetailHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
