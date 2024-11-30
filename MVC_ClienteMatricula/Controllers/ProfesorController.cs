using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//agreamos

using MVC_ClienteMatricula.ProxyProfesores;
using MVC_ClienteMatricula.ProxyEspecialidades;
using MVC_ClienteMatricula.ProxyCursos;

namespace MVC_ClienteMatricula.Controllers
{
    public class ProfesorController : Controller
    {
        // 1° Instanciamos los servicios

        EspecialidadClient miServEspecialidades = new EspecialidadClient();

        ServicioProfesoresClient miServProfesores = new ServicioProfesoresClient();

        ServicioCursosClient miServCursos= new ServicioCursosClient();

        // Método para devolver la colección de Especialidades (para Combo Box)

        public List<SelectListItem> ObtenerEspecialidades(String strEspecialidad)

        {
            List<SelectListItem> items = new SelectList(miServEspecialidades.ListarEspecialidad(), "codEsp", "desEsp").ToList();

            // Insertar en la posicion 0, el item con texto: Seleccione Marca y valor 0

            items.Insert(0, (new SelectListItem { Text = "Seleccione Especialidad", Value = "0" }));

            SelectListItem itemSel = new SelectListItem();

            itemSel = items.Where(x => x.Value == strEspecialidad).FirstOrDefault();

            itemSel.Selected = true;

            return items;

        }

        // Método para devolver la colección de Cursos (para Combo Box)

        public List<SelectListItem> ObtenerCursos(String strCurso)

        {
            List<SelectListItem> items = new SelectList(miServCursos.ListarCurso2(), "Cod_cur", "Des_Cur").ToList();

            // Insertar en la posicion 0, el item con texto: Seleccione Marca y valor 0

            items.Insert(0, (new SelectListItem { Text = "Seleccione Curso", Value = "0" }));

            SelectListItem itemSel = new SelectListItem();

            itemSel = items.Where(x => x.Value == strCurso).FirstOrDefault();

            itemSel.Selected = true;

            return items;

        }

        public ActionResult Index()
        {
            ViewBag.ListarProfesores = miServProfesores.ListarProfesor2();
            ViewBag.Cantidad = miServProfesores.ListarProfesor2().Count();

            // Para el llenado de los dropdownlist en la vista

            ViewBag.ListarEspecialidades = ObtenerEspecialidades("0");
            ViewBag.ListarCursos = ObtenerCursos("0");

            return View();
        }

        public ActionResult Buscar(FormCollection fc)
        {
            String strcriterioEspecialidad = fc["cboEspecialidades"];

            String strcriterioColor = fc["cboCursos"];

            String strCondicion = fc["condicion"];

            if (strCondicion.Equals("PorEspecialidad"))
            {
                ViewBag.ListarProfesores = miServProfesores.ListarProfesorEspecialidad(strcriterioEspecialidad);
                ViewBag.ListarEspecialidades = ObtenerEspecialidades(strcriterioEspecialidad);
                ViewBag.ListarCursos = ObtenerCursos("0");

                ViewBag.Cantidad = miServProfesores.ListarProfesorEspecialidad(strcriterioEspecialidad).Count();
            }
            else if (strCondicion.Equals("PorCurso"))
            {
                ViewBag.ListarProfesores = miServProfesores.ListarProfesorCurso(strcriterioColor);
                ViewBag.ListarEspecialidades = ObtenerEspecialidades("0");
                ViewBag.ListarCursos = ObtenerCursos(strcriterioColor);

                ViewBag.Cantidad = miServProfesores.ListarProfesorCurso(strcriterioColor).Count();

            }
            else
            {
                ViewBag.ListarProfesores = miServProfesores.ListarProfesor2();
                ViewBag.ListarEspecialidades = ObtenerEspecialidades("0");
                ViewBag.ListarCursos = ObtenerCursos("0");

            }

            return View("Index");
        }
    }
}