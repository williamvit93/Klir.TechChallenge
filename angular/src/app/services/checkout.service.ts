import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductPromotion } from '../models/ProductPromotion';
import { Product } from '../models/Product';

@Injectable({
  providedIn: 'root',
})
export class CheckoutService {
  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_API_URL') private baseUrl: string
  ) {}

  getCheckoutProducts(products: Product[]): Observable<ProductPromotion[]> {
    return this.httpClient.post<ProductPromotion[]>(
      this.baseUrl + 'checkout',
      products
    );
  }
}
