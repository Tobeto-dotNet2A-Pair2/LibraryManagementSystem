import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [ MultiSelectModule, FormsModule ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
 
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
