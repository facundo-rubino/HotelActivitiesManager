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

        [HttpGet]
        public IActionResult ActividadesPorFecha()
        {
            ViewBag.Actividad = _sistema.ListaActividadesPorFecha(DateTime.Today);
            ViewBag.Fecha = DateTime.Today;
            return View("index");
        }

        [HttpPost]
        public IActionResult ActividadesPorFecha(DateTime fecha)
        {
            try
            {
                ViewBag.Actividad = _sistema.ListaActividadesPorFecha(fecha);
                ViewBag.Fecha = fecha;
                return View("index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return RedirectToAction("ActividadesPorFecha");

            }

            return View("index");

        }
    }
}

