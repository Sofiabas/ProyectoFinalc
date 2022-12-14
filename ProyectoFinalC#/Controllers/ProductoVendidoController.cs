using Microsoft.AspNetCore.Mvc;
using ProyectoFinalC#.ADO.NET;
using ProyectoFinalC#.Models;
using System.Data.SqlClient;

namespace ProyectoFinalC#.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        private ProductoVendidoHandler handler = new ProductoVendidoHandler();

        [HttpGet]
        public ActionResult<List<ProductoVendido>> Get()
        {
            try
            {
                List<ProductoVendido> lista = handler.GetProductosVendidos();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}