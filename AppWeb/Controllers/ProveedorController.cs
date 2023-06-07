using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWeb.Controllers
{
    public class ProveedorController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Proveedores = _sistema.ListaProveedoresOrdenada();
            return View();
        }

        [HttpPost]
        public IActionResult DescuentoXNumero(string numero, decimal descuento)
        {

            _sistema.ModificarPromocionProveedor(numero, descuento);

            return Json(new { numero });
        }

        public ActionResult actualizacionTabla(string identificador)
        {
            // Retrieve the data for the specified uniqueIdentifier
            // and return a partial view with the data

            ViewBag.Id = identificador;

            return PartialView("actualizacionTabla");
        }



    }
}

