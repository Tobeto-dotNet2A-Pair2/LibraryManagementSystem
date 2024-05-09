import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [RouterModule, FormsModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})
export class SearchComponent {

  //
  searchText: string = '';
  constructor(private router: Router) {}

  performSearch() {
    if (this.searchText.trim().length >= 1) {
      // Arama terimine göre bir sayfaya yönlendirme yapabilirsiniz
      console.log('search metodu');
      this.router.navigate(['/homepage/app-material-list-home'], { queryParams: { q: this.searchText.trim() } });
    }
  }


}
