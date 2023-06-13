using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            ViewBag.Proveedores = _sistema.ListaProveedoresOrdenada();

            return View("index");
        }
    }
}

