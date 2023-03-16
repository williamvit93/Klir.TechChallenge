import { HttpClient } from '@angular/common/http';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { CheckoutService } from './checkout.service';
import mockProductPromotions from '../mock/productPromotions.json';
import mockProducts from '../mock/products.json';

describe('CheckoutService', () => {
  let checkoutService: CheckoutService;
  let httpMock: HttpTestingController;
  let httpClient: HttpClient;
  const apiUrl = 'http://localhost:3000/api/';
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        CheckoutService,
        HttpClient,
        { provide: 'BASE_API_URL', useValue: apiUrl },
      ],
    });

    checkoutService = TestBed.get(CheckoutService);
    httpMock = TestBed.get(HttpTestingController);
    httpClient = TestBed.get(HttpClient);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should call the API', () => {
    expect(checkoutService).toBeTruthy();
  });

  it('should return an Observable<ProductPromotion[]>', () => {
    checkoutService
      .getCheckoutProducts(mockProducts)
      .subscribe((productPromotion) => {
        expect(productPromotion.length).toBe(1);
        expect(productPromotion).toEqual(mockProductPromotions);
      });

    const req = httpMock.expectOne(`${apiUrl}checkout`);
    expect(req.request.method).toBe('POST');

    req.flush(mockProductPromotions);
  });
});
