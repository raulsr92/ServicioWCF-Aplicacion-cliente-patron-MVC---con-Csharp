using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioAlumnos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]




    public interface IServicioAlumnos
    {
        [OperationContract]
        Boolean ActualizarEstudiante(AlumnoDC objAlumnoDC);
        [OperationContract]
        AlumnoDC ConsultarEstudiante(String strCodigo);
        [OperationContract]
        Boolean EliminarEstudiante(String strCodigo);
        [OperationContract]
        Boolean InsertarEstudiante(AlumnoDC objAlumnoDC);
        [OperationContract]
        List<AlumnoDC> ListarEstudiante();

        [OperationContract]
        AlumnoDC ObtenerCantidadAlumnosPorPeriodo(String periodo);

    }
    [DataContract]
    [Serializable]
    public class AlumnoDC
    {
        [DataMember]
        public String Cod_Est { get; set; }
        [DataMember]
        public String Nom_Est { get; set; }
        [DataMember]
        public String Ape_Est { get; set; }
        [DataMember]
        public String Tel_Est { get; set; }
        [DataMember]
        public String Email_Est { get; set; }
        [DataMember]
        public String Id_Ubigeo { get; set; }
        [DataMember]
        public String Departamento { get; set; }
        [DataMember]
        public String Provincia { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public String direccion_Est { get; set; }
        [DataMember]
        public DateTime Fec_Nac_Est { get; set; }
        [DataMember]
        public String DNI_Pro { get; set; }
        [DataMember]
        public String Usu_Reg { get; set; }
        [DataMember]
        public DateTime Fec_Reg { get; set; }
        [DataMember]
        public String Usu_Ult_Mod { get; set; }
        [DataMember]
        public DateTime Fec_Ult_Mod { get; set; }
        [DataMember]
        public Int32? Est_Est { get; set; }
        [DataMember]
        public byte[] Foto_Est { get; set; }
        [DataMember]
        public String Estado { get; set; }


        [DataMember]
        public String Periodo { get; set; }

        [DataMember]
        public Int16 Cantidad_alumnos_matri { get; set; }

    }
}