import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BorrowedMaterialComponent } from './borrowed-material.component';

describe('BorrowedMaterialComponent', () => {
  let component: BorrowedMaterialComponent;
  let fixture: ComponentFixture<BorrowedMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BorrowedMaterialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BorrowedMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
