using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioSedes" in both code and config file together.
    public class ServicioSedes : IServicioSedes
    {
        public List<SedeDC> ListarSedeConsulta()
        {
            try
            {
                // Instanciar el modelo
                DBMatricula2Entities misSedes = new DBMatricula2Entities();

                // creamos la lista para retornas
                List<SedeDC> listaSede = new List<SedeDC>();

                // obtenemos el listado

                var query = misSedes.Tb_Sede.ToList();

                foreach (var resultado in query)
                {
                    SedeDC objSede = new SedeDC();

                    objSede.Cod_Sed = resultado.Cod_Sed;
                    objSede.Desc_Sed = resultado.Desc_Sed;
                    objSede.Id_Ubigeo = resultado.Id_Ubigeo;
                    objSede.Ubicación = resultado.Tb_Ubigeo.Distrito + " - " +
                                        resultado.Tb_Ubigeo.Provincia + " - " +
                                        resultado.Tb_Ubigeo.Departamento;
                    objSede.cantSecciones = resultado.Tb_Seccion.Count();

                    listaSede.Add(objSede);
                }
                return listaSede;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
