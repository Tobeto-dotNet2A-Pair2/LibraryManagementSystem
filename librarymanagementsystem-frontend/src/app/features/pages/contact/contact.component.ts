import { Component } from '@angular/core';
import { SocialsComponent } from '../../../shared/components/socials/socials.component';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [SocialsComponent],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {

}
