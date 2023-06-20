using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWeb.Controllers
{
    public class AgendaController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Agendas = _sistema.ObtenerListadoDeAgendas();
            return View();
        }

        //[HttpPost]
        //public IActionResult Index()
        //{
        //    try
        //    {
        //        ViewBag.Agendas = _sistema.ObtenerListadoDeAgendas();
        //        return View("index");
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.error = e.Message;
        //    }


        //    return View("index");
        //}
    }
}

