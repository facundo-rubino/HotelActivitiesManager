using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWeb.Controllers
{
    public class ActividadController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;


        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Actividad = _sistema.ListaActividadesDelDia();
            return View();
        }

        public IActionResult ActividadesPorFecha(DateTime fecha)
        {
            ViewBag.Actividad = _sistema.ListaActividadesPorFecha(fecha);
            return View("index");
        }
    }
}

