import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class Orders {

  private http = inject(HttpClient);

  create(request: any) {

    return this.http.post(
      `${environment.apiUrl}/orders`,
      request
    );
  }
}
