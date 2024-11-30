using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioSecciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioSecciones
    {
        [OperationContract]
        Boolean ActualizarSeccion(SeccionDC objSeccionDC);
        [OperationContract]
        SeccionDC ConsultarSeccion(String strCodigo);
        [OperationContract]
        Boolean EliminarSeccion(String strCodigo);
        [OperationContract]
        Boolean InsertarSeccion(SeccionDC objSeccionDC);
        [OperationContract]
        List<SeccionDC> ListarSeccion();

        // Servicio de consulta de negocio

        [OperationContract]
        List<SeccionDC> ListarSeccion2();


        [OperationContract]
        List<SeccionDC> ListarSeccionCurso(string strCodCurso);


        //--------------------

        [OperationContract]
        List<SeccionDC> ObtenerSeccionesPorCurso(string strCodCurso);

    }
    [DataContract]
    [Serializable]
    public class SeccionDC
    {
        [DataMember]
        public String Id_Seccion { get; set; }
        [DataMember]
        public String Cod_Cur { get; set; }
        [DataMember]
        public String Cod_Hor { get; set; }
        [DataMember]
        public String Cod_Pro { get; set; }
        [DataMember]
        public String Cod_Sed { get; set; }
        [DataMember]
        public Int16 Modalidad { get; set; }
        [DataMember]
        public String Num_Aula { get; set; }
        [DataMember]
        public Int16 cupo { get; set; }
        [DataMember]
        public String Usu_Reg { get; set; }
        [DataMember]
        public DateTime Fec_Reg { get; set; }
        [DataMember]
        public String Usu_Ult_Mod { get; set; }
        [DataMember]
        public DateTime Fec_Ult_Mod { get; set; }
        [DataMember]
        public Int32? Est_Sec { get; set; }

        [DataMember]
        public String Cod_Curso { get; set; }

        [DataMember]
        public String Nom_Curso { get; set; }

        [DataMember]
        public String NombreCompletoProfesor { get; set; }

        [DataMember]
        public String Horario { get; set; }


        //Propiedades a agregar para consulta 3 (secciones por curso)

        [DataMember]
        public String Sede { get; set; }



    }
}
