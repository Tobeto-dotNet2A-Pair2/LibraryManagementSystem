import { Component } from '@angular/core';
import { SocialsComponent } from '../../../shared/components/socials/socials.component';

@Component({
  selector: 'app-question',
  standalone: true,
  imports: [SocialsComponent],
  templateUrl: './question.component.html',
  styleUrl: './question.component.scss'
})
export class QuestionComponent {

}
