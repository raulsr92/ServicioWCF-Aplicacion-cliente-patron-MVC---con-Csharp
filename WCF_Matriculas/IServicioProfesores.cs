using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioProfesores" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioProfesores
    {
        [OperationContract]
        Boolean ActualizarProfesor(ProfesorDC objProfesorDC);
        [OperationContract]
        ProfesorDC ConsultarProfesor(string strCodigo);
        [OperationContract]
        Boolean EliminarProfesor(string strCodigo);
        [OperationContract]
        Boolean InsertarProfesor(ProfesorDC objProfesorDC);
        [OperationContract]
        List<ProfesorDC> ListarProfesor();

        // Operaciones de consulta de negocio

        [OperationContract]
        List<ProfesorDC> ListarProfesor2();

        [OperationContract]
        List<ProfesorDC> ListarProfesorEspecialidad(string strCodEspecialidad);

        [OperationContract]
        List<ProfesorDC> ListarProfesorCurso(string strCodCurso);

        //--------------------

        [OperationContract] //Ya no se usará porque no agrega valor
        List<ProfesorDC> ObtenerCargaTrabajoProfesor(string periodo);

        [OperationContract] //Ya no se usará, se cambió por ListarProfesorCurso( )
        List<ProfesorDC> ObtenerProfesoresPorCurso(string strCodCurso);

        [OperationContract] //Ya no se usará, se cambió por ListarProfesorEspecialidad( )
        List<ProfesorDC> ObtenerProfesoresPorEspecialidad(string strCodEspecialidad);

    }
    [DataContract]
    [Serializable]
    public class ProfesorDC
    {
        [DataMember]
        public String Cod_Pro { get; set; }
        [DataMember]
        public String Nom_Pro { get; set; }
        [DataMember]
        public String Ape_Pro { get; set; }

        [DataMember]
        public String Direccion_Pro { get; set; }
        [DataMember]
        public String Email_Pro { get; set; }
        [DataMember]
        public DateTime Fec_Nac_Pro { get; set; }
        [DataMember]
        public String DNI_Pro { get; set; }
        [DataMember]
        public String Cod_Espec { get; set; }
        [DataMember]
        public String Especialidad { get; set; }
        [DataMember]
        public String Id_Ubigeo { get; set; }
        [DataMember]
        public String Departamento { get; set; }
        [DataMember]
        public String Provincia { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public String Usu_Reg { get; set; }
        [DataMember]
        public DateTime Fec_Reg { get; set; }
        [DataMember]
        public String Usu_Ult_Mod { get; set; }
        [DataMember]
        public DateTime Fec_Ult_Mod { get; set; }
        [DataMember]
        public Int32? Est_Pro { get; set; }
        public String Estado { get; set; }

        [DataMember]
        public byte[] Foto_Pro { get; set; }

        [DataMember]
        public String NombreCompleto { get; set; }

        [DataMember]
        public String Periodo { get; set; }

        [DataMember]
        public Int16 Numero_secciones { get; set; }

        [DataMember]
        public String Cod_Curso { get; set; }

        [DataMember]
        public String Nom_Curso { get; set; }
    }
}
