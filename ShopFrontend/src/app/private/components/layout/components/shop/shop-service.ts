import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../../../../environments/environment';
import { articuloClass } from '../admin/components/articulos/articulosClass';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
    private readonly _http = inject(HttpClient);
  private readonly _apiUrl = `${environment.apiUrl}/Articulo`;

  state = signal({
    articulos: new Map<number, articuloClass>()
  })
  constructor(){
    this.getTArticulosByTienda(1)
  }

  getFormattedArticulosByTienda() {
    return Array.from(this.state().articulos.values())
  }


getTArticulosByTienda(id:number):void {
      this._http.get<articuloClass[]>(`http://localhost:4201/api/Tiendas/articulos/${id}`).subscribe((result) => {
        result.forEach((tienda) =>
          this.state().articulos.set(tienda.id, tienda));
        this.state.set({ articulos: this.state().articulos })
      });
    }
}
