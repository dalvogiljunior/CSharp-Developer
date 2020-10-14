using MongoDB.Driver;
using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;
using ProvaMaxima.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaMaxima.Repositorio.Repositorios
{
    public class RepositorioPedido : BaseRepositorio<Pedido>, IRepositorioPedido
    {
        public RepositorioPedido(MongoDbContexto mongoDbContexto) : base(mongoDbContexto)
        {
        }
    }
}
