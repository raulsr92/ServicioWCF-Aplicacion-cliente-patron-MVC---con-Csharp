using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioCursos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioCursos
    {
        [OperationContract]
        Boolean ActualizarCurso(CursoDC objCursoDC);
        [OperationContract]
        CursoDC ConsultarCurso(String codigo);
        [OperationContract]
        Boolean EliminarCurso(String codigo);
        [OperationContract]
        Boolean InsertarCurso(CursoDC objCursoDC);
        [OperationContract]
        List<CursoDC> ListarCurso();

        [OperationContract]
        List<CursoDC> ListarCurso2();


    }
    [DataContract]
    [Serializable]
    public class CursoDC
    {
        [DataMember]
        public String Cod_Cur { get; set; }
        [DataMember]
        public String Des_Cur { get; set; }
        [DataMember]
        public Int16 Cred_Cur { get; set; }
        [DataMember]
        public String Usu_Reg { get; set; }
        [DataMember]
        public DateTime Fec_Reg { get; set; }
        [DataMember]
        public String Usu_Ult_Mod { get; set; }
        [DataMember]
        public DateTime Fec_Ult_Mod { get; set; }
        [DataMember]
        public Int32? Est_Curso { get; set; }
        [DataMember]
        public String Estado { get; set; }

        // Se agregó la siguiente propiedad: (para servicio consulta 2)

        [DataMember]
        public Int32 cantProfesores { get; set; }

        // Se agregó la siguiente propiedad: (para servicio consulta 3)

        [DataMember]
        public Int32 cantSecciones { get; set; }


    }
}
