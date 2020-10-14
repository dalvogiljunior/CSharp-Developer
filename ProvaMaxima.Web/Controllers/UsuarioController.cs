using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;

namespace ProvaMaxima.Web.Controllers
{
    public class UsuarioController : BaseController<Usuario, IRepositorioUsuario>
    {
        public UsuarioController(IRepositorioUsuario repositorioUsuario) : base(repositorioUsuario)
        {
        }

        [HttpPost("VerifiqueUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuariPersistido = _repositorio.ObtenhaUsuarioPorLoginESenha(usuario);

                if (usuariPersistido != null)
                    return Ok(usuariPersistido);

                return BadRequest("Usuário ou senha não incorreto.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
