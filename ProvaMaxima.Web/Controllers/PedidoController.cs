using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;

namespace ProvaMaxima.Web.Controllers
{
    public class PedidoController : BaseController<Pedido, IRepositorioPedido>
    {
        public PedidoController(IRepositorioPedido repositorioPedido) : base(repositorioPedido)
        {
        }

        [HttpPost("ObtenhaValorDoFrete")]
        public decimal ObtenhaValorDoFrete([FromBody] ItemPedido[] listaItens)
        {
            var numAleatorio = new Random().Next(5, 10);

            if (listaItens != null && listaItens.Count() > 0)
            {
                return (decimal)listaItens.Sum(x => x.Quantidade) * numAleatorio;
            }

            return 0;
        }

        [HttpGet("ObtenhaCodigoPedido")]
        public int ObtenhaCodigoPedido()
        {
            var listaDeTotal = _repositorio.ObtenhaTodos();

            if (listaDeTotal == null || listaDeTotal.Count() == 0)
                return 1;

            return listaDeTotal.Max(x=> x.Codigo) +1;
        }
    }
}
