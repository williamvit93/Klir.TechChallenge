import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { CheckoutService } from '../services/checkout.service';
import { CheckoutComponent } from './checkout.component';
import mockProductPromotions from '../mock/productPromotions.json';

class MockCheckoutService {
  getCheckoutProducts() {
    return of(mockProductPromotions);
  }
}

describe('CheckoutComponent', () => {
  let checkoutComponent: CheckoutComponent;
  let fixture: ComponentFixture<CheckoutComponent>;
  let checkoutService: CheckoutService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CheckoutComponent],
      imports: [HttpClientTestingModule, HttpClientModule],
      providers: [{ provide: CheckoutService, useClass: MockCheckoutService }],
    }).compileComponents();
  }));

  beforeEach(() => {
    checkoutService = TestBed.get(CheckoutService);
    spyOn(checkoutService, 'getCheckoutProducts').and.returnValue(
      of(mockProductPromotions)
    );
    fixture = TestBed.createComponent(CheckoutComponent);
    checkoutComponent = fixture.componentInstance;
    checkoutComponent.ngOnInit();
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(checkoutComponent).toBeTruthy();
  });

  it('should call the checkout API', () => {
    expect(checkoutService.getCheckoutProducts).toHaveBeenCalled();
  });

  it('should set the products rows list', () => {
    expect(checkoutComponent.productPromotions).toEqual(mockProductPromotions);
  });

  it('should show quantity of products in the checkout', () => {
    const qtyCheckoutProducts = fixture.nativeElement.querySelector(
      '#qtyCheckoutProducts'
    );
    expect(qtyCheckoutProducts.textContent).toBe('7');
  });

  it('should show checkout empty message', () => {
    const noProductsInTheCheckoutMessage = fixture.nativeElement.querySelector(
      '#noProductsInTheCheckoutMessage'
    );
    expect(noProductsInTheCheckoutMessage).toBeNull();
  });
});
