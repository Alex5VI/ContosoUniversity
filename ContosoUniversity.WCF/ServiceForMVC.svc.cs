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
    public class ServiceForMVC : IServiceForMVC
    {
        public List<Estudiante> listarEstudiantes()
        {
            EstudianteNegocio obj = new EstudianteNegocio();
            List<Estudiante> lst = new List<Estudiante>();
            lst = obj.Instancia.listarEstudiantes();
            return lst;
        }

        public int insertarEstudiante(Estudiante _obj)
        {
            EstudianteNegocio obj = new EstudianteNegocio();
            int vReturn = obj.Instancia.insertarEstudiante(_obj);
            return vReturn;
        }
    }
}
