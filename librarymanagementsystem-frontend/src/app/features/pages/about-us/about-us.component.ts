import { Component } from '@angular/core';
import { SocialsComponent } from '../../../shared/components/socials/socials.component';

@Component({
  selector: 'app-about-us',
  standalone: true,
  imports: [SocialsComponent],
  templateUrl: './about-us.component.html',
  styleUrl: './about-us.component.scss'
})
export class AboutUsComponent {

}
