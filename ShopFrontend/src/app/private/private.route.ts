
import { Routes } from "@angular/router";
import { roleguardGuard } from "../guards/role-guard";
import { Shopping } from "./components/layout/components/shopping/shopping";

export const routes: Routes = [
    { path: '', loadComponent: () => import('./components/layout/components/shop/shop').then(m => m.Shop) },
    { path: 'admin', canActivate: [roleguardGuard(['ADMIN'])], loadComponent: () => import('./components/layout/components/admin/admin').then(m => m.Admin) },
    { path: 'compras', canActivate: [roleguardGuard(['ADMIN', 'CLIENT'])], loadComponent: () => import('./components/layout/components/shopping/shopping').then(m => m.Shopping) },
];
export default routes