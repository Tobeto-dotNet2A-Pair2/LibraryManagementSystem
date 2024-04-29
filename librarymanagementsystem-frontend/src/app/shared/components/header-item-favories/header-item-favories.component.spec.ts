import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderItemFavoriesComponent } from './header-item-favories.component';

describe('HeaderItemFavoriesComponent', () => {
  let component: HeaderItemFavoriesComponent;
  let fixture: ComponentFixture<HeaderItemFavoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HeaderItemFavoriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HeaderItemFavoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
