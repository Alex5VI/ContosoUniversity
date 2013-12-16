using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContosoUniversity.BE;

namespace ContosoUniversity.DALC
{
    public interface IEstudianteDatos
    {
        List<Estudiante> listarEstudiantes();
        int insertarEstudiante(Estudiante _obj);
        void eliminarEstudiante(int _StudentID);
        Estudiante seleccionarEstudiante(int _StudentID);
    }
}
