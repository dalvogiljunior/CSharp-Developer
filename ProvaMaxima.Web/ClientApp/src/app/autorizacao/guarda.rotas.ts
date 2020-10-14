import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router'
import { UsuarioServico } from '../_servicos/usuario/usuario.servico';

@Injectable({
  providedIn: 'root'
})
export class GuardaRotas implements CanActivate {

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean/* | import("rxjs").Observable<boolean> | Promise<boolean> */ {

    if (this.usuarioServico.usuario_autenticado()) {
      return true;
    }
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }

}
