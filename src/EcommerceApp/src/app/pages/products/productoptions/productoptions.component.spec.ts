import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoptionsComponent } from './productoptions.component';

describe('ProductoptionsComponent', () => {
  let component: ProductoptionsComponent;
  let fixture: ComponentFixture<ProductoptionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductoptionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
