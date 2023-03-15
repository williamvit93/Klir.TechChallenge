import { Promotion } from './Promotion';

export interface Product {
  id: number;
  name: string;
  price: number;
  promotion: Promotion;
}
