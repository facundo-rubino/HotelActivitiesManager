
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

    [Logueado]

    public class AgendaController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]

        public IActionResult AgendasPorFecha(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.Huespedes = _sistema.HuespedConAgendas();


            if (HttpContext.Session.GetString("rol") == "huesped")
                ViewBag.Agendas = _sistema.ListadoDeAgendasPorHuesped(HttpContext.Session.GetString("email"));
            else
                ViewBag.Agendas = _sistema.AgendasPorFecha(DateTime.Today);

            return View("index");
        }

        [SoloOperador]
        [HttpPost]
        public IActionResult AgendasPorFecha(DateTime fecha)
        {
            ViewBag.Fecha = fecha;
            ViewBag.Huespedes = _sistema.HuespedConAgendas();
            try
            {
                ViewBag.Agendas = _sistema.AgendasPorFecha(fecha);
                return View("index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return RedirectToAction("ActividadesPorFecha", new { error = $"No hay agendas para la fecha: {fecha.ToString("d")} " });

            }

            return View("index");


        }

    }
}

