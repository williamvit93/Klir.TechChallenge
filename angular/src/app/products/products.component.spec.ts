/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClientModule } from '@angular/common/http';
import { of } from 'rxjs';

import { ProductsComponent } from './products.component';
import { ProductsService } from '../services/products.service';
import mockProducts from '../mock/products.json';
import { createMatrix } from '../helpers/matrixHelper';

class MockProductsService {
  getProducts() {
    return of(mockProducts);
  }
}

describe('ProductsComponent', () => {
  let productsComponent: ProductsComponent;
  let fixture: ComponentFixture<ProductsComponent>;
  let productsService: ProductsService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ProductsComponent],
      imports: [HttpClientTestingModule, HttpClientModule],
      providers: [{ provide: ProductsService, useClass: MockProductsService }],
    }).compileComponents();
  }));

  beforeEach(() => {
    productsService = TestBed.get(ProductsService);
    spyOn(productsService, 'getProducts').and.returnValue(of(mockProducts));
    fixture = TestBed.createComponent(ProductsComponent);
    productsComponent = fixture.componentInstance;
    productsComponent.ngOnInit();
  });

  it('should create', () => {
    expect(productsComponent).toBeTruthy();
  });

  it('should call the products API', () => {
    expect(productsService.getProducts).toHaveBeenCalled();
  });

  it('should set the products rows list', () => {
    expect(productsComponent.productsRows).toEqual(
      createMatrix(3, mockProducts)
    );
  });
});
