import { Component } from '@angular/core';
import { SocialsComponent } from '../../../shared/components/socials/socials.component';


@Component({
  selector: 'app-question',
  standalone: true,
  imports: [ SocialsComponent],
  templateUrl: './question.component.html',
  styleUrl: './question.component.scss'
})
export class QuestionComponent {
  cities: any[]; // Şehirleri tutacak dizi
  selectedCities: any[]; // Seçilen şehirleri tutacak dizi

  constructor() {
    // Şehirler dizisi oluşturuluyor
    this.cities = [
      { name: 'İstanbul' },
      { name: 'Ankara' },
      { name: 'İzmir' },
      { name: 'Bursa' },
      { name: 'Antalya' }
    ];

    this.selectedCities = []; // Seçilen şehirler dizisi başlangıçta boş olarak başlatılıyor
  }
}
