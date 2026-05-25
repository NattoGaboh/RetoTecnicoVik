import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Products } from '../../../products/services/products';
import { Orders } from '../../services/orders';

@Component({
  selector: 'app-orders-page',
  imports: [CommonModule,
    FormsModule],
  templateUrl: './orders-page.html',
  styleUrl: './orders-page.scss',
})
export class OrdersPage 
implements OnInit {

  private productsService = inject(Products);

  private ordersService = inject(Orders);

  products: any[] = [];

  cart: any[] = [];

  selectedProductId = '';

  quantity = 1;

  message = '';

  total = 0;

  ngOnInit(): void {

    this.loadProducts();
  }

  loadProducts() {

    this.productsService.getProducts()
      .subscribe((response: any) => {

        this.products = response.items;
      });
  }

  addItem() {

    if (!this.selectedProductId)
      return;

    const product = this.products.find(
      x => x.id === this.selectedProductId
    );

    if (!product)
      return;

    const subtotal =
      product.price * this.quantity;

    this.cart.push({

      productId: product.id,

      productName: product.name,

      quantity: this.quantity,

      unitPrice: product.price,

      subtotal: subtotal
    });

    this.calculateTotal();

    this.quantity = 1;
  }

  calculateTotal() {

    this.total = this.cart.reduce(
      (sum, item) =>
        sum + item.subtotal,
      0
    );
  }

  removeItem(index: number) {

    this.cart.splice(index, 1);

    this.calculateTotal();
  }

  createOrder() {

    if (this.cart.length === 0)
      return;

    const request = {

      items: this.cart.map(x => ({

        productId: x.productId,

        quantity: x.quantity
      }))
    };

    this.ordersService
      .create(request)
      .subscribe({

        next: () => {

          this.message =
            'Orden creada satisfactoriamente';

          this.cart = [];

          this.total = 0;

          this.loadProducts();
        },

        error: (err) => {

          this.message =
            err.error.message ||
            'Error creando la orden';
        }
      });
  }
}