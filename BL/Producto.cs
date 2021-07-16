using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class Producto
    {
        //ADD
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                  string Query = "INSERT INTO [Producto] ([Nombre],[Descripcion],[Proveedor],[Existencia]) VALUES (@Nombre,@Descripcion, @Proveedor, @Existencia)";

                     using (SqlCommand cmd = new SqlCommand())
                     {
                         cmd.Connection = context;
                         cmd.CommandText = Query;
                        

                         SqlParameter[] collection = new SqlParameter[4];

                         collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                         collection[0].Value = producto.Nombre;

                         collection[1] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                         collection[1].Value = producto.Descripcion;

                         collection[2] = new SqlParameter("Proveedor", SqlDbType.VarChar);
                         collection[2].Value = producto.Proveedor;

                         collection[3] = new SqlParameter("Existencia", SqlDbType.Int);
                         collection[3].Value = producto.Existencia;

                         cmd.Parameters.AddRange(collection);

                         cmd.Connection.Open();

                         int RowsAffected = cmd.ExecuteNonQuery();

                         cmd.Connection.Close();

                         if (RowsAffected > 0)
                         {
                             result.Correct = true;
                         }
                         else
                         {
                             result.Correct = false;
                             result.ErrorMessage = "El producto no se pudo insertar correctamente.";
                         }
                     }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
           
            return result;
        }
        //UPDATE
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();            
                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        string Query = "UPDATE Producto SET Nombre=@Nombre,Descripcion=@Descripcion,Proveedor=@Proveedor,Existencia=@Existencia WHERE IdProducto=@IdProducto";

                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = context;
                            cmd.CommandText = Query;

                            SqlParameter[] collection = new SqlParameter[5];

                            collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                            collection[0].Value = producto.Nombre;

                            collection[1] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                            collection[1].Value = producto.Descripcion;

                            collection[2] = new SqlParameter("Proveedor", SqlDbType.VarChar);
                            collection[2].Value = producto.Proveedor;

                            collection[3] = new SqlParameter("Existencia", SqlDbType.Int);
                            collection[3].Value = producto.Existencia;

                            collection[4] = new SqlParameter("IdProducto", SqlDbType.Int);
                            collection[4].Value = producto.IdProducto;

                            cmd.Parameters.AddRange(collection);

                            cmd.Connection.Open();

                            int RowsAffected = cmd.ExecuteNonQuery();

                            cmd.Connection.Close();

                            if (RowsAffected > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "El producto no se pudo insertar correctamente.";
                            }
                        }  
                    }

                }
                catch  (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }

                return result;
            }

        //DELETE
             public static ML.Result Delete(ML.Producto producto){
                 ML.Result result = new ML.Result();
                 try{
                     using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                     {
                         string Query = "DELETE FROM Producto WHERE IdProducto=@IdProducto";

                         using (SqlCommand cmd = new SqlCommand())
                         {

                             cmd.Connection = context;
                             cmd.CommandText = Query;

                             SqlParameter[] collection = new SqlParameter[1];

                             collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                             collection[0].Value = producto.IdProducto;

                             cmd.Parameters.AddRange(collection);

                             cmd.Connection.Open();

                             int RowsAffected = cmd.ExecuteNonQuery();

                             cmd.Connection.Close();

                             if (RowsAffected > 0)
                             {
                                 result.Correct = true;
                             }
                             else
                             {
                                 result.Correct = false;
                                 result.ErrorMessage = "El producto no se pudo insertar correctamente.";
                             }
                         }

                     }
                 }
                 catch(Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }

                return result;
             }
        //GETALL
    public static ML.Result GetAll(ML.Producto producto)
      {
         ML.Result result = new ML.Result();
            try
              {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                  {
                      string Query = "SELECT * FROM Producto";

                      using (SqlCommand cmd = new SqlCommand())
                      {

                         cmd.Connection = context;
                         cmd.CommandText = Query;
                                              
                         cmd.Connection.Open();
                         SqlDataReader reader = cmd.ExecuteReader();

                         if (reader.HasRows)
                         {
                             while (reader.Read())
                             {
                                 Console.WriteLine(reader["IdProducto"] + "\t" + reader["Nombre"] + "\t" + "\t" + reader["Descripcion"] + "\t" + reader["Proveedor"] + "\t" + "\t" + reader["Existencia"]);
                             }
                            
                            result.Correct = true;
                             
                         }
                         else
                         {
                             result.Correct = false;
                             result.ErrorMessage = "El producto no se pudo insertar correctamente.";
                         } 
                       
                         cmd.Connection.Close();
                    }

               }
         }
          catch (Exception ex)
            {
              result.Correct = false;
              result.ErrorMessage = ex.Message;

            }
         return result;
      }  
        //GETBYID
    public static ML.Result GetById(ML.Producto producto)
    {
        ML.Result result = new ML.Result();
        try
        {
            using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
            {
                string Query = "SELECT * FROM Producto WHERE IdProducto=@IdProducto";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = context;
                    cmd.CommandText = Query;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                    collection[0].Value = producto.IdProducto;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                   
                     int RowsAffected = cmd.ExecuteNonQuery();
                     SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["IdProducto"] + "\t" + reader["Nombre"] + "\t" + "\t" + reader["Descripcion"] + "\t" + reader["Proveedor"] + "\t" + "\t" + reader["Existencia"]);
                            }

                            result.Correct = true;
                        }
                    
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El producto no se pudo insertar correctamente.";
                    }

                    cmd.Connection.Close();
                }
            }

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
