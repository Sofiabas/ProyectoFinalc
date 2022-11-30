using Microsoft.AspNetCore.Mvc;
using ProyectoFinalC#.ADO.NET;
using ProyectoFinalC#.Models;
using System.Data.SqlClient;

namespace ProyectoFinalC#.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioHandler handler = new UsuarioHandler();

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            try
            {
                List<Usuario> lista = handler.GetUsuario();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}