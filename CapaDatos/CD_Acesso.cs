using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace CapaDatos
{
   public class CD_Acesso
    {
        public List<Acceso> Listar()
        {
            List<Acceso> lista = new List<Acceso>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Select a.IdAcceso,a.Fecha,a.Correo,a.Contraseña,a.Activo,e.IdEmpleado,e.PrimerNombre+' '+e.PrimerApellido nombre,p.IdPuesto ,p.NombrPuesto");
                    sb.AppendLine("from ACCESO a inner join EMPLEADO e on a.IdEmpleado = e.IdEmpleado");
                    sb.AppendLine("inner join PUESTO p on p.IdPuesto = e.IdPuesto");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Acceso()
                            {
                                IdAcceso = Convert.ToInt32(dr["IdAcceso"]),
                                Fecha = dr["Fecha"].ToString(),
                                Correo = dr["Correo"].ToString(),

                                NombrPuesto = dr["NombrPuesto"].ToString(),

                                Contraseña = dr["Contraseña"].ToString(),
                                
                                Activo = Convert.ToBoolean(dr["Activo"]),
                               
                                oEmpleado = new Empleado() { IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]), PrimerNombre = dr["nombre"].ToString() },

                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<Acceso>();
            }

            return lista;
        }

        public int Registrar(Acceso obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_ACCESO", oconexion);

                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.AddWithValue("IdEmpleado", obj.oEmpleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                




                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (IOException ex)
            {
                idautogenerado = 0;

                Console.WriteLine(ex.Message);
            }
            return idautogenerado;
        }

        public bool Editar(Acceso obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_ACCESO", oconexion);
                    cmd.Parameters.AddWithValue("IdAcceso", obj.IdAcceso);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    // Manejar el caso de contraseña nula
                    if (obj.Contraseña != null)
                    {
                        cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Contraseña", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("IdEmpleado", obj.oEmpleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);





                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1)  from ACCESO where IdAcceso = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (SqlException ex)
            {
                resultado = false;

                
                if (ex.Number == 547)
                {
                    Mensaje = "No se puede eliminar el los datos para acceso al sistema";
                }
                else
                {
                    Mensaje = ex.Message;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


    }
}
