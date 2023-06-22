
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

namespace AppWeb.Controllers
{

    [Logueado]

    public class AgendaController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult AgendasPorFecha(string error, string mensaje)
        {
            ViewBag.Error = error;
            ViewBag.Mensaje = mensaje;
            ViewBag.Huespedes = _sistema.HuespedConAgendas();

            try
            {
                if (HttpContext.Session.GetString("rol") == "huesped")
                    ViewBag.Agendas = _sistema.ListadoDeAgendasPorHuesped(HttpContext.Session.GetString("email"));
                else
                    ViewBag.Agendas = _sistema.AgendasPorFecha(DateTime.Today);

                return View("index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View("index");
            }
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
                return RedirectToAction("AgendasPorFecha", new { error = $"No hay agendas para la fecha: {fecha.ToString("d")} " });

            }
        }

        [SoloOperador]
        [HttpPost]
        public IActionResult AgendasPorHuesped(string email)
        {
            try
            {
                ViewBag.Agendas = _sistema.AgendasPorHuesped(email);
                ViewBag.Huespedes = _sistema.HuespedConAgendas();

                return View("index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                ViewBag.Huespedes = _sistema.HuespedConAgendas();
                return RedirectToAction("AgendasPorFecha");
            }
        }

        public IActionResult CambiarEstado(int Id)
        {
            _sistema.CambiarEstadoAgenda(Id);
            return RedirectToAction("AgendasPorFecha", new { mensaje = "Estado cambiado exitosamente" });
        }

    }
}

