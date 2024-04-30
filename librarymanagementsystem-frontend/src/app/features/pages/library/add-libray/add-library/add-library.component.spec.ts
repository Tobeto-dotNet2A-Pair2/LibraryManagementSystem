import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLibraryComponent } from './add-library.component';

describe('AddLibraryComponent', () => {
  let component: AddLibraryComponent;
  let fixture: ComponentFixture<AddLibraryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddLibraryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddLibraryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
