import { Promotion } from './Promotion';
import { Product } from './Product';

export interface ProductPromotion {
  product: Product;
  totalQuantity: number;
  totalQuantityFree: number;
  totalPrice: number;
  totalDiscount: number;
  isPromotionApplied: boolean;
  promotion: Promotion;
}
