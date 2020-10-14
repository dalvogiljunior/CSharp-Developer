import { Injectable, inject, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../../_modelos/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteServico {
  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public obtenhaListaDeClientes(): Observable<Cliente[]> {

    return this.http.get<Cliente[]>(this._baseUrl + "api/cliente")
  }
}
