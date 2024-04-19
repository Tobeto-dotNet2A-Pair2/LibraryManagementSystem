import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMaterialFormComponent } from './add-material-form.component';

describe('AddMaterialFormComponent', () => {
  let component: AddMaterialFormComponent;
  let fixture: ComponentFixture<AddMaterialFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddMaterialFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddMaterialFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
