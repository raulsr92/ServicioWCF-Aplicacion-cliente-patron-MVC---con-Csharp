using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioAlumnos" en el código y en el archivo de configuración a la vez.
    public class ServicioAlumnos : IServicioAlumnos
    {
        public Boolean ActualizarEstudiante(AlumnoDC objAlumnoDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_ActualizarEstudiantes
                    (
                        objAlumnoDC.Cod_Est,
                        objAlumnoDC.Nom_Est,
                        objAlumnoDC.Ape_Est,
                        objAlumnoDC.Tel_Est,
                        objAlumnoDC.Email_Est,
                        objAlumnoDC.Id_Ubigeo,
                        objAlumnoDC.Foto_Est,
                        objAlumnoDC.direccion_Est,
                        objAlumnoDC.Fec_Nac_Est,
                        objAlumnoDC.DNI_Pro,
                        objAlumnoDC.Usu_Reg,
                        Convert.ToBoolean(objAlumnoDC.Est_Est)
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
        public Boolean EliminarEstudiante(String strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_EliminarEstudiante(strCodigo);

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
        public Boolean InsertarEstudiante(AlumnoDC objAlumnoDC)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //***********************************************************//

                MisMatriculas.usp_InsertarEstudiantes
                    (
                        objAlumnoDC.Nom_Est,
                        objAlumnoDC.Ape_Est,
                        objAlumnoDC.Tel_Est,
                        objAlumnoDC.Email_Est,
                        objAlumnoDC.Id_Ubigeo,
                        objAlumnoDC.Foto_Est,
                        objAlumnoDC.direccion_Est,
                        objAlumnoDC.Fec_Nac_Est.ToString(),
                        objAlumnoDC.DNI_Pro,
                        objAlumnoDC.Usu_Reg,
                        Convert.ToBoolean(objAlumnoDC.Est_Est)
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
        public AlumnoDC ConsultarEstudiante(String strCodigo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                AlumnoDC objAlumnoDC = new AlumnoDC();
                //***********************************************************//

                var query = MisMatriculas.usp_ConsultarEstudiantes(strCodigo);

                foreach (var item in query)
                {
                    objAlumnoDC.Cod_Est = item.Cod_Est;
                    objAlumnoDC.Nom_Est = item.Nom_Est;
                    objAlumnoDC.Ape_Est = item.Ape_Est;
                    objAlumnoDC.Tel_Est = item.Tel_Est;
                    objAlumnoDC.Email_Est = item.Email_Est;
                    objAlumnoDC.Id_Ubigeo = item.Id_Ubigeo;
                    objAlumnoDC.Departamento = item.Departamento;
                    objAlumnoDC.Provincia = item.Provincia;
                    objAlumnoDC.Distrito = item.Distrito;
                    //objAlumnoDC.Foto_Est = item.Foto_Est;
                    objAlumnoDC.direccion_Est = item.direccion_Est;
                    objAlumnoDC.Fec_Nac_Est = Convert.ToDateTime(item.Fec_Nac_Est);
                    objAlumnoDC.DNI_Pro = item.DNI_Pro;
                    objAlumnoDC.Usu_Reg = item.Usu_Reg;
                    objAlumnoDC.Fec_Reg = Convert.ToDateTime(item.Fec_Reg);
                    objAlumnoDC.Usu_Ult_Mod = item.Usu_Ult_Mod;
                    objAlumnoDC.Fec_Ult_Mod = Convert.ToDateTime(item.Fec_Ult_Mod);
                    objAlumnoDC.Est_Est = Convert.ToInt16(item.Est_Est);
                    objAlumnoDC.Estado = item.Estado;
                }

                //***********************************************************//
                //retornamos la coleccion
                return objAlumnoDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<AlumnoDC> ListarEstudiante()
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar
                List<AlumnoDC> objListaAlumnos = new List<AlumnoDC>();
                //***********************************************************//

                var query = MisMatriculas.usp_ListarEstudiantes();

                foreach (var item in query)
                {
                    AlumnoDC objAlumnoDC = new AlumnoDC();

                    objAlumnoDC.Cod_Est = item.Cod_Est;
                    objAlumnoDC.Nom_Est = item.Nom_Est;
                    objAlumnoDC.Ape_Est = item.Ape_Est;
                    objAlumnoDC.Tel_Est = item.Tel_Est;
                    objAlumnoDC.Email_Est = item.Email_Est;
                    objAlumnoDC.Id_Ubigeo = item.Id_Ubigeo;
                    objAlumnoDC.Departamento = item.Departamento;
                    objAlumnoDC.Provincia = item.Provincia;
                    objAlumnoDC.Distrito = item.Distrito;
                    //objAlumnoDC.Foto_Est = item.Foto_Est;
                    objAlumnoDC.direccion_Est = item.direccion_Est;
                    objAlumnoDC.Fec_Nac_Est = Convert.ToDateTime(item.Fec_Nac_Est);
                    objAlumnoDC.DNI_Pro = item.DNI_Pro;
                    objAlumnoDC.Usu_Reg = item.Usu_Reg;
                    objAlumnoDC.Fec_Reg = Convert.ToDateTime(item.Fec_Reg);
                    objAlumnoDC.Usu_Ult_Mod = item.Usu_Ult_Mod;
                    objAlumnoDC.Fec_Ult_Mod = Convert.ToDateTime(item.Fec_Ult_Mod);
                    objAlumnoDC.Est_Est = Convert.ToInt16(item.Est_Est);
                    objAlumnoDC.Estado = item.Estado;

                    objListaAlumnos.Add(objAlumnoDC);
                }

                //***********************************************************//
                //retornamos la coleccion
                return objListaAlumnos;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AlumnoDC ObtenerCantidadAlumnosPorPeriodo(String periodo)
        {
            try
            {
                //creamos una instancia del model
                DBMatricula2Entities MisMatriculas = new DBMatricula2Entities();
                //creamos la cosa a retornar

                AlumnoDC objAlumnoDC = new AlumnoDC();
                //***********************************************************//

                var query = MisMatriculas.usp_ObtenerCantidadAlumnosPorPeriodo(periodo).FirstOrDefault();

                if(query != null)
                {
                    objAlumnoDC.Periodo = query.Periodo;
                    objAlumnoDC.Cantidad_alumnos_matri = Convert.ToInt16(query.CantidadAlumnosMatriculados);
                }
                else
                {
                    objAlumnoDC.Cantidad_alumnos_matri = 0;
                }


                //***********************************************************//
                //retornamos la coleccion
                return objAlumnoDC;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
