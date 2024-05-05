import { Component } from '@angular/core';
import { CarouselModule, OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [CarouselModule],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.scss'
})
export class HeroComponent {
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    autoplay:true,
    dots: true,
    navSpeed: 700,
    navText: ['', ''],
    nav: false,
    responsive: {
      0: {
        items: 1
      }
    
    },
    
  }

}
