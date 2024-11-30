using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioProfesores" en el código y en el archivo de configuración a la vez.
    public class ServicioProfesores : IServicioProfesores
    {
        public Boolean ActualizarProfesor(ProfesorDC objProfesorDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                Boolean boolActualizar = false;
                //***********************************************************//

                MisMatriculas.usp_ActualizarProfesor(
                        objProfesorDC.Cod_Pro,
                        objProfesorDC.Nom_Pro,
                        objProfesorDC.Ape_Pro,
                        objProfesorDC.Foto_Pro,
                        objProfesorDC.Direccion_Pro,
                        objProfesorDC.Email_Pro,
                        Convert.ToDateTime(objProfesorDC.Fec_Nac_Pro),
                        objProfesorDC.DNI_Pro,
                        objProfesorDC.Cod_Espec,
                        objProfesorDC.Id_Ubigeo,
                        objProfesorDC.Usu_Reg,
                        Convert.ToBoolean(objProfesorDC.Est_Pro)

                    );

                MisMatriculas.SaveChanges();

                boolActualizar = true;

                //***********************************************************//
                //retornamos la coleccion
                return boolActualizar;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean EliminarProfesor(string strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                Boolean boolEliminar = false;
                //***********************************************************//

                MisMatriculas.usp_EliminarProfesor(strCodigo);

                MisMatriculas.SaveChanges();

                boolEliminar = true;

                //***********************************************************//
                //retornamos la coleccion
                return boolEliminar;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean InsertarProfesor(ProfesorDC objProfesorDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                Boolean boolInsertar = false;
                //***********************************************************//

                MisMatriculas.usp_InsertarProfesor(
                        objProfesorDC.Nom_Pro,
                        objProfesorDC.Ape_Pro,
                        objProfesorDC.Foto_Pro,
                        objProfesorDC.Direccion_Pro,
                        objProfesorDC.Email_Pro,
                        Convert.ToDateTime(objProfesorDC.Fec_Nac_Pro),
                        objProfesorDC.DNI_Pro,
                        objProfesorDC.Cod_Espec,
                        objProfesorDC.Id_Ubigeo,
                        objProfesorDC.Usu_Reg,
                        Convert.ToBoolean(objProfesorDC.Est_Pro)
                 );

                MisMatriculas.SaveChanges();

                boolInsertar = true; 

                //***********************************************************//
                //retornamos la coleccion
                return boolInsertar;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ProfesorDC ConsultarProfesor(string strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                ProfesorDC objProfesorDC = new ProfesorDC();
                //***********************************************************//
                //Obtener la información del profesor en consulta

                var query = MisMatriculas.usp_ConsultarProfesor(strCodigo).FirstOrDefault();

                if(query != null)
                {
                    objProfesorDC.Cod_Pro = query.Cod_Pro;
                    objProfesorDC.Nom_Pro = query.Nom_Pro;
                    objProfesorDC.Ape_Pro = query.Ape_Pro;
                    objProfesorDC.Direccion_Pro = query.direccion_Pro;
                    objProfesorDC.Email_Pro = query.email_Pro;
                    objProfesorDC.Fec_Nac_Pro = Convert.ToDateTime(query.Fec_Nac_Pro);
                    objProfesorDC.DNI_Pro = query.DNI_Pro;
                    objProfesorDC.Especialidad = query.Des_Esp;
                    objProfesorDC.Departamento = query.Departamento;
                    objProfesorDC.Provincia = query.Provincia;
                    objProfesorDC.Distrito =  query.Distrito;
                    objProfesorDC.Est_Pro = Convert.ToInt32(query.Est_Pro);

                }
                else
                {
                    objProfesorDC.Cod_Pro = String.Empty;
                }

                //***********************************************************//
                //retornamos el objeto Profesor DC

                return objProfesorDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ProfesorDC> ListarProfesor()
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<ProfesorDC> objListaProfesorDC = new List<ProfesorDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ListarProfesor();

                foreach (var profesor in query) {

                    ProfesorDC objProfesorDC = new ProfesorDC();

                    objProfesorDC.Cod_Pro = profesor.Cod_Pro;
                    objProfesorDC.Nom_Pro = profesor.Nom_Pro;
                    objProfesorDC.Ape_Pro = profesor.Ape_Pro;
                    objProfesorDC.Direccion_Pro = profesor.direccion_Pro;
                    objProfesorDC.Email_Pro = profesor.email_Pro;
                    objProfesorDC.Fec_Nac_Pro = Convert.ToDateTime(profesor.Fec_Nac_Pro);
                    objProfesorDC.DNI_Pro = profesor.DNI_Pro;
                    objProfesorDC.Especialidad = profesor.Des_Esp;
                    objProfesorDC.Departamento = profesor.Departamento;
                    objProfesorDC.Provincia = profesor.Provincia;
                    objProfesorDC.Distrito = profesor.Distrito;
                    objProfesorDC.Est_Pro = Convert.ToInt32(profesor.Est_Pro);

                    objListaProfesorDC.Add(objProfesorDC);
                }

                //***********************************************************//
                //retornamos la coleccion
                return objListaProfesorDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Operaciones de consulta de negocio

        public List<ProfesorDC> ListarProfesor2()
        {
            try
            {
                // Instanciar el modelo

                DBMatricula2Entities misProfesores = new DBMatricula2Entities();

                // creamos la lista para retornas

                List<ProfesorDC> listaProfesor = new List<ProfesorDC>();

                // Obtener la lista de profesores (ordenada por apellido)

                var query = misProfesores.Tb_Profesores.OrderBy(miProfe => miProfe.Ape_Pro);

                foreach (var resultado in query)
                {
                    ProfesorDC objProfesor = new ProfesorDC();

                    objProfesor.Cod_Pro = resultado.Cod_Pro;
                    objProfesor.NombreCompleto = resultado.Nom_Pro + " " + resultado.Ape_Pro;
                    objProfesor.Especialidad = resultado.Tb_Especialidad.Des_Esp;
                    objProfesor.Email_Pro = resultado.email_Pro;
                    objProfesor.Direccion_Pro = resultado.direccion_Pro + " - " +
                                                resultado.Tb_Ubigeo.Distrito + " - "+
                                                resultado.Tb_Ubigeo.Provincia + " - " + 
                                                resultado.Tb_Ubigeo.Departamento;

                    objProfesor.Numero_secciones = Convert.ToInt16(resultado.Tb_Seccion.Count());


                    listaProfesor.Add(objProfesor);
                }
                return listaProfesor;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<ProfesorDC> ListarProfesorEspecialidad(string strCodEspecialidad)
        {
            try
            {
                // Instanciar el modelo

                DBMatricula2Entities misProfesores = new DBMatricula2Entities();

                // creamos la lista para retornas

                List<ProfesorDC> listaProfesor = new List<ProfesorDC>();

                // Obtener la lista de profesores (ordenada por apellido) por ESPECIALIDAD

                var query = misProfesores.Tb_Profesores.OrderBy(miProfe => miProfe.Ape_Pro)
                                                       .Where(miProfe => miProfe.Cod_Espec ==                                                                   strCodEspecialidad).ToList();

                foreach (var resultado in query)
                {
                    ProfesorDC objProfesor = new ProfesorDC();

                    objProfesor.Cod_Pro = resultado.Cod_Pro;
                    objProfesor.NombreCompleto = resultado.Nom_Pro + " " + resultado.Ape_Pro;
                    objProfesor.Email_Pro = resultado.email_Pro;
                    objProfesor.Especialidad = resultado.Tb_Especialidad.Des_Esp;
                    objProfesor.Direccion_Pro = resultado.direccion_Pro + " - " +
                                                resultado.Tb_Ubigeo.Distrito + " - " +
                                                resultado.Tb_Ubigeo.Provincia + " - " +
                                                resultado.Tb_Ubigeo.Departamento;

                    objProfesor.Numero_secciones = Convert.ToInt16(resultado.Tb_Seccion.Count());


                    listaProfesor.Add(objProfesor);
                }
                return listaProfesor;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        

        public List<ProfesorDC> ListarProfesorCurso(string strCodCurso)
        {
            try
            {
                // Instanciar el modelo

                DBMatricula2Entities misProfesores = new DBMatricula2Entities();

                // creamos la lista para retornas

                List<ProfesorDC> listaProfesor = new List<ProfesorDC>();

                // Obtener la lista de profesores (ordenada por apellido) por CURSO haciendo inner JOIN con LINQ

                var query = from profesor in misProfesores.Tb_Profesores
                            join seccion in misProfesores.Tb_Seccion
                            on profesor.Cod_Pro equals seccion.Cod_Pro
                            join curso in misProfesores.Tb_Cursos
                            on seccion.Cod_Cur equals curso.Cod_Cur
                            join especialidad in misProfesores.Tb_Especialidad
                            on profesor.Cod_Espec equals especialidad.Cod_Esp
                            where curso.Cod_Cur == strCodCurso
                            select new
                            {
                                codigoProfesor = profesor.Cod_Pro,
                                nombreProfesor = profesor.Nom_Pro,
                                apellidoProfesor = profesor.Ape_Pro,
                                correoProfesor = profesor.email_Pro,
                                especialidadProfesor = especialidad.Des_Esp,
                                direccionprofesor = profesor.direccion_Pro,
                                cursoProfe = curso.Des_Cur,
                                seccionProfe = seccion.Id_Seccion,
                            };
                            
              

                foreach (var resultado in query)
                {
                    ProfesorDC objProfesor = new ProfesorDC();

                    objProfesor.Cod_Pro = resultado.codigoProfesor;
                    objProfesor.NombreCompleto = resultado.nombreProfesor + " " + resultado.apellidoProfesor;
                    objProfesor.Email_Pro = resultado.correoProfesor;
                    objProfesor.Especialidad = resultado.especialidadProfesor;
                    objProfesor.Direccion_Pro = resultado.direccionprofesor;
                    objProfesor.Numero_secciones = Convert.ToInt16(resultado.seccionProfe.Count());


                    listaProfesor.Add(objProfesor);
                }
                return listaProfesor;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        //--------------------

        //Ya no se usará porque no agrega valor
        public List<ProfesorDC> ObtenerCargaTrabajoProfesor(string periodo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<ProfesorDC> objListaProfesorDC = new List<ProfesorDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ObtenerCargaTrabajoProfesor(periodo);

                foreach (var profesor in query)
                {
                    ProfesorDC objProfesorDC = new ProfesorDC();

                    objProfesorDC.NombreCompleto = profesor.NombreCompletoProfesor;
                    objProfesorDC.Periodo = profesor.Periodo;
                    objProfesorDC.Numero_secciones = Convert.ToInt16(profesor.Numero_Secciones);

                    objListaProfesorDC.Add(objProfesorDC);
                }

                
                //***********************************************************//
                //retornamos la coleccion
                return objListaProfesorDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Ya no se usará, se cambió por ListarProfesorCurso( )
        public List<ProfesorDC> ObtenerProfesoresPorCurso(string strCodCurso)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<ProfesorDC> objListaProfesorDC = new List<ProfesorDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ObtenerProfesoresPorCurso(strCodCurso);

                foreach (var profesor in query)
                {
                    ProfesorDC objProfesorDC = new ProfesorDC();

                    objProfesorDC.Cod_Curso = profesor.CodigoCurso;
                    objProfesorDC.Nom_Curso = profesor.NombreCurso;
                    objProfesorDC.NombreCompleto = profesor.NombreCompletoProfesor;

                    objListaProfesorDC.Add(objProfesorDC);
                }


                //***********************************************************//
                //retornamos la coleccion
                return objListaProfesorDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Ya no se usará, se cambió por ListarProfesorEspecialidad( )
        public List<ProfesorDC> ObtenerProfesoresPorEspecialidad(string strCodCurso)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<ProfesorDC> objListaProfesorDC = new List<ProfesorDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ObtenerProfesoresPorEspecialidad(strCodCurso);

                foreach (var profesor in query)
                {
                    ProfesorDC objProfesorDC = new ProfesorDC();

                    objProfesorDC.Cod_Espec = profesor.CodigoEspecialidad;
                    objProfesorDC.Especialidad = profesor.NombreEspecialidad;
                    objProfesorDC.NombreCompleto = profesor.NombreCompletoProfesor;
                    objProfesorDC.Cod_Pro = profesor.CodigoProfesor;

                    objListaProfesorDC.Add(objProfesorDC);
                }


                //***********************************************************//
                //retornamos la coleccion
                return objListaProfesorDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
