import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../../../../../environments/environment';
import { articuloClass } from './articulosClass';

@Injectable({
  providedIn: 'root' 
})
export class ArticulosService {
  private readonly _http = inject(HttpClient);
  private readonly _apiUrl = `${environment.apiUrl}/Articulo`;

  state = signal({
    articulos: new Map<number, articuloClass>()
  })
  constructor(){
    this.getTiendas()
  }

  getFormattedTiendas() {
    return Array.from(this.state().articulos.values())
  }
  getTiendas():void {
    this._http.get<articuloClass[]>(this._apiUrl).subscribe((result) => {
      result.forEach((tienda) =>
        this.state().articulos.set(tienda.id, tienda));
      this.state.set({ articulos: this.state().articulos })
    });

  }
 
  // POST: Crear proveedor y refrescar lista
  postTienda(dto: FormData): Observable<articuloClass> {
    const request = this._http.post<articuloClass>(this._apiUrl, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }

  // PUT: Actualizar proveedor y refrescar lista
  updateTienda(dto: FormData): Observable<articuloClass> {
    const request = this._http.put<articuloClass>(`${this._apiUrl}`, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }


  deleteTienda(id: number): Observable<void> {
    const request = this._http.delete<void>(`${this._apiUrl}/${id}`);
    request.subscribe(() => this.getTiendas());
    return request;
  }

}
