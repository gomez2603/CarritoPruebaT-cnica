import { Component, computed, inject, Signal } from '@angular/core';
import { MatDialogRef, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { ShoppingCartService } from '../../shopping-cart-service';
import { articuloClass } from '../../../admin/components/articulos/articulosClass';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-shopping-cart',
  imports: [MatDialogContent,MatTableModule,MatDialogActions,MatButtonModule],
  templateUrl: './shopping-cart.html',
  styleUrl: './shopping-cart.css'
})
export class ShoppingCart {
    readonly dialogRef = inject(MatDialogRef<ShoppingCart>);
    protected readonly shoppingCartService = inject(ShoppingCartService)
    displayedColumns: string[] = ['id', 'code', 'description','price','image'];
  cartItems: Signal<articuloClass[]> = computed(() =>
    this.shoppingCartService.cart$()
  );
  cartCount: Signal<number> = computed(() =>
    this.shoppingCartService.cart$().length
  );
Comprar() {
   
    this.dialogRef.close();
  }



 onNoClick(): void {
    this.dialogRef.close();
  }
  vaciarCarrito(){
    this.shoppingCartService.clearCart()
  }


}
