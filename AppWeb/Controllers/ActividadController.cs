using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWeb.Controllers
{
    public class ActividadController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult ActividadesPorFecha()
        {


            if (HttpContext.Session.GetString("email") != null)
            {
                ViewBag.Actividad = _sistema.ListaFiltradaDeActividadesAgendadas(DateTime.Today, HttpContext.Session.GetString("email"));
                ViewBag.Fecha = DateTime.Today;
            }
            else
            {
                ViewBag.Actividad = _sistema.ListaActividadesPorFecha(DateTime.Today);
                ViewBag.Fecha = DateTime.Today;
            }

            return View("index");
        }

        [HttpPost]
        public IActionResult ActividadesPorFecha(DateTime fecha)
        {
            try
            {
                if (HttpContext.Session.GetString("email") != null)
                {
                    ViewBag.Actividad = _sistema.ListaFiltradaDeActividadesAgendadas(fecha, HttpContext.Session.GetString("email"));
                    ViewBag.Fecha = fecha;
                }
                else
                {
                    ViewBag.Actividad = _sistema.ListaActividadesPorFecha(fecha);
                    ViewBag.Fecha = fecha;
                }

                return View("index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return RedirectToAction("ActividadesPorFecha");

            }

            return View("index");

        }

        [HttpPost]
        public IActionResult CrearAgenda(int Id)
        {

            string emailHuesped = HttpContext.Session.GetString("email");

            _sistema.CrearAgenda(emailHuesped, Id);

            return RedirectToAction("Index", "Agenda");
        }


    }
}

