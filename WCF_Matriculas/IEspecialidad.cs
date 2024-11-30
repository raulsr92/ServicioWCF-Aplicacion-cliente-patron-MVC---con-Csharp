using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Matriculas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEspecialidad" in both code and config file together.
    [ServiceContract]
    public interface IEspecialidad
    {
        [OperationContract]
        List<DCEspecialidad> ListarEspecialidad();
    }

    [DataContract]
    [Serializable]
    public class DCEspecialidad  // definimos la clase DCColor como Data Contractual
    {
        // Cada propiedad es un DataMember de la Data Contractual

        [DataMember]
        public string codEsp { get; set; }
        [DataMember]
        public string desEsp { get; set; }
        [DataMember]
        public Int32 cantProfesores { get; set; }
    }
}
