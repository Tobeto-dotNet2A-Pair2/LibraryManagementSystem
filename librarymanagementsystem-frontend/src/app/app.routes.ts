import { Routes } from '@angular/router';
import { HomepageComponent } from './shared/pages/homepage/homepage.component';
import { BookListComponent } from './features/book/pages/book-list/book-list.component';
import { authGuard } from './core/guards/auth.guard';
import { AuthComponent } from './features/auth/pages/auth/auth.component';
import { AdminLayoutComponent } from './shared/layouts/admin-layout/admin-layout.component';

export const routes: Routes = [
  { path: '', redirectTo: 'homepage', pathMatch: 'full' },
  // { path: 'homepage', component: HomepageComponent },
  { path: 'homepage', component: AdminLayoutComponent },
  { path: 'adminpage', component: AdminLayoutComponent, canActivate: [authGuard] },
];
