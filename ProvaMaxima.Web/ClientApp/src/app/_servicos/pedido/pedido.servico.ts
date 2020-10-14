import { Injectable, inject, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from '../../_modelos/pedido';
import { ItemPedido } from '../../_modelos/itemPedido';

@Injectable({
  providedIn: 'root'
})
export class PedidoServico {
  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public obtenhaListaDePedidos(): Observable<Pedido[]> {

    return this.http.get<Pedido[]>(this._baseUrl + "api/pedido")
  }

  public obtenhaCodigoPedido(): Observable<number> {

    return this.http.get<number>(this._baseUrl + "api/pedido/ObtenhaCodigoPedido");
  }

  public obtenhaFrete(listaItens: ItemPedido[]): Observable<number> {
    var headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<number>(this._baseUrl + "api/pedido/obtenhaValorDoFrete", JSON.stringify(listaItens), { headers });
  }

  public post(pedido: Pedido): Observable<Pedido> {
    var headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<Pedido>(this._baseUrl + "api/pedido", JSON.stringify(pedido), { headers });
  }
}
