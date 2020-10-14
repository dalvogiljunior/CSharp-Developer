import { ItemPedido } from "./itemPedido";

export class Pedido {
  public id: string;
  public codigo: number;
  public idCliente: string;
  public itensPedidos: ItemPedido[];
  public valorTotal: number;
  public valorDoFrete: number;
  public quantidadeTotalDeItens: number;
}
