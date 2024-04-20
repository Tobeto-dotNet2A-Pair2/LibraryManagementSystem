import { Routes } from '@angular/router';
import { HomepageComponent } from './shared/pages/homepage/homepage.component';
import { authGuard } from './core/guards/auth.guard';
import { AuthComponent } from './features/pages/auth/auth.component';
import { AdminLayoutComponent } from './shared/layouts/admin-layout/admin-layout.component';
import { DashboardComponent } from './features/pages/dashboard/dashboard.component';
import { MaterialListComponent } from './features/pages/materials/material-list/material-list.component';
import { MemberListComponent } from './features/pages/members/member-list/member-list.component';
import { AddBranchFormComponent } from './features/pages/branches/add-branch-form/add-branch-form.component';
import { BranchListComponent } from './features/pages/branches/branch-list/branch-list.component';

export const routes: Routes = [
  { path: '', redirectTo: 'adminpage', pathMatch: 'full' },
  // { path: 'homepage', component: HomepageComponent },
  // { path: 'homepage', component: AdminLayoutComponent },

  // { path: 'adminpage', component: AdminLayoutComponent, canActivate: [authGuard] },
  { 
    path: 'adminpage',
    component: AdminLayoutComponent,
    // canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      {path: 'material-lists', component:MaterialListComponent },
      {path: 'members', component:MemberListComponent},
      {path: 'add-branches', component:AddBranchFormComponent},
      {path:'branch-lists', component:BranchListComponent},
    ]
  }
];
