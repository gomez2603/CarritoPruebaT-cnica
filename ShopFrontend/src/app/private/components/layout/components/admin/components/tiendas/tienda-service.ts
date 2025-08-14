import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../../../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { TiendaClass } from './tiendaClass';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TiendaService {
  private readonly _http = inject(HttpClient);
  private readonly _apiUrl = `${environment.apiUrl}/Tiendas`;

  state = signal({
    tiendas: new Map<number, TiendaClass>()
  })
  constructor(){
    this.getTiendas()
  }

  getFormattedTiendas() {
    return Array.from(this.state().tiendas.values())
  }
  getTiendas():void {
    this._http.get<TiendaClass[]>(this._apiUrl).subscribe((result) => {
      result.forEach((tienda) =>
        this.state().tiendas.set(tienda.id, tienda));
      this.state.set({ tiendas: this.state().tiendas })
    });

  }
 
  // POST: Crear proveedor y refrescar lista
  postTienda(dto: TiendaClass): Observable<TiendaClass> {
    const request = this._http.post<TiendaClass>(this._apiUrl, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }

  // PUT: Actualizar proveedor y refrescar lista
  updateTienda(dto: TiendaClass): Observable<TiendaClass> {
    const request = this._http.put<TiendaClass>(`${this._apiUrl}`, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }


  deleteTienda(id: number): Observable<void> {
    const request = this._http.delete<void>(`${this._apiUrl}/${id}`);
    request.subscribe(() => this.getTiendas());
    return request;
  }

}


