using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// 1° Usings que referencian a los servicios

using MVC_ClienteMatricula.ProxySecciones;
using MVC_ClienteMatricula.ProxyCursos;

namespace MVC_ClienteMatricula.Controllers
{
    public class SeccionController : Controller
    {
        // 2° Instanciamos los servicios

        ServicioSeccionesClient miServSecciones = new ServicioSeccionesClient();
        ServicioCursosClient miServCursos = new ServicioCursosClient();


        // 3° Métodos para llenar los COMBO BOX 

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


        // 4° Action Result INDEX

        public ActionResult Index()
        {
            ViewBag.ListarSecciones = miServSecciones.ListarSeccion2();

            ViewBag.Cantidad = miServSecciones.ListarSeccion2().Count();

            // Para el llenado de los dropdownlist en la vista

            ViewBag.ListarCursos = ObtenerCursos("0");

            return View();
        }

        // 5° Action Result para BÚSQUEDA

        public ActionResult Buscar(FormCollection fc)
        {
            // 5.1 Se toman los valores de los controles del formulario

            String strcriterioCurso = fc["cboCursos"];

            String strCondicion = fc["condicion"];

            // 5.2 Si se elige el criterio de búsqueda "Por cursos", devuelve las secciones del curso seleccionado

            if (strCondicion.Equals("PorCurso"))
            {
                ViewBag.ListarSecciones = miServSecciones.ListarSeccionCurso(strcriterioCurso);
                ViewBag.ListarCursos = ObtenerCursos(strcriterioCurso);

                ViewBag.Cantidad = miServSecciones.ListarSeccionCurso(strcriterioCurso).Count();
            }
            // 5.3 Si no se elige criterio de búsqueda , devuelve todas las secciones disponibles

            else
            {
                ViewBag.ListarSecciones = miServSecciones.ListarSeccion2();
                ViewBag.ListarCursos = ObtenerCursos("0");
            }

            return View("Index");
        }

    }
}