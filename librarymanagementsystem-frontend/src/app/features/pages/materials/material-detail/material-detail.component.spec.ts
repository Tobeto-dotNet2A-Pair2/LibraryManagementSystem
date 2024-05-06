import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialDetailComponent } from './material-detail.component';

describe('MaterialDetailComponent', () => {
  let component: MaterialDetailComponent;
  let fixture: ComponentFixture<MaterialDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MaterialDetailComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MaterialDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
