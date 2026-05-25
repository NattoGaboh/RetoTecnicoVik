import { Component, inject } from '@angular/core';
import { Router, RouterOutlet, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-main-layout',
  imports: [RouterLink,
    CommonModule,
    RouterOutlet],
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.scss',
})
export class MainLayout {
   private authService = inject(AuthService);

  private router = inject(Router);

  logout() {

    this.authService.logout();

    this.router.navigate(['/login']);
  }
}
