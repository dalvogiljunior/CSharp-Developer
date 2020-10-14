import { Component, OnInit, Input } from '@angular/core'
import { Produto } from '../../_modelos/produto'
import { ProdutoServico } from '../../_servicos/produto/produto.servico';
import {  map } from 'rxjs/operators';

@Component({
  selector: "pesquisa-produto",
  templateUrl: "./pesquisa.produto.component.html",
  styleUrls: ["./pesquisa.produto.component.css"]
})

export class PesquisaProdutoComponent {
  public listaDeProdutos;
  codigoAtual='';

  constructor(private produtoServico: ProdutoServico) {
  }

  doFilter() {
    this.listaDeProdutos = this.produtoServico.obtenhaListaDeProdutos()
      .pipe<Produto[]>(map(lista => this.filtre(lista)));
  }

  filtre(valores) {
    console.log(valores)
    return valores.filter(produto => produto.codigo.toLowerCase().includes(this.codigoAtual))
  }
}
