import { Routes } from '@angular/router';
import { authRoutes } from './auth/auth-routing.module';
import { AuthComponent } from './auth/auth.component';


export const routes: Routes = [
    {
        path: '',
        redirectTo: 'auth/login',
        pathMatch: 'full'
    },
    {
        path: 'auth',
        component: AuthComponent,
        children: authRoutes
    },
    {
        path: '**',
        redirectTo: 'auth/login'
    }
    
];
