import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/Product';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartService {
  private _cartProducts: Product[] = [];
  public changeCartProductsSubject = new BehaviorSubject<Product[]>([]);

  public addCartProduct(cartProduct: Product) {
    this._cartProducts = [...this._cartProducts, cartProduct];
    this.changeCartProductsSubject.next(this._cartProducts);
  }
}
