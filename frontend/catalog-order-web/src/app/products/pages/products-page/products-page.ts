import { Component, inject, OnInit, ChangeDetectorRef } from '@angular/core';
import { Products } from '../../services/products';
import { Categories } from '../../../categories/services/categories';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-products-page',
imports: [
  CommonModule,
  FormsModule,
  MatCardModule,
  MatInputModule,
  MatButtonModule,
  MatTableModule
],
  templateUrl: './products-page.html',
  styleUrl: './products-page.scss',
})
export class ProductsPage 
implements OnInit {

  private productsService =
    inject(Products);

  private categoriesService =
    inject(Categories);

  products: any[] = [];

  categories: any[] = [];

  displayedColumns: string[] = [
    'nombre',
    'precio',
    'stock',
    'categoria',
    'activo'
  ];

  search = '';

  name = '';

  description = '';

  price = 0;

  stock = 0;

  categoryId = '';

  ngOnInit(): void {

    this.loadProducts();

    this.loadCategories();
  }

  loadProducts() {

    this.productsService
      .getProducts(1, 10, this.search)
      .subscribe((response: any) => {

        this.products = response.items;
      });
  }

  loadCategories() {

    this.categoriesService
      .getAll()
      .subscribe((response: any) => {

        this.categories = response;
      });
  }

  createProduct() {

    const request = {
      name: this.name,
      description: this.description,
      price: this.price,
      stock: this.stock,
      categoryId: this.categoryId
    };

    this.productsService
      .create(request)
      .subscribe(() => {

        this.clearForm();

        this.loadProducts();
      });
  }

  clearForm() {

    this.name = '';

    this.description = '';

    this.price = 0;

    this.stock = 0;

    this.categoryId = '';
  }
}
