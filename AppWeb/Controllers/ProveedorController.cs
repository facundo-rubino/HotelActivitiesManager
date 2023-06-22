using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppWeb.Controllers
{
    [Logueado]
    [SoloOperador]
    public class ProveedorController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Proveedores = _sistema.ListaProveedoresOrdenada();
            return View();
        }

        [HttpPost]
        public IActionResult DescuentoXNumero(string numero, decimal descuento)
        {
            try
            {
                _sistema.ModificarPromocionProveedor(numero, descuento);
                ViewBag.Proveedores = _sistema.ListaProveedoresOrdenada();
                ViewBag.Mensaje = "Modificación exitosa";
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                ViewBag.Proveedores = _sistema.ListaProveedoresOrdenada();
            }

            return View("index");
        }
    }
}

