using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaMaxima.Dominio.Entidades
{
    public class Pedido: Entidade
    {
        public int Codigo { get; set; }
        public Guid IdCliente { get; set; }

        [BsonIgnore]
        public List<ItemPedido> ItensPedidos { get; set; }

        public int QuantidadeTotalDeItens { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDoFrete { get; set; }

        public override void Validate()
        {
            LimparMensagensDeValidacao();

            if (IdCliente == null)
                AdicionarMensagemDeValidacao("O Cliente deve ser informado.");

            if (ItensPedidos == null || !ItensPedidos.Any())
                AdicionarMensagemDeValidacao("Pedido não pode ficar sem itens.");
        }
    }
}
