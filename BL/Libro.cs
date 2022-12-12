using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("@IdAutor", SqlDbType.Int);
                        collection[1].Value = (int)libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("@NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = (int)libro.NumeroPaginas;

                        collection[3] = new SqlParameter("@FechaDePublicacion", SqlDbType.VarChar);
                        collection[3].Value = libro.FechaDePublicacion;

                        collection[4] = new SqlParameter("@IdEditorial", SqlDbType.Int);
                        collection[4].Value = (int)libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("@Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("@IdGenero", SqlDbType.Int);
                        collection[6].Value = (int)libro.Genero.IdGenero;

                        //Ir llenando con los parametros
                        cmd.Parameters.AddRange(collection);
                        //Abrir la conexion
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("@IdAutor", SqlDbType.Int);
                        collection[1].Value = (int)libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("@NumeroPaginas", SqlDbType.Int);
                        collection[2].Value = (int)libro.NumeroPaginas;

                        collection[3] = new SqlParameter("@FechaDePublicacion", SqlDbType.VarChar);
                        collection[3].Value = libro.FechaDePublicacion;

                        collection[4] = new SqlParameter("@IdEditorial", SqlDbType.Int);
                        collection[4].Value = (int)libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("@Edicion", SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("@IdGenero", SqlDbType.Int);
                        collection[6].Value = (int)libro.Genero.IdGenero;

                        collection[7] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[7].Value = (int)libro.IdLibro;


                        //Ir llenando con los parametros
                        cmd.Parameters.AddRange(collection);
                        //Abrir la conexion
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = (int)libro.IdLibro;


                        //Ir llenando con los parametros
                        cmd.Parameters.AddRange(collection);
                        //Abrir la conexion
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        DataTable tablaLibro = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenamos la tabla
                        adapter.Fill(tablaLibro);
                        //si la tabla tiene filas
                        if (tablaLibro.Rows.Count > 0)
                        {
                            cmd.Connection.Open();
                            result.Objects = new List<object>();
                            foreach (DataRow row in tablaLibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();
                                libro.Autor = new ML.Autor();
                                libro.Editorial = new ML.Editorial();
                                libro.Genero = new ML.Genero();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.Autor.NombreAutor = row[2].ToString();
                                libro.NumeroPaginas = int.Parse(row[3].ToString());
                                libro.FechaDePublicacion = row[4].ToString();
                                libro.Editorial.NombreEditorial = row[5].ToString();
                                libro.Edicion = row[6].ToString();
                                libro.Genero.NombreGenero = row[7].ToString();

                                result.Objects.Add(libro);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;


                        //Ir llenando con los parametros
                        cmd.Parameters.AddRange(collection);

                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);



                        adapter.SelectCommand = cmd;
                        adapter.Fill(tableLibro);


                        if (tableLibro.Rows.Count > 0)
                        {
                            DataRow row = tableLibro.Rows[0];


                            ML.Libro libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.Genero = new ML.Genero();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();
                            libro.Autor.NombreAutor = row[2].ToString();
                            libro.NumeroPaginas = int.Parse(row[3].ToString());
                            libro.FechaDePublicacion = row[4].ToString();
                            libro.Editorial.NombreEditorial = row[5].ToString();
                            libro.Edicion = row[6].ToString();
                            libro.Genero.NombreGenero = row[7].ToString();

                            result.Object = libro;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }


        //Metodos Entity Framework

        public static ML.Result AddEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DAguirreLibroEntities1 context = new DL_EF.DAguirreLibroEntities1())
                {
                    var codigo = context.LibroAdd(libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaDePublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);
                    if (codigo > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Hubo un Error";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DAguirreLibroEntities1 context = new DL_EF.DAguirreLibroEntities1())
                {
                    var codigo = context.LibroUpdate(libro.IdLibro, libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaDePublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);
                    if (codigo > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Hubo un Error";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteEF(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DAguirreLibroEntities1 context = new DL_EF.DAguirreLibroEntities1())
                {
                    var codigo = context.LibroDelete(IdLibro);
                    if (codigo > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Hubo un Error";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DAguirreLibroEntities1 context = new DL_EF.DAguirreLibroEntities1())
                {
                    var codigo = context.LibroGetAll();
                    result.Objects = new List<object>();

                    if (codigo != null)
                    {
                        foreach (var obj in codigo)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.Genero = new ML.Genero();

                            libro.IdLibro = obj.IdLibro;
                            libro.Nombre = obj.Nombre;
                            libro.Autor.NombreAutor = obj.NombreAutor;
                            libro.NumeroPaginas = (int)obj.NumeroPaginas;
                            libro.FechaDePublicacion = DateTime.Parse(obj.FechaDePublicacion.ToString()).ToString("dd-MM-yyyy");
                            libro.Editorial.NombreEditorial = obj.NombreEditorial;
                            libro.Edicion = obj.Edicion;
                            libro.Genero.NombreGenero = obj.NombreGenero;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Hubo un Error";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DAguirreLibroEntities1 context = new DL_EF.DAguirreLibroEntities1())
                {
                    var codigo = context.LibroGetById(IdLibro).FirstOrDefault();

                    if (codigo != null)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Autor = new ML.Autor();
                        libro.Editorial = new ML.Editorial();
                        libro.Genero = new ML.Genero();

                        libro.IdLibro = codigo.IdLibro;
                        libro.Nombre = codigo.Nombre;
                        libro.Autor.IdAutor = (int)codigo.IdAutor;
                        libro.Autor.NombreAutor = codigo.NombreAutor;
                        libro.NumeroPaginas = (int)codigo.NumeroPaginas;
                        libro.FechaDePublicacion = DateTime.Parse(codigo.FechaDePublicacion.ToString()).ToString("dd-MM-yyyy");
                        libro.Editorial.IdEditorial = (int)codigo.IdEditorial;
                        libro.Editorial.NombreEditorial = codigo.NombreEditorial;
                        libro.Edicion = codigo.Edicion;
                        libro.Genero.IdGenero = (int)codigo.IdGenero;
                        libro.Genero.NombreGenero = codigo.NombreGenero;

                        result.Object = libro;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Hubo un Error";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
