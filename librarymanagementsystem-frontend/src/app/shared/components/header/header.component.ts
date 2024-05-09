import { Component } from '@angular/core';
import { SearchComponent } from '../search/search.component';
import { CommonModule } from '@angular/common';
import { LocalStorageService } from '../../../core/services/concretes/local-storage.service';
import { HeaderItemFavoriesComponent } from '../header-item-favories/header-item-favories.component';
import { HeaderItemUsermenuComponent } from '../header-item-usermenu/header-item-usermenu.component';
import { Router, RouterModule } from '@angular/router';
import { MyProfileComponent } from '../../../features/pages/my-profile/my-profile.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, SearchComponent, HeaderItemFavoriesComponent, HeaderItemUsermenuComponent, RouterModule, MyProfileComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  constructor(private localStorageService: LocalStorageService, private router: Router) {}

  isToken(): boolean {
    const token = this.localStorageService.getToken();
    return !!token; 
  }
  logout(): void {
    this.localStorageService.removeToken();
    this.router.navigate(['/homepage']);
  }

}
