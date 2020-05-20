import { Routes, RouterModule } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { AuthGuard } from './components/account/login/auth.guard';

export const AppRoutes: Routes = [
  
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
    //canActivate: [AuthGuard],
  },
  
  {
    path: '',
    component: AdminLayoutComponent, canActivate: [AuthGuard],
    children: 
    [{
      path: '',
      loadChildren: './layouts/admin-layout/admin-layout.module#AdminLayoutModule'
    }],
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  {
    path: '**', redirectTo: ''
  }
];

