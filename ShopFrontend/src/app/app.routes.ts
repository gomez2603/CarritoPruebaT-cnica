import { Routes } from '@angular/router';
import { authGuard } from './guards/auth-guard';
import { Layout } from './private/components/layout/layout';
import { Login } from './public/components/login/login';

export const routes: Routes = [
    {path:'',canActivate:[authGuard],component:Layout,
        children: [
            { path: '', loadChildren:() => import('./private/private.route').then(m=>m.routes) }, // Ruta por defecto
         
          ]

    },
    {path:'login',component:Login},

];
