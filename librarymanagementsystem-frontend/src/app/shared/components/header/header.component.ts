import { Component } from '@angular/core';
import { SearchComponent } from '../search/search.component';
import { HeaderItemsComponent } from '../header-items/header-items.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [SearchComponent, HeaderItemsComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

}
