
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWeb.Controllers
{
    public class AgendaController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;

        [Logueado]
        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.Agendas = _sistema.ListadoDeAgendasPorHuesped(HttpContext.Session.GetString("email"));

            return View();
        }
    }
}

