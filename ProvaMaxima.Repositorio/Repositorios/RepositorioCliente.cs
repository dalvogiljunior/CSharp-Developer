using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;
using ProvaMaxima.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaMaxima.Repositorio.Repositorios
{
    public class RepositorioCliente : BaseRepositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(MongoDbContexto mongoDbContexto) : base(mongoDbContexto)
        {
        }
    }
}
