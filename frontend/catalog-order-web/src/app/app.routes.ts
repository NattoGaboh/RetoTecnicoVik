import { Routes } from '@angular/router';
import { Login } from './auth/pages/login/login';
import { ProductsPage } from './products/pages/products-page/products-page';
import { authGuard } from './core/guards/auth.guard';
import { MainLayout } from './layout/main-layout/main-layout';
import { CategoriesPage } from './categories/pages/categories-page/categories-page';
import { OrdersPage } from './orders/pages/orders-page/orders-page';

export const routes: Routes = [
  {
    path: 'login',
    component: Login
  },
  {
    path: '',
    component: MainLayout,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full'
      },
      {
        path: 'products',
        component: ProductsPage
      },
      {
        path: 'categories',
        component: CategoriesPage
      },
      {
        path: 'orders',
        component: OrdersPage
      }
    ]
  },

  {
    path: '**',
    redirectTo: 'login'
  }
];
