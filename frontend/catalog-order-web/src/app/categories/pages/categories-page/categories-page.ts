import { Component,inject, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Categories } from '../../services/categories';

@Component({
  selector: 'app-categories-page',
  imports: [CommonModule,
            FormsModule],
  templateUrl: './categories-page.html',
  styleUrl: './categories-page.scss',
})
export class CategoriesPage 
implements OnInit {

  private service = inject(Categories);

  categories: any[] = [];

  name = '';

  ngOnInit(): void {

    this.loadCategories();
  }

  loadCategories() {

    this.service.getAll()
      .subscribe((response: any) => {

        this.categories = response;
      });
  }

  createCategory() {

    if (!this.name) return;

    this.service.create({
      name: this.name
    })
    .subscribe(() => {

      this.name = '';

      this.loadCategories();
    });
  }
}
