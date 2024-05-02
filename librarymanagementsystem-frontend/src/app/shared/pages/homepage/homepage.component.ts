import { Component } from '@angular/core';
import { SearchComponent } from '../../components/search/search.component';

@Component({
  standalone: true,
  imports: [SearchComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss',
})
export class HomepageComponent {}
