import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatAutocompleteModule, MatInputModule } from '@angular/material';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProdutoComponent } from './produto/produto.component';
import { LoginComponent } from './login/login.component';
import { PedidoComponent } from './pedido/pedido.component';
import { CadastroPedidoComponent } from './pedido/cadastro/cadastro.pedido.component';
import { PesquisaProdutoComponent } from './produto/pesquisa/pesquisa.produto.component';

import { GuardaRotas } from './autorizacao/guarda.rotas';

import { UsuarioServico } from './_servicos/usuario/usuario.servico';
import { PedidoServico } from './_servicos/pedido/pedido.servico';
import { ProdutoServico } from './_servicos/produto/produto.servico';
import { ClienteServico } from './_servicos/cliente/cliente.servico';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProdutoComponent,
    LoginComponent,
    PedidoComponent,
    CadastroPedidoComponent,
    PesquisaProdutoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    MatAutocompleteModule,
    MatInputModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '', canActivate: [GuardaRotas], children:
          [
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'produto', component: ProdutoComponent },
            { path: 'pedido', component: PedidoComponent },
            { path: 'cadastro-pedido', component: CadastroPedidoComponent },
            { path: 'pesquisa-produto', component: PesquisaProdutoComponent}
          ]
      },
      { path: 'login', component: LoginComponent }
    ])
  ],
  providers: [
    UsuarioServico,
    PedidoServico,
    ProdutoServico,
    ClienteServico
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
