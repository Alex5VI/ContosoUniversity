using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContosoUniversity.BE;
using ContosoUniversity.DALC;

namespace ContosoUniversity.BL
{
    public interface IEstudianteNegocio
    {
        List<Estudiante> listarEstudiantes();
        int insertarEstudiante(Estudiante _obj);
    }
}
