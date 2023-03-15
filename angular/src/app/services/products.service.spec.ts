import { TestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';
import { ProductsService } from './products.service';
import mockProducts from '../mock/products.json';

describe('ProductsService', () => {
  let productsService: ProductsService;
  let httpMock: HttpTestingController;
  let httpClient: HttpClient;
  const apiUrl = 'http://localhost:3000/api/';

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        ProductsService,
        HttpClient,
        { provide: 'BASE_API_URL', useValue: apiUrl },
      ],
    });

    productsService = TestBed.get(ProductsService);
    httpMock = TestBed.get(HttpTestingController);
    httpClient = TestBed.get(HttpClient);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should return an Observable<Product[]>', () => {
    productsService.getProducts().subscribe((products) => {
      expect(products.length).toBe(4);
      expect(products).toEqual(mockProducts);
    });

    const req = httpMock.expectOne(`${apiUrl}products`);
    expect(req.request.method).toBe('GET');

    req.flush(mockProducts);
  });
});
