import { Component, OnInit } from '@angular/core';
import { Usuario } from '../_modelos/Usuario';
import { Router, ActivatedRoute } from '@angular/router';
import { UsuarioServico } from '../_servicos/usuario/usuario.servico';
import { error } from 'util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  public usuario: Usuario;
  public mensagem: string;
  public returnUrl: string;

  constructor(
    private router: Router,
    private activetedRouter: ActivatedRoute,
    private usuarioServico: UsuarioServico) {
  }
  ngOnInit(): void {
    this.usuario = new Usuario();
    this.usuario.login = "talentosmaxima";
    this.usuario.senha = "talentosmaxima";
    this.returnUrl = this.activetedRouter.snapshot.queryParams['returnUrl'];
  }

  entrar() {

    this.usuarioServico.verificarUsuario(this.usuario)
      .subscribe(
        usuario_json => {

          this.usuarioServico.usuario = usuario_json;

          if (this.returnUrl == null) {
            this.returnUrl = '/';
          }

          this.router.navigate([this.returnUrl]);
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;
        }
    );
  }
}
