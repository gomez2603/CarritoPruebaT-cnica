import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { shoppingClass } from '../shopping/shoppingClass';

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  private readonly _apiUrl = `${environment.apiUrl}/Sales`;
  private readonly _http = inject(HttpClient);
 state = signal({
    articulos: new Map<number, shoppingClass>()
  })
  constructor(){
    this.getTArticulosByClient()
  }

  
getFormattedArticulosByClient() {
    return Array.from(this.state().articulos.values())
  }
  postSalesMultiple(ids:number[]){
    this._http.post( `${this._apiUrl}/multiple`,ids).subscribe(() => this.getTArticulosByClient());
  }


  getTArticulosByClient() {
    this._http.get<shoppingClass[]>(`${this._apiUrl}/byClient`)
      .subscribe((result) => {
          result.forEach((artTienda) =>
        this.state().articulos.set(artTienda.saleId, artTienda));
      this.state.set({ articulos: this.state().articulos })
      });
  }
}

  
