using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioSecciones" en el código y en el archivo de configuración a la vez.
    public class ServicioSecciones : IServicioSecciones
    {
        public Boolean ActualizarSeccion(SeccionDC objSeccionDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_ActualizarSeccion
                    (
                        objSeccionDC.Id_Seccion,
                        objSeccionDC.Cod_Cur,
                        objSeccionDC.Cod_Hor,
                        objSeccionDC.Cod_Pro,
                        objSeccionDC.Cod_Sed,
                        Convert.ToBoolean(objSeccionDC.Modalidad),
                        objSeccionDC.Num_Aula,
                        objSeccionDC.cupo,
                        objSeccionDC.Usu_Reg,
                        Convert.ToBoolean(objSeccionDC.Est_Sec)
                    );
                //***********************************************************//
                //retornamos la coleccion
                MisMatriculas.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarSeccion(String strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_EliminarSeccion(strCodigo);

                MisMatriculas.SaveChanges();

                //***********************************************************//
                //retornamos la coleccion
                return true;
            }

            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean InsertarSeccion(SeccionDC objSeccionDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_InsertarSeccion
                    (
                        objSeccionDC.Cod_Cur,
                        objSeccionDC.Cod_Hor,
                        objSeccionDC.Cod_Pro,
                        objSeccionDC.Cod_Sed,
                        Convert.ToBoolean(objSeccionDC.Modalidad),
                        objSeccionDC.Num_Aula,
                        objSeccionDC.cupo,
                        objSeccionDC.Usu_Reg,
                        objSeccionDC.Fec_Reg.ToString(),
                        Convert.ToBoolean(objSeccionDC.Est_Sec)
                    );
                MisMatriculas.SaveChanges();

                //***********************************************************//
                //retornamos la coleccion
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SeccionDC ConsultarSeccion(String strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                SeccionDC objSeccionDC = new SeccionDC();
                //***********************************************************//

                var query = MisMatriculas.usp_ConsultarSeccion(strCodigo);

                foreach (var item in query)
                {
                    objSeccionDC.Id_Seccion = item.Id_Seccion;
                    objSeccionDC.Cod_Cur = item.Cod_Cur;
                    objSeccionDC.Cod_Hor = item.Cod_Hor;
                    objSeccionDC.Cod_Pro = item.Cod_Pro;
                    objSeccionDC.Cod_Sed = item.Cod_Sed;
                    objSeccionDC.Modalidad = Convert.ToInt16(item.Modalidad);
                    objSeccionDC.Num_Aula = item.Num_Aula;
                    objSeccionDC.cupo = Convert.ToInt16(item.cupo);
                    objSeccionDC.Usu_Reg = item.Usu_Reg;
                    objSeccionDC.Fec_Reg = Convert.ToDateTime(item.Fec_Reg);
                    objSeccionDC.Usu_Ult_Mod = item.Usu_Ult_Mod;
                    objSeccionDC.Fec_Ult_Mod = Convert.ToDateTime(item.Fec_Ult_Mod);
                    objSeccionDC.Est_Sec = Convert.ToInt16(item.Est_Sec);
                }
                //***********************************************************//
                //retornamos la coleccion
                return objSeccionDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SeccionDC> ListarSeccion()
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<SeccionDC> objListaSecciones = new List<SeccionDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ListarSeccion();

                foreach (var item in query)
                {
                    SeccionDC objSeccionDC = new SeccionDC();

                    objSeccionDC.Id_Seccion = item.Id_Seccion;
                    objSeccionDC.Cod_Cur = item.Cod_Cur;
                    objSeccionDC.Cod_Hor = item.Cod_Hor;
                    objSeccionDC.Cod_Pro = item.Cod_Pro;
                    objSeccionDC.Cod_Sed = item.Cod_Sed;
                    objSeccionDC.Modalidad = Convert.ToInt16(item.Modalidad);
                    objSeccionDC.Num_Aula = item.Num_Aula;
                    objSeccionDC.cupo = Convert.ToInt16(item.cupo);
                    objSeccionDC.Usu_Reg = item.Usu_Reg;
                    objSeccionDC.Fec_Reg = Convert.ToDateTime(item.Fec_Reg);
                    objSeccionDC.Usu_Ult_Mod = item.Usu_Ult_Mod;
                    objSeccionDC.Fec_Ult_Mod = Convert.ToDateTime(item.Fec_Ult_Mod);
                    objSeccionDC.Est_Sec = Convert.ToInt16(item.Est_Sec);

                    objListaSecciones.Add(objSeccionDC);
                }
                //***********************************************************//
                //retornamos la coleccion
                return objListaSecciones;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Operaciones de consulta de negocio

        public List<SeccionDC> ListarSeccion2()
        {
            try
            {
                // Instanciar el modelo
                DBMatricula2Entities misProfesores = new DBMatricula2Entities();

                // creamos la lista para retornar
                List<SeccionDC> listaseccion = new List<SeccionDC>();

                // Obtener la lista de SECCIONES
                var query = misProfesores.Tb_Seccion.ToList();

                //recorrer la lista
                foreach (var resultado in query)
                {
                    //Crear un objeto de seccion DC para que se vayan creando en c/iteración
                    SeccionDC objSeccion = new SeccionDC();

                    objSeccion.Id_Seccion = resultado.Id_Seccion;
                    objSeccion.Nom_Curso = resultado.Tb_Cursos.Des_Cur;
                    objSeccion.Horario = resultado.Tb_Horario.DiaSem_Hor + " : " +
                                          resultado.Tb_Horario.Ini_Hor + " - " +
                                          resultado.Tb_Horario.Fin_Hor;
                    objSeccion.NombreCompletoProfesor = resultado.Tb_Profesores.Nom_Pro + "  " +
                                                        resultado.Tb_Profesores.Ape_Pro;
                    objSeccion.Sede = resultado.Tb_Sede.Desc_Sed;
                    objSeccion.Num_Aula = resultado.Num_Aula;
                    objSeccion.cupo = Convert.ToInt16(resultado.cupo);

                    listaseccion.Add(objSeccion);
                }

                return listaseccion;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public List<SeccionDC> ListarSeccionCurso(string strCodCurso)
        {
            try
            {
                // Instanciar el modelo
                DBMatricula2Entities misProfesores = new DBMatricula2Entities();

                // creamos la lista para retornar
                List<SeccionDC> listaseccion = new List<SeccionDC>();

                // Obtener la lista de SECCIONES
                var query = misProfesores.Tb_Seccion.Where(miCurso => miCurso.Cod_Cur ==  strCodCurso).ToList();

                //recorrer la lista
                foreach (var resultado in query)
                {
                    //Crear un objeto de seccion DC para que se vayan creando en c/iteración
                    SeccionDC objSeccion = new SeccionDC();

                    objSeccion.Id_Seccion = resultado.Id_Seccion;
                    objSeccion.Nom_Curso = resultado.Tb_Cursos.Des_Cur;
                    objSeccion.Horario = resultado.Tb_Horario.DiaSem_Hor + " : " +
                                          resultado.Tb_Horario.Ini_Hor + " - " +
                                          resultado.Tb_Horario.Fin_Hor;
                    objSeccion.NombreCompletoProfesor = resultado.Tb_Profesores.Nom_Pro + "  " +
                                                        resultado.Tb_Profesores.Ape_Pro;
                    objSeccion.Sede = resultado.Tb_Sede.Desc_Sed;
                    objSeccion.Num_Aula = resultado.Num_Aula;
                    objSeccion.cupo = Convert.ToInt16(resultado.cupo);

                    listaseccion.Add(objSeccion);
                }

                return listaseccion;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public List<SeccionDC> ListarSeccionProfesor(string strCodProfesor)
        {
            try
            {
                // Instanciar el modelo
                DBMatricula2Entities misProfesores = new DBMatricula2Entities();

                // creamos la lista para retornar
                List<SeccionDC> listaseccion = new List<SeccionDC>();

                // Obtener la lista de SECCIONES
                var query = misProfesores.Tb_Seccion.Where(miCurso => miCurso.Cod_Pro == strCodProfesor).ToList();

                //recorrer la lista
                foreach (var resultado in query)
                {
                    //Crear un objeto de seccion DC para que se vayan creando en c/iteración
                    SeccionDC objSeccion = new SeccionDC();

                    objSeccion.Id_Seccion = resultado.Id_Seccion;
                    objSeccion.Nom_Curso = resultado.Tb_Cursos.Des_Cur;
                    objSeccion.Horario = resultado.Tb_Horario.DiaSem_Hor + " : " +
                                          resultado.Tb_Horario.Ini_Hor + " - " +
                                          resultado.Tb_Horario.Fin_Hor;
                    objSeccion.NombreCompletoProfesor = resultado.Tb_Profesores.Nom_Pro + "  " +
                                                        resultado.Tb_Profesores.Ape_Pro;
                    objSeccion.Sede = resultado.Tb_Sede.Desc_Sed;
                    objSeccion.Num_Aula = resultado.Num_Aula;
                    objSeccion.cupo = Convert.ToInt16(resultado.cupo);

                    listaseccion.Add(objSeccion);
                }

                return listaseccion;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
        public List<SeccionDC> ListarSeccionSede(string strCodSede)
        {
            try
            {
                // Instanciar el modelo
                DBMatricula2Entities misProfesores = new DBMatricula2Entities();

                // creamos la lista para retornar
                List<SeccionDC> listaseccion = new List<SeccionDC>();

                // Obtener la lista de SECCIONES
                var query = misProfesores.Tb_Seccion.Where(miCurso => miCurso.Cod_Sed == strCodSede).ToList();

                //recorrer la lista
                foreach (var resultado in query)
                {
                    //Crear un objeto de seccion DC para que se vayan creando en c/iteración
                    SeccionDC objSeccion = new SeccionDC();

                    objSeccion.Id_Seccion = resultado.Id_Seccion;
                    objSeccion.Nom_Curso = resultado.Tb_Cursos.Des_Cur;
                    objSeccion.Horario = resultado.Tb_Horario.DiaSem_Hor + " : " +
                                          resultado.Tb_Horario.Ini_Hor + " - " +
                                          resultado.Tb_Horario.Fin_Hor;
                    objSeccion.NombreCompletoProfesor = resultado.Tb_Profesores.Nom_Pro + "  " +
                                                        resultado.Tb_Profesores.Ape_Pro;
                    objSeccion.Sede = resultado.Tb_Sede.Desc_Sed;
                    objSeccion.Num_Aula = resultado.Num_Aula;
                    objSeccion.cupo = Convert.ToInt16(resultado.cupo);

                    listaseccion.Add(objSeccion);
                }

                return listaseccion;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //--------------------


        //Ya no se usará, se cambió por ListarSeccionCurso
        public List<SeccionDC> ObtenerSeccionesPorCurso(string strCodCurso)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<SeccionDC> objListaSeccionDC = new List<SeccionDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ObtenerSeccionesPorCurso(strCodCurso);

                foreach (var seccion in query)
                {
                    SeccionDC objSeccionDC = new SeccionDC();

                    objSeccionDC.Cod_Curso = seccion.CodigoCurso;
                    objSeccionDC.Nom_Curso = seccion.NombreCurso;
                    objSeccionDC.NombreCompletoProfesor = seccion.NombreCompletoProfesor;
                    objSeccionDC.cupo = Convert.ToInt16(seccion.Cupos);

                    objListaSeccionDC.Add(objSeccionDC);
                }


                //***********************************************************//
                //retornamos la coleccion
                return objListaSeccionDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

