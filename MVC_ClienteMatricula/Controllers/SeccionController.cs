using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// 1° Usings que referencian a los servicios

using MVC_ClienteMatricula.ProxySecciones;
using MVC_ClienteMatricula.ProxyCursos;
using MVC_ClienteMatricula.ProxyProfesores;
using MVC_ClienteMatricula.ProxySedes;

namespace MVC_ClienteMatricula.Controllers
{
    public class SeccionController : Controller
    {
        // 2° Instanciamos los servicios

        ServicioSeccionesClient miServSecciones = new ServicioSeccionesClient();
        ServicioCursosClient miServCursos = new ServicioCursosClient();
        
        ServicioProfesoresClient miServProfesores = new ServicioProfesoresClient();

        ServicioSedesClient miServSedes = new ServicioSedesClient();    


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

        // Método para devolver la colección de Profesores (para Combo Box)

        public List<SelectListItem> ObtenerProfesores(String strProfesor)

        {
            List<SelectListItem> items = new SelectList(miServProfesores.ListarProfesor2(), "Cod_Pro", "NombreCompleto").ToList();

            // Insertar en la posicion 0, el item con texto: Seleccione Marca y valor 0

            items.Insert(0, (new SelectListItem { Text = "Seleccione Profesor", Value = "0" }));

            SelectListItem itemSel = new SelectListItem();

            itemSel = items.Where(x => x.Value == strProfesor).FirstOrDefault();

            itemSel.Selected = true;

            return items;

        }


        // Método para devolver la colección de Sedes (para Combo Box)

        public List<SelectListItem> ObtenerSedes(String strSede)

        {
            List<SelectListItem> items = new SelectList(miServSedes.ListarSedeConsulta(), "Cod_Sed", "Desc_Sed").ToList();

            // Insertar en la posicion 0, el item con texto: Seleccione Marca y valor 0

            items.Insert(0, (new SelectListItem { Text = "Seleccione Sede", Value = "0" }));

            SelectListItem itemSel = new SelectListItem();

            itemSel = items.Where(x => x.Value == strSede).FirstOrDefault();

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

            ViewBag.ListarProfesores = ObtenerProfesores("0");

            ViewBag.ListarSedes = ObtenerSedes("0");    

            return View();
        }


        // 5° Action Result para BÚSQUEDA

        public ActionResult Buscar(FormCollection fc)
        {
            // 5.1 Se toman los valores de los controles del formulario

            String strcriterioCurso = fc["cboCursos"];

            String strcriterioProfesor = fc["cboProfesores"];

            String strcriterioSede = fc["cboSedes"];

            String strCondicion = fc["condicion"];

            // 5.2 Si se elige el criterio de búsqueda "Por cursos", devuelve las secciones del curso seleccionado

            if (strCondicion.Equals("PorCurso"))
            {
                ViewBag.ListarSecciones = miServSecciones.ListarSeccionCurso(strcriterioCurso);

                ViewBag.ListarCursos = ObtenerCursos(strcriterioCurso);
                ViewBag.ListarProfesores = ObtenerProfesores("0");
                ViewBag.ListarSedes = ObtenerSedes("0");

                ViewBag.Cantidad = miServSecciones.ListarSeccionCurso(strcriterioCurso).Count();
            }             
            
            // 5.3 Si se elige el criterio de búsqueda "Por profesores", devuelve las secciones del profesor seleccionado


            else if (strCondicion.Equals("PorProfesor"))
            {
                ViewBag.ListarSecciones = miServSecciones.ListarSeccionProfesor(strcriterioProfesor);

                ViewBag.ListarCursos = ObtenerCursos("0");
                ViewBag.ListarProfesores = ObtenerProfesores(strcriterioProfesor);
                ViewBag.ListarSedes = ObtenerSedes("0");

                ViewBag.Cantidad = miServSecciones.ListarSeccionProfesor(strcriterioProfesor).Count();

            }

            // 5.4 Si se elige el criterio de búsqueda "Por Sedes", devuelve las secciones de la sede seleccionada

            else if (strCondicion.Equals("PorSede"))
            {
                ViewBag.ListarSecciones = miServSecciones.ListarSeccionSede(strcriterioSede);

                ViewBag.ListarCursos = ObtenerCursos("0");
                ViewBag.ListarProfesores = ObtenerProfesores("0");
                ViewBag.ListarSedes = ObtenerSedes(strcriterioSede);

                ViewBag.Cantidad = miServSecciones.ListarSeccionSede(strcriterioSede).Count();
            }

            // 5.5 Si no se elige criterio de búsqueda , devuelve todas las secciones disponibles

            else
            {
                ViewBag.ListarSecciones = miServSecciones.ListarSeccion2();

                ViewBag.ListarCursos = ObtenerCursos("0");
                ViewBag.ListarProfesores = ObtenerProfesores("0");
                ViewBag.ListarSedes = ObtenerSedes("0");

                ViewBag.Cantidad = miServSecciones.ListarSeccion2().Count();
            }

            return View("Index");
        }

    }
}