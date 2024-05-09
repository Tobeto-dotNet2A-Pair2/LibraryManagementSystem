import { Routes } from '@angular/router';
import { HomepageComponent } from './shared/pages/homepage/homepage.component';
import { authGuard } from './core/guards/auth.guard';
import { AuthComponent } from './features/pages/auth/auth.component';
import { AdminLayoutComponent } from './shared/layouts/admin-layout/admin-layout.component';
import { DashboardComponent } from './features/pages/dashboard/dashboard.component';
import { MaterialListComponent } from './features/pages/materials/material-list/material-list.component';
import { MemberListComponent } from './features/pages/members/member-list/member-list.component';
import { BranchListComponent } from './features/pages/branches/branch-list/branch-list.component';
import { AddMaterialFormComponent } from './features/pages/materials/add-material-form/add-material-form.component';
import { roleGuard } from './core/guards/role.guard';
import { MainLayoutComponent } from './shared/layouts/main-layout/main-layout.component';
import { MemberProfileComponent } from './features/pages/members/member-profile/member-profile.component';
import { AddLibraryComponent } from './features/pages/library/add-libray/add-library/add-library.component';
import { AddBranchFormComponent } from './features/pages/branches/add-branch-form/add-branch-form.component';
import { ContactComponent } from './features/pages/contact/contact.component';
import { AboutUsComponent } from './features/pages/about-us/about-us.component';
import { QuestionComponent } from './features/pages/question/question.component';
import { MaterialDetailComponent } from './features/pages/materials/material-detail/material-detail.component';
import { MaterialDetailHomeComponent } from './features/pages/materials/material-detail-home/material-detail-home.component';
import { MaterialListHomeComponent } from './features/pages/materials/material-list-home/material-list-home.component';

export const routes: Routes = [
  
  { path: '', redirectTo: 'homepage', pathMatch: 'full' },
   { path: 'auth', component: AuthComponent },
   {path: 'homepage',
    component:MainLayoutComponent,
    children: [
      { path: '', component:HomepageComponent},
      { path: 'contact', component: ContactComponent },
      { path: 'aboutus', component: AboutUsComponent },
      { path: 'questions', component: QuestionComponent },
      { path: 'app-material-list-home', component: MaterialListHomeComponent },
      { path: 'material-detail-home/:id', component: MaterialDetailHomeComponent }


      


    ]
  },
  // { path: 'homepage', component: AdminLayoutComponent },

  // { path: 'adminpage', component: AdminLayoutComponent, canActivate: [authGuard] },
  {
    path: 'adminpage',
    component: AdminLayoutComponent,
    canActivate: [roleGuard],
    data:{requiredRoles:['Admin']},
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'material-lists', component: MaterialListComponent },
      { path: 'member-lists', component: MemberListComponent },
      { path: 'add-branches', component: AddBranchFormComponent },
      { path: 'branch-lists', component: BranchListComponent },
      { path: 'add-material-forms', component: AddMaterialFormComponent },
      { path: 'member-profile/:id', component: MemberProfileComponent },
      { path: 'material-detail/:id', component: MaterialDetailComponent },
      { path: 'add-library', component: AddLibraryComponent }
      
    ],
  },
];
