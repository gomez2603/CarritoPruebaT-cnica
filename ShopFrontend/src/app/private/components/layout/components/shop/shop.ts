import { Component, computed, inject, Signal } from '@angular/core';
import { ArticulosService } from '../admin/components/articulos/articulos-service';
import { articuloClass } from '../admin/components/articulos/articulosClass';
import {MatCardModule} from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CurrencyPipe } from '@angular/common';
import { TiendaService } from '../admin/components/tiendas/tienda-service';
import { TiendaClass } from '../admin/components/tiendas/tiendaClass';
import {MatSelectChange, MatSelectModule} from '@angular/material/select';
import { ShopService } from './shop-service';
@Component({
  selector: 'app-shop',
  imports: [MatCardModule,MatButtonModule,CurrencyPipe,MatSelectModule],
  templateUrl: './shop.html',
  styleUrl: './shop.css'
})
export class Shop {
  protected readonly articuloService = inject(ShopService);
  
onStoreChange($event: MatSelectChange<any>) {

  this.articuloService.getTArticulosByTienda($event.value)
   this.articuloService.getFormattedArticulosByTienda()
}

  protected readonly tiendaService = inject(TiendaService);
     tiendasState: Signal<TiendaClass[]> = computed(() =>
      this.tiendaService.getFormattedTiendas()
    );

     articulosState: Signal<articuloClass[]> = computed(() =>
    this.articuloService.getFormattedArticulosByTienda()
  );
}
