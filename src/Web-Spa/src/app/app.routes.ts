import { Routes } from '@angular/router';
import { authRoutes } from './auth/auth-routing.module';
import { AuthComponent } from './auth/auth.component';
import { EcommerceLayoutComponent } from './ecommerce/ecommerce-layout.component';
import { ecommerceLayoutRoutes } from './ecommerce/ecommerce-layout-routing.module';


export const routes: Routes = [
  {
    path: '',
    component: EcommerceLayoutComponent,
    children: ecommerceLayoutRoutes
  },
  {
    path: 'auth',
    component: AuthComponent,
    children: authRoutes
  },
//   {
//     path: 'admin',
//     component: AdminComponent,
//     children: adminRoutes
//   },
  {
    path: '**',
    redirectTo: 'home'
  }
];