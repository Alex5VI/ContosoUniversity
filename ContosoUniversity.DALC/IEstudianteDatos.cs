﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContosoUniversity.BE;

namespace ContosoUniversity.DALC
{
    public interface IEstudianteDatos
    {
        List<Estudiante> listarEstudiantes();
    }
}