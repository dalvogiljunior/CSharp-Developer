import { Injectable, inject, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Http } from '@angular/http';
import { Usuario } from '../../_modelos/Usuario';

@Injectable({
 providedIn:'root'
})
export class UsuarioServico {
  private baseUrl: string;
  private _usuario: Usuario;

  set usuario(usuario:Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
    this._usuario = usuario;
  }

  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem("usuario-autenticado");
    this._usuario = JSON.parse(usuario_json);
    return this._usuario;
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public usuario_autenticado(): boolean {
    return this._usuario != null;
  }

  public limpar_sessao() {
    this._usuario = null;
    sessionStorage.removeItem('usuario-autenticado');
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      login:usuario.login,
      senha:usuario.senha
    }

    return this.http.post<Usuario>(this.baseUrl + "api/usuario/verifiqueusuario", body, { headers });
  }
}
