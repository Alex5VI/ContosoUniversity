using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ContosoUniversity.BE;

namespace ContosoUniversity.DALC
{
    public class EstudianteDatos : IEstudianteDatos, IDisposable
    {
        private IEstudianteDatos mInstancia;
        public IEstudianteDatos Instancia
        {
            get
            {
                IEstudianteDatos retorno;
                if (mInstancia == null)
                    retorno = new EstudianteDatos();
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
                    List<Estudiante> lst = new List<Estudiante>();
                    using (SqlCommand oCommand = new SqlCommand("uspListarEstudiante", oCn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader drListado = oCommand.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                        {
                            if (drListado.HasRows)
                            {
                                while ((drListado.Read()))
                                {
                                    Estudiante obj = new Estudiante();
                                    obj.StudentID = drListado.GetInt32(drListado.GetOrdinal("StudentID"));
                                    obj.LastName = drListado.GetString(drListado.GetOrdinal("LastName"));
                                    obj.FirstName = drListado.GetString(drListado.GetOrdinal("FirstName"));
                                    obj.EnrollmentDate = drListado.GetString(drListado.GetOrdinal("EnrollmentDate"));
                                    lst.Add(obj);
                                }
                            }
                        }
                    }

                    return lst;
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
                    Estudiante obj = new Estudiante();
                    using (SqlCommand oCommand = new SqlCommand("uspSeleccionarEstudiante", oCn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Value = _StudentID;
                        using (SqlDataReader drListado = oCommand.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                        {
                            if (drListado.HasRows)
                            {
                                while ((drListado.Read()))
                                {
                                    obj.StudentID = drListado.GetInt32(drListado.GetOrdinal("StudentID"));
                                    obj.LastName = drListado.GetString(drListado.GetOrdinal("LastName"));
                                    obj.FirstName = drListado.GetString(drListado.GetOrdinal("FirstName"));
                                    obj.EnrollmentDate = drListado.GetString(drListado.GetOrdinal("EnrollmentDate"));
                                }
                            }
                        }
                    }

                    return obj;
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
                int vReturn = 0;
                try
                {
                    using (SqlCommand oCommand = new SqlCommand("uspInsertarEstudiante", oCn))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50)).Value = _obj.LastName;
                        oCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)).Value = _obj.FirstName;
                        oCommand.Parameters.Add(new SqlParameter("@EnrollmentDate", SqlDbType.VarChar, 8)).Value = _obj.EnrollmentDate;
                        oCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        oCommand.ExecuteNonQuery();
                        vReturn = Convert.ToInt32(oCommand.Parameters["@StudentID"].Value);
                    }
                    return vReturn;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        #endregion

        #region "Constructor & Disposable"
            private bool _disposed = false;
            SqlConnection oCn = null;
            public EstudianteDatos()
            {
                string strConnection = ConfigurationManager.ConnectionStrings["dbContosoUniversity"].ConnectionString;
                oCn = new SqlConnection(strConnection);
                oCn.Open();
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        //Dispose managed resources here. llamar componetes de conexion u otros.                        
                        if (oCn.State != ConnectionState.Closed)
                        {
                            oCn.Close();
                        }
                        oCn.Dispose();
                    }
                    //Disposed unmanaged resources here.
                    //set the _disposed flag to prevent subsequent disposals.
                    _disposed = true;
                }
            }
            //Finalization code.
            ~EstudianteDatos()
            {
                Dispose(false);
            }
        #endregion
    }
}
