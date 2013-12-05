﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContosoUniversity.BE;
using ContosoUniversity.DALC;

namespace ContosoUniversity.BL
{
    public class EstudianteNegocio: IEstudianteNegocio
    {
        private IEstudianteNegocio mInstancia;
        public IEstudianteNegocio Instancia
        {
            get
            {
                IEstudianteNegocio retorno;
                if (mInstancia == null)
                    retorno = new EstudianteNegocio();
                else
                    retorno = mInstancia;
                return retorno;
            }
            set
            {
                mInstancia = value;
            }
        }

        #region "Procedimientos Consultas"
            public List<Estudiante> listarEstudiantes()
            {
                try
                {
                    using (EstudianteDatos Dalc = new EstudianteDatos())
                    {
                        return Dalc.Instancia.listarEstudiantes();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        #endregion
    }
}