using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaMaxima.Dominio.Entidades
{
    public class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
