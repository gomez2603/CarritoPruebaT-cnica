import { Component, computed, inject, Signal } from '@angular/core';
import { ArticulosService } from '../admin/components/articulos/articulos-service';
import { articuloClass } from '../admin/components/articulos/articulosClass';
import {MatCardModule} from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CurrencyPipe } from '@angular/common';
@Component({
  selector: 'app-shop',
  imports: [MatCardModule,MatButtonModule,CurrencyPipe],
  templateUrl: './shop.html',
  styleUrl: './shop.css'
})
export class Shop {
  protected readonly articuloService = inject(ArticulosService);
     articulosState: Signal<articuloClass[]> = computed(() =>
    this.articuloService.getFormattedTiendas()
  );
}
