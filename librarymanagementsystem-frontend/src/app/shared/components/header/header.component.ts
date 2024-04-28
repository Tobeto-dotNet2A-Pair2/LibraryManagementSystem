import { Component } from '@angular/core';
import { SearchComponent } from '../search/search.component';
import { CommonModule } from '@angular/common';
import { LocalStorageService } from '../../../core/services/concretes/local-storage.service';
import { HeaderItemFavoriesComponent } from '../header-item-favories/header-item-favories.component';
import { HeaderItemUsermenuComponent } from '../header-item-usermenu/header-item-usermenu.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, SearchComponent, HeaderItemFavoriesComponent, HeaderItemUsermenuComponent, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  constructor(private localStorageService: LocalStorageService) {}

  isToken(): boolean {
    const token = this.localStorageService.getToken();
    return !!token; 
  }
}
