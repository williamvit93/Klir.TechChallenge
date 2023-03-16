import { Component, OnInit } from '@angular/core';
import { CheckoutService } from '../services/checkout.service';
import { ProductPromotion } from '../models/ProductPromotion';
import { ShoppingCartService } from '../services/shopping-cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  private _productPromotions: ProductPromotion[] = [];
  private _totalQuantity = 0;
  private _totalPrice = 0;
  private _totalDiscount = 0;
  private _promotionsApplied = [];

  public get productPromotions() {
    return this._productPromotions;
  }

  public get totalQuantity() {
    return this._totalQuantity;
  }

  public get totalPrice() {
    return this._totalPrice;
  }

  public get totalDiscount() {
    return this._totalDiscount;
  }

  public get promotionsApplied() {
    return this._promotionsApplied;
  }

  getTotalQuantity(productPromotions: ProductPromotion[]) {
    let total = 0;

    productPromotions.forEach((productPromotion) => {
      total += productPromotion.totalQuantity;
    });
    return total;
  }

  getTotalPrice(productPromotions: ProductPromotion[]) {
    let total = 0;

    productPromotions.forEach((productPromotion) => {
      total += productPromotion.totalPrice;
    });
    return total;
  }

  getTotalDiscount(productPromotions: ProductPromotion[]) {
    let total = 0;

    productPromotions.forEach((productPromotion) => {
      total += productPromotion.totalDiscount;
    });
    return total;
  }

  getPromotionsApplied(productPromotions: ProductPromotion[]): string[] {
    const promotions = [];

    productPromotions.forEach((productPromotion) => {
      if (productPromotion.isPromotionApplied) {
        promotions.push(productPromotion.promotion.promotionDescription);
      }
    });

    return promotions.filter(
      (item, index) => promotions.indexOf(item) === index
    );
  }

  constructor(
    private checkoutService: CheckoutService,
    private shoppingCartService: ShoppingCartService
  ) {}

  ngOnInit(): void {
    const products =
      this.shoppingCartService.changeCartProductsSubject.getValue();

    this.checkoutService
      .getCheckoutProducts(products)
      .subscribe((productPromotions) => {
        this._productPromotions = productPromotions;
        this._totalQuantity = this.getTotalQuantity(productPromotions);
        this._totalPrice = this.getTotalPrice(productPromotions);
        this._totalDiscount = this.getTotalDiscount(productPromotions);
        this._promotionsApplied = this.getPromotionsApplied(productPromotions);
      });
  }
}
