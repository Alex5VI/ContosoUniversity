using System;
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

            public Estudiante seleccionarEstudiante(int _StudentID)
            {
                try
                {
                    using (EstudianteDatos Dalc = new EstudianteDatos())
                    {
                        return Dalc.Instancia.seleccionarEstudiante(_StudentID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        #endregion

        #region "Procedimientos Mantenimientos"
            public int insertarEstudiante(Estudiante _obj)
            {
                try
                {
                    using (EstudianteDatos Dalc = new EstudianteDatos())
                    {
                        return Dalc.Instancia.insertarEstudiante(_obj);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        #endregion

        #region "Procedimientos Mantenimientos"
            public void eliminarEstudiante(int _StudentID)
            {
                try
                {
                    using (EstudianteDatos Dalc = new EstudianteDatos())
                    {
                        Dalc.Instancia.eliminarEstudiante(_StudentID);
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
