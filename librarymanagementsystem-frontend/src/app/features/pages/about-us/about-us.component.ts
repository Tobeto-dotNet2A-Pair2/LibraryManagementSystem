import { Component } from '@angular/core';
import { SocialsComponent } from '../../../shared/components/socials/socials.component';
import { RouterModule } from '@angular/router';
import { TeamComponent } from '../../components/team/team.component';


@Component({
  selector: 'app-about-us',
  standalone: true,
  imports: [SocialsComponent, RouterModule,  TeamComponent],
  templateUrl: './about-us.component.html',
  styleUrl: './about-us.component.scss'
})
export class AboutUsComponent {
 

}
