using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Especialidad" in both code and config file together.
    public class Especialidad : IEspecialidad
    {
        public List<DCEspecialidad> ListarEspecialidad()
        {
            try
            {
                // Instanciar el modelo
                DBMatricula2Entities misEspecialidades = new DBMatricula2Entities();

                // creamos la lista para retornas
                List<DCEspecialidad> listaEspecialidad = new List<DCEspecialidad>();

                // obtenemos el listado
                var query = misEspecialidades.Tb_Especialidad.OrderBy(miEspecialidad => miEspecialidad.Des_Esp);

                foreach (var resultado in query)
                {
                    DCEspecialidad objEspecialidad = new DCEspecialidad();

                    objEspecialidad.codEsp = resultado.Cod_Esp;
                    objEspecialidad.desEsp = resultado.Des_Esp;
                    objEspecialidad.cantProfesores = resultado.Tb_Profesores.Count();
                    listaEspecialidad.Add(objEspecialidad);
                }
                return listaEspecialidad;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
