import { Component, OnInit } from '@angular/core';
import {
  ActivatedRoute,
  Router,
  RouterModule,
  NavigationEnd,
} from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss',
})
export class ToolbarComponent implements OnInit {
  activeRouteName: string = 'giriş';
  activeChildRouteName: string = 'Hoş Geldin!';

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.setActiveRouteNames(); // OnInit'de bir kere çağrılıyor
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        this.setActiveRouteNames(); // Her NavigationEnd olayında çağrılıyor
      });
  }

  setActiveRouteNames(): void {
    this.activeRouteName = this.route.snapshot.routeConfig?.path || '';
    
    this.activeChildRouteName =
      this.route.snapshot.firstChild?.routeConfig?.path || '';
      if (this.activeChildRouteName.endsWith('/:id')) {
        this.activeChildRouteName = this.activeChildRouteName.slice(0, -4); // Son 4 karakteri (/:id) kes

      }
   if (this.activeChildRouteName=="") {
        this.activeChildRouteName = "Hoş Geldin"
       }
      console.log(this.activeChildRouteName)
  }

}
