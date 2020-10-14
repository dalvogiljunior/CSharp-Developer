import { Component, OnInit } from '@angular/core';
import { Pedido } from '../_modelos/pedido';
import { PedidoServico } from '../_servicos/pedido/pedido.servico';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent implements OnInit {
  public listaDePedidos: Pedido[];

  constructor(private pedidoServico: PedidoServico) {

  }

  ngOnInit() {
    this.getPedidos();
  }

  getPedidos() {
    this.pedidoServico.obtenhaListaDePedidos().subscribe(
      listaPedidos_json => {
        console.log(listaPedidos_json);
      this.listaDePedidos = listaPedidos_json;
    }, error => {
      console.log(error);
    });
  }
}
