import { Component, computed, inject, Signal } from '@angular/core';
import { articuloClass } from '../admin/components/articulos/articulosClass';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CurrencyPipe } from '@angular/common';
import { TiendaService } from '../admin/components/tiendas/tienda-service';
import { TiendaClass } from '../admin/components/tiendas/tiendaClass';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { ShopService } from './shop-service';
import { MatIconModule } from '@angular/material/icon';
import { ShoppingCartService } from './shopping-cart-service';
import { MatBadgeModule } from '@angular/material/badge';
import { MatDialog } from '@angular/material/dialog';
import { ShoppingCart } from './components/shopping-cart/shopping-cart';
import { SaleService } from './sale-service';
@Component({
  selector: 'app-shop',
  imports: [MatCardModule, MatButtonModule, CurrencyPipe, MatSelectModule, MatIconModule, MatBadgeModule],
  templateUrl: './shop.html',
  styleUrl: './shop.css'
})
export class Shop {
  protected readonly articuloService = inject(ShopService);
  protected readonly saleService = inject(SaleService)
  protected readonly shoppingCartService = inject(ShoppingCartService)
  protected readonly tiendaService = inject(TiendaService);
  readonly dialog = inject(MatDialog);
  tiendasState: Signal<TiendaClass[]> = computed(() =>
    this.tiendaService.getFormattedTiendas()
  );
  articulosState: Signal<articuloClass[]> = computed(() =>
    this.articuloService.getFormattedArticulosByTienda()
  );

  cartCount: Signal<number> = computed(() =>
    this.shoppingCartService.cart$().length
  );



  onStoreChange($event: MatSelectChange<any>) {

    this.articuloService.getTArticulosByTienda($event.value)
    console.log(this.articulosState())
  }




  addToCart(articulo: articuloClass) {
    this.shoppingCartService.addToCart(articulo)
    console.log(this.shoppingCartService.getCartItems())
  }


  openDialog(): void {
    const dialogRef = this.dialog.open(ShoppingCart, {
      
    });

    dialogRef.afterClosed().subscribe((result: TiendaClass | undefined) => {
      console.log('The dialog was closed');
     
        const articuloIds: number[] = this.shoppingCartService.cart$().map(item => item.id);
        this.saleService.postSalesMultiple(articuloIds)
        this.shoppingCartService.clearCart();
      
      
    });
  }
}
