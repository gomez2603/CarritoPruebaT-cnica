import { Component } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { Tiendas } from "./components/tiendas/tiendas";

@Component({
  selector: 'app-admin',
  imports: [MatTabsModule, Tiendas],
  templateUrl: './admin.html',
  styleUrl: './admin.css'
})
export class Admin {

}
