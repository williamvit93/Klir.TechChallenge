import { TestBed } from '@angular/core/testing';
import { ShoppingCartService } from './shopping-cart.service';
import mockProducts from '../mock/products.json';

describe('ShoppingCartService', () => {
  let service: ShoppingCartService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ShoppingCartService],
    });
    service = TestBed.get(ShoppingCartService);
  });

  it('should add a product to the cart', () => {
    service.addCartProduct(mockProducts[0]);

    expect(service.changeCartProductsSubject.getValue()).toEqual([
      mockProducts[0],
    ]);
  });

  it('should add different products to the cart', () => {
    service.addCartProduct(mockProducts[0]);
    service.addCartProduct(mockProducts[1]);

    expect(service.changeCartProductsSubject.getValue()).toEqual([
      mockProducts[0],
      mockProducts[1],
    ]);
  });
});
