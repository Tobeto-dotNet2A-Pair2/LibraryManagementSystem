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
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        this.activeRouteName = this.route.snapshot.routeConfig?.path || '';
        this.activeChildRouteName =
          this.route.snapshot.firstChild?.routeConfig?.path || '';
      });
  }
}
