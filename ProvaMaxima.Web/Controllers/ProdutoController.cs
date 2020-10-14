using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;

namespace ProvaMaxima.Web.Controllers
{
    public class ProdutoController : BaseController<Produto, IRepositorioProduto>
    {
        public ProdutoController(IRepositorioProduto repositorioProduto):base(repositorioProduto)
        {
        }
    }
}
