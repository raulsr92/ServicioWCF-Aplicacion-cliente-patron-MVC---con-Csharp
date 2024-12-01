using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioSedes" in both code and config file together.
    [ServiceContract]
    public interface IServicioSedes
    {

        // Operaciones de consulta de negocio

        [OperationContract]
        List<SedeDC> ListarSedeConsulta();
    }


    [DataContract]
    [Serializable]
    public class SedeDC
    {
        [DataMember]
        public String Cod_Sed { get; set; }
        [DataMember]
        public String Desc_Sed { get; set; }
        [DataMember]
        public String Id_Ubigeo { get; set; }

        [DataMember]
        public String Ubicación { get; set; }

        [DataMember]
        public Int32 cantSecciones { get; set; }

        [DataMember]
        public Int32 cantCursos { get; set; }

        [DataMember]
        public Int32 cantProfesores { get; set; }

    }
}
