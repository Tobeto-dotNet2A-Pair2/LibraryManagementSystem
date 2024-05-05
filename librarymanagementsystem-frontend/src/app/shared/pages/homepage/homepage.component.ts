import { Component } from '@angular/core';
import { SearchComponent } from '../../components/search/search.component';
import { HeroComponent } from '../../../features/components/hero/hero.component';

@Component({
  standalone: true,
  imports: [SearchComponent,  HeroComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss',
})
export class HomepageComponent {
  
}
