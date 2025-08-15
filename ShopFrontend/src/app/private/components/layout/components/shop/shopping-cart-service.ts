import { Injectable, signal } from '@angular/core';
import { articuloClass } from '../admin/components/articulos/articulosClass';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  

  private _cart = signal<articuloClass[]>([]);


  cart$ = this._cart;


  addToCart(articulo: articuloClass): void {
    const current = this._cart();
    // Evitamos duplicados por ID (opcional)
    if (!current.find(a => a.id === articulo.id)) {
      this._cart.set([...current, articulo]);
    }
  }


  removeFromCart(articuloId: number): void {
    const current = this._cart();
    this._cart.set(current.filter(a => a.id !== articuloId));
  }

  clearCart(): void {
    this._cart.set([]);
  }

  getCartCount(): number {
    return this._cart().length;
  }

  getCartItems(): articuloClass[] {
    return this._cart();
  }
}
