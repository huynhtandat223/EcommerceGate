import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductdedailComponent } from './productdedail.component';

describe('ProductdedailComponent', () => {
  let component: ProductdedailComponent;
  let fixture: ComponentFixture<ProductdedailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductdedailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductdedailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
