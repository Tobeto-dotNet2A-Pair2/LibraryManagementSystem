import { Component } from '@angular/core';
import { SearchComponent } from '../../components/search/search.component';
import { HeroComponent } from '../../../features/components/hero/hero.component';
import { SocialsComponent } from '../../components/socials/socials.component';

@Component({
  standalone: true,
  imports: [SearchComponent,  HeroComponent, SocialsComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss',
})
export class HomepageComponent {
  
}
