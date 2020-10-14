using MongoDB.Driver;
using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;
using ProvaMaxima.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaMaxima.Repositorio.Repositorios
{
    public class RepositorioUsuario : BaseRepositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(MongoDbContexto mongoDbContexto) : base(mongoDbContexto)
        {
        }

        public Usuario ObtenhaUsuarioPorLoginESenha(Usuario usuario)
        {
            if (usuario != null)
            {
                return ColecaoDoObjeto.Find(x => x.Login == usuario.Login && x.Senha == usuario.Senha).FirstOrDefault();
            }

            return null;
        }
    }
}
