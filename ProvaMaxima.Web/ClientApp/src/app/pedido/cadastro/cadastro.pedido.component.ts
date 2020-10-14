import { Component, OnInit } from '@angular/core';
import { Pedido } from '../../_modelos/pedido';
import { PedidoServico } from '../../_servicos/pedido/pedido.servico';
import { map } from 'rxjs/operators';
import { ProdutoServico } from '../../_servicos/produto/produto.servico';
import { Produto } from '../../_modelos/produto';
import { Cliente } from '../../_modelos/cliente';
import { ClienteServico } from '../../_servicos/cliente/cliente.servico';
import { ItemPedido } from '../../_modelos/itemPedido';
import { forEach } from '@angular/router/src/utils/collection';
import { Router } from '@angular/router';

@Component({
  selector: 'cadastro-pedido',
  templateUrl: './cadastro.pedido.component.html',
  styleUrls: ['./cadastro.pedido.component.css']
})
export class CadastroPedidoComponent implements OnInit {
  public pedido: Pedido;
  public valorItens: number = 0;
  public valorFrete: number = 0;
  public clienteSelecionado: Cliente;
  public listaDeItensDePedido: ItemPedido[];
  public listaDeProdutos: Produto[];
  public listaDeClientes: Cliente[];
  codigoAtualCliente = '';
  codigoAtual = '';

  constructor(
    private pedidoServico: PedidoServico,
    private produtoServico: ProdutoServico,
    private clienteServico: ClienteServico,
    private router: Router) {

  }

  ngOnInit() {
    this.pedido = new Pedido();
    this.pedido.itensPedidos = []
    this.listaDeItensDePedido = this.pedido.itensPedidos;
    this.filtroProduto();
    this.filtroCliente();

    this.pedidoServico.obtenhaCodigoPedido().subscribe(cod => { this.pedido.codigo = cod})
  }

  selecaoDeProduto(chave: string) {
    var produto = this.filtre<Produto[]>(this.listaDeProdutos, chave)[0];
    console.log(produto);
    if (produto != null) {
      var itemPedido = new ItemPedido();
      itemPedido.produto = produto;
      itemPedido.quantidade = 1;

      this.listaDeItensDePedido.push(itemPedido);

      this.atualizeFreteETotal();
    }
  }

  selecaoDeCliente(chave: string) {
    this.clienteSelecionado = this.filtre<Cliente[]>(this.listaDeClientes, chave)[0];

    this.pedido.idCliente = this.clienteSelecionado.id;
  }

  filtroProduto() {
    this.produtoServico.obtenhaListaDeProdutos()
      .pipe<Produto[]>(map(lista => this.filtre<Produto[]>(lista, this.codigoAtual))).subscribe(resultado => {
        this.listaDeProdutos = resultado;
      });;
  }

  filtroCliente() {
    this.clienteSelecionado = null;
    this.clienteServico.obtenhaListaDeClientes()
      .pipe<Cliente[]>(map(lista => this.filtre<Cliente[]>(lista, this.codigoAtualCliente))).subscribe(resultado => {
        this.listaDeClientes = resultado;
      });
  }

  cadastrePedido() {
    this.pedidoServico.post(this.pedido).subscribe(result => {
      this.router.navigate(['/pedido']);
    });
  }

  limpeCarrinho() {
    this.listaDeItensDePedido = [];
    this.atualizeFreteETotal();
    
  }

  atualizeFreteETotal() {
    this.pedidoServico.obtenhaFrete(this.listaDeItensDePedido).subscribe(json => {
      this.valorFrete = json;
      this.pedido.valorDoFrete = this.valorFrete;
      });

    this.valorItens = 0;
    this.pedido.quantidadeTotalDeItens=0
    this.listaDeItensDePedido.forEach((item, index) => {
      this.valorItens += item.produto.precoUnitario * item.quantidade;
      this.pedido.quantidadeTotalDeItens += item.quantidade;
    })

    this.pedido.valorTotal = this.valorItens + this.valorFrete;
  }

  filtre<T>(valores, valorPesquisa): T {
    console.log(valores)
    return valores.filter(obj => (obj.codigo + " - " + obj.nome).toLowerCase().includes(valorPesquisa.toLowerCase()))
  }

}
