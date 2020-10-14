using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;
using ProvaMaxima.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaMaxima.Repositorio.Repositorios
{
    public class RepositorioProduto : BaseRepositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(MongoDbContexto mongoDbContexto) : base(mongoDbContexto)
        {
        }
    }
}
