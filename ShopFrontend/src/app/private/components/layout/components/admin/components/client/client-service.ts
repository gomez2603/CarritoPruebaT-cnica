import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private readonly _http = inject(HttpClient);
  private readonly _apiUrl = `${environment.apiUrl}/Auth`;

  state = signal({
    clients: new Map<number, clientClass>()
  })
  constructor(){
    this.getTiendas()
  }

  getFormattedTiendas() {
    return Array.from(this.state().clients.values())
  }
  getTiendas():void {
    this._http.get<clientClass[]>(this._apiUrl).subscribe((result) => {
      result.forEach((client) =>
        this.state().clients.set(client.id, client));
      this.state.set({ clients: this.state().clients })
    });

  }
 
  // POST: Crear proveedor y refrescar lista
  postTienda(dto: clientClass): Observable<clientClass> {
    const request = this._http.post<clientClass>(`${this._apiUrl}/Register`, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }

  // PUT: Actualizar proveedor y refrescar lista
  updateTienda(dto: clientClass): Observable<clientClass> {
    const request = this._http.put<clientClass>(`${this._apiUrl}`, dto);
    request.subscribe(() => this.getTiendas());
    return request;
  }


  deleteTienda(id: number): Observable<void> {
    const request = this._http.delete<void>(`${this._apiUrl}/${id}`);
    request.subscribe(() => this.getTiendas());
    return request;
  }

}
