using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ClienteMatricula.ProxyEspecialidades;

namespace MVC_ClienteMatricula.Controllers
{
    public class EspecialidadController : Controller
    {
        // Crear instancia del servicio de Especialidades

        EspecialidadClient miServEspecialidades = new EspecialidadClient(); 
        public ActionResult Index()
        {
            ViewBag.ListarEspecialidades = miServEspecialidades.ListarEspecialidad();

            return View();
        }
    }
}