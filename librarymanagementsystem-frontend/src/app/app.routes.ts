import { Routes } from '@angular/router';
import { HomepageComponent } from './shared/pages/homepage/homepage.component';
import { BookListComponent } from './features/book/pages/book-list/book-list.component';
import { authGuard } from './core/guards/auth.guard';
import { RegisterpageComponent } from './features/register/pages/registerpage/registerpage.component';

export const routes: Routes = [
  { path: '', redirectTo: 'homepage', pathMatch: 'full' },
  // { path: 'homepage', component: HomepageComponent },
  { path: 'homepage', component: RegisterpageComponent },
  { path: 'books', component: BookListComponent, canActivate: [authGuard] },
];
