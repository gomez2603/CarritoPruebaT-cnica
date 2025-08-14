
import { Routes } from "@angular/router";
import { roleguardGuard } from "../guards/role-guard";

export const routes: Routes = [
    {path:'',loadComponent: () => import('./components/layout/components/shop/shop').then(m=>m.Shop)},
    {path:'admin',canActivate: [roleguardGuard(['ADMIN','CLIENT'])],loadComponent:()=>import('./components/layout/components/admin/admin').then(m=>m.Admin)}
];
export default routes