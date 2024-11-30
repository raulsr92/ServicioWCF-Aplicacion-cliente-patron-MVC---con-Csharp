using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioCursos" en el código y en el archivo de configuración a la vez.
    public class ServicioCursos : IServicioCursos
    {
        public Boolean ActualizarCurso(CursoDC objCursoDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_ActualizarCursos
                    (
                        objCursoDC.Cod_Cur,
                        objCursoDC.Des_Cur,
                        objCursoDC.Cred_Cur,
                        objCursoDC.Usu_Reg,
                        Convert.ToBoolean(objCursoDC.Est_Curso)
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

        public Boolean EliminarCurso(String strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_EliminarCursos(strCodigo);

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

        public Boolean InsertarCurso(CursoDC objCursoDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_InsertarCursos
                    (
                        objCursoDC.Des_Cur,
                        objCursoDC.Cred_Cur,
                        objCursoDC.Usu_Reg,
                        Convert.ToBoolean(objCursoDC.Est_Curso)
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

        public CursoDC ConsultarCurso(String strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                CursoDC objCursoDC = new CursoDC();
                //***********************************************************//

                var query = MisMatriculas.usp_ConsultartCursos(strCodigo);

                foreach (var item in query)
                {
                    objCursoDC.Cod_Cur = item.Cod_Cur;
                    objCursoDC.Des_Cur = item.Des_Cur;
                    objCursoDC.Cred_Cur = Convert.ToInt16(item.Cred_Cur);
                    objCursoDC.Usu_Reg = item.Usu_Reg;
                    Convert.ToBoolean(objCursoDC.Est_Curso);
                    objCursoDC.Fec_Reg = Convert.ToDateTime(item.Fec_Reg);
                    objCursoDC.Usu_Ult_Mod = item.Usu_Ult_Mod;
                    objCursoDC.Fec_Ult_Mod = Convert.ToDateTime(item.Fec_Ult_Mod);
                }
                //***********************************************************//
                //retornamos la coleccion
                return objCursoDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CursoDC> ListarCurso()
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<CursoDC> objListaCursos = new List<CursoDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ListarCursos();

                foreach (var item in query)
                {
                    CursoDC objCursoDC = new CursoDC();

                    objCursoDC.Cod_Cur = item.Cod_Cur;
                    objCursoDC.Des_Cur = item.Des_Cur;
                    objCursoDC.Cred_Cur = Convert.ToInt16(item.Cred_Cur);
                    objCursoDC.Usu_Reg = item.Usu_Reg;
                    Convert.ToBoolean(objCursoDC.Est_Curso);
                    objCursoDC.Fec_Reg = Convert.ToDateTime(item.Fec_Reg);
                    objCursoDC.Usu_Ult_Mod = item.Usu_Ult_Mod;
                    objCursoDC.Fec_Ult_Mod = Convert.ToDateTime(item.Fec_Ult_Mod);

                    objListaCursos.Add(objCursoDC);
                }
                //***********************************************************//
                //retornamos la coleccion
                return objListaCursos;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        // Operaciones de consulta de negocio

        public List<CursoDC> ListarCurso2()
        {
            try
            {
                // Instanciar el modelo
                DBMatricula2Entities misEspecialidades = new DBMatricula2Entities();

                // creamos la lista para retornas
                List<CursoDC> listaCurso = new List<CursoDC>();

                // obtenemos el listado
                var query = misEspecialidades.Tb_Cursos.OrderBy(miCurso =>  miCurso.Des_Cur);

                foreach (var resultado in query)
                {
                    CursoDC objCurso  = new CursoDC();

                    objCurso.Cod_Cur = resultado.Cod_Cur;
                    objCurso.Des_Cur = resultado.Des_Cur;
                    objCurso.Cred_Cur = Convert.ToInt16(resultado.Cred_Cur);
                    objCurso.Est_Curso = Convert.ToInt32(resultado.Est_Cur);   
                    //Para determinar la cantidad de profesores dictando por cada curso
                    objCurso.cantProfesores = resultado.Tb_Seccion.Count();

                    //Para determinar la cantidad de seccioneS(horarios) abiertos para cada curso
                    objCurso.cantSecciones = resultado.Tb_Seccion.Count();

                    listaCurso.Add(objCurso);
                }
                return listaCurso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
