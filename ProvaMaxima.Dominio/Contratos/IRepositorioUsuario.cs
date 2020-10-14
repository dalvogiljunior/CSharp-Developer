using ProvaMaxima.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProvaMaxima.Dominio.Contratos
{
    public interface IRepositorioUsuario : IBaseRepositorio<Usuario>
    {
        Usuario ObtenhaUsuarioPorLoginESenha(Usuario usuario);
    }
}
