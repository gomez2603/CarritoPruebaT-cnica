import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../../../../environments/environment';
import { articuloClass } from '../admin/components/articulos/articulosClass';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
    private readonly _http = inject(HttpClient);
   private readonly _apiUrl = `${environment.apiUrl}/Tiendas`;

  state = signal({
    articulos: new Map<number, articuloClass>()
  })
  constructor(){
    this.getTArticulosByTienda(1)
  }

  getFormattedArticulosByTienda() {
    return Array.from(this.state().articulos.values())
  }


getTArticulosByTienda(id: number): void {
  this._http.get<articuloClass[]>(`${this._apiUrl}/articulos/${id}`)
    .subscribe((result) => {
      const nuevosArticulos = new Map<number, articuloClass>();
      result.forEach((articulo) => nuevosArticulos.set(articulo.id, articulo));
      this.state.set({ articulos: nuevosArticulos });
    });
}
}
