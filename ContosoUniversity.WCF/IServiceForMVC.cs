using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using ContosoUniversity.BE;
using ContosoUniversity.BL;

namespace ContosoUniversity.WCF
{
    [ServiceContract]
    public interface IServiceForMVC
    {
        [OperationContract]
        List<Estudiante> listarEstudiantes();
        [OperationContract]
        int insertarEstudiante(Estudiante _obj);
    }
}
