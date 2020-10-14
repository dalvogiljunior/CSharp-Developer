using ProvaMaxima.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProvaMaxima.Dominio.Contratos
{
    public interface IBaseRepositorio<T> where T : Entidade
    {
        void Adicionar(T obj);
        T ObtenhaPorId(Guid id);
        IEnumerable<T> ObtenhaTodos();
        void Atualizar(T obj);
        void Remover(T obj);
    }
}
