import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ArtTiendaServices {
    private readonly _http = inject(HttpClient);
  private readonly _apiUrl = `${environment.apiUrl}/ArtTienda`;

  state = signal({
    tiendas: new Map<number, artTiendaClass>()
  })
  constructor(){
    this.getTiendas()
  }

  getFormattedTiendas() {
    return Array.from(this.state().tiendas.values())
  }
  getTiendas():void {
    this._http.get<artTiendaClass[]>(this._apiUrl).subscribe((result) => {
      result.forEach((artTienda) =>
        this.state().tiendas.set(artTienda.id, artTienda));
      this.state.set({ tiendas: this.state().tiendas })
    });

  }
 
  // POST: Crear proveedor y refrescar lista
  postTienda(dto: artTiendaClass): Observable<artTiendaClass> {
    const request = this._http.post<artTiendaClass>(this._apiUrl, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }

  // PUT: Actualizar proveedor y refrescar lista
  updateTienda(dto: artTiendaClass): Observable<artTiendaClass> {
    const request = this._http.put<artTiendaClass>(`${this._apiUrl}`, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }


  deleteTienda(id: number): Observable<void> {
    const request = this._http.delete<void>(`${this._apiUrl}/${id}`);
    request.subscribe(() => this.getTiendas());
    return request;
  }

}
