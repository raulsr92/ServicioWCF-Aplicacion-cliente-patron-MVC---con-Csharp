using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_ClienteMatricula.ProxyCursos;

namespace MVC_ClienteMatricula.Controllers
{
    public class CursoController : Controller
    {
        // Crear instancia del servicio de Cursos

        ServicioCursosClient miServCursos = new ServicioCursosClient(); 
        public ActionResult Index()
        {
            ViewBag.ListarCursos = miServCursos.ListarCurso2();
            return View();
        }
    }
}