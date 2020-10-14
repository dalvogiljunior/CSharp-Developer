import { Injectable, inject, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../../_modelos/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoServico {
  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public obtenhaListaDeProdutos(): Observable<Produto[]> {

    return this.http.get<Produto[]>(this._baseUrl + "api/produto")
  }
}
