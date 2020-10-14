using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;

namespace ProvaMaxima.Web.Controllers
{
    [Route("api/[Controller]")]
    public abstract class BaseController<T, Repositorio> : Controller 
        where T : Entidade 
        where Repositorio : IBaseRepositorio<T>
    {
        protected readonly Repositorio _repositorio;
        public BaseController(Repositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                return Json(_repositorio.ObtenhaTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] T entidade)
        {
            try
            {
                _repositorio.Adicionar(entidade);

                return Ok(entidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
