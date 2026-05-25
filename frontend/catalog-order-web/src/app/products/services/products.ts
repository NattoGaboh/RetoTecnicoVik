import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';


@Injectable({
  providedIn: 'root',
})
export class Products {
   private http = inject(HttpClient);

  getProducts(
    page = 1,
    pageSize = 10,
    search = ''
  ) {

    return this.http.get(
      `${environment.apiUrl}/products?page=${page}&pageSize=${pageSize}&search=${search}`
    );
  }

  create(request: any) {
    return this.http.post(
      `${environment.apiUrl}/products`,
      request
    );
  }
}
