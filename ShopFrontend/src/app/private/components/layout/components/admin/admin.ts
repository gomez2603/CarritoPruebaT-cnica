import { Component } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { Tiendas } from "./components/tiendas/tiendas";
import { Articulos } from "./components/articulos/articulos";
import { Client } from "./components/client/client";
import { ArtTienda } from "./components/art-tienda/art-tienda";

@Component({
  selector: 'app-admin',
  imports: [MatTabsModule, Tiendas, Articulos, Client, ArtTienda],
  templateUrl: './admin.html',
  styleUrl: './admin.css'
})
export class Admin {

}
