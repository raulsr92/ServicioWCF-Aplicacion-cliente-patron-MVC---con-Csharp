using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ClienteMatricula.ProxyEspecialidades;

// 1° Referenciar al servicio sedes
using MVC_ClienteMatricula.ProxySedes;

namespace MVC_ClienteMatricula.Controllers
{
    public class SedeController : Controller
    {
        // 2° Crear instancia del servicio de SEDES

        ServicioSedesClient miServSedes = new ServicioSedesClient();

        public ActionResult Index()
        {
            // 3° Devolver las sedes a traves de un ViewBag

            ViewBag.ListarSedes = miServSedes.ListarSedeConsulta();

            return View();
        }
    }
}