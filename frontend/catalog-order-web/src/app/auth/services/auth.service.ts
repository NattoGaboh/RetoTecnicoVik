import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);

  login(request: any) {
    return this.http.post(
      `${environment.apiUrl}/auth/login`,
      request
    ).pipe(
      tap((response: any) => {
        localStorage.setItem(
          'token',
          response.data.token
        );

        localStorage.setItem(
          'role',
          response.data.role
        );
      })
    );
  }

  logout() {
    localStorage.clear();
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string | null {
    return localStorage.getItem('role');
  }
}