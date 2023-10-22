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
   public class CD_Estadistica
    {

        public List<Estadistica> Listar()
        {
            List<Estadistica> lista = new List<Estadistica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select IdEstadisticaDiaria,e.IdEmpleado, e.PrimerNombre+' '+e.PrimerApellido as nombre, CONVERT(VARCHAR, FechaRegistro, 103) AS FechaRegistro, horaInicio, horaFin from ESTADISTICA_DIARIA et ");
                    sb.AppendLine("inner join EMPLEADO e on et.IdEmpleado= e.IdEmpleado ORDER BY IdEstadisticaDiaria DESC");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Estadistica()
                            {
                                IdEstadisticaDiaria = Convert.ToInt32(dr["IdEstadisticaDiaria"]),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                horaFin = dr["horaFin"].ToString(),

                                horaInicio = dr["horaInicio"].ToString(),

     

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
                lista = new List<Estadistica>();
            }

            return lista;
        }




        public Estadistica VerEstadistica(string FechaRegistro)
        {
            Estadistica objeto = new Estadistica();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("BuscarEstadisticaDiariaXFecha", oconexion);
                    cmd.Parameters.AddWithValue("FechaRegistro", FechaRegistro);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            objeto = new Estadistica()
                            {
                                IdEstadisticaDiaria = Convert.ToInt32(dr["IdEstadisticaDiaria"]),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                horaInicio = dr["horaInicio"].ToString(),

                                horaFin = dr["horaFin"].ToString(),

                                oEmpleado = new Empleado() { IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]), PrimerNombre = dr["nombre"].ToString() },

                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objeto = new Estadistica();
                Console.WriteLine(ex.Message);
            }

            return objeto;
        }





        public int Registrar(Estadistica obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("IngresarEstadisticaDiaria", oconexion);

                    cmd.Parameters.AddWithValue("FechaRegistro", obj.FechaRegistro);
                    cmd.Parameters.AddWithValue("horaInicio", obj.horaInicio);
                    cmd.Parameters.AddWithValue("horaFin", obj.horaFin);
                    cmd.Parameters.AddWithValue("IdEmpleado", obj.oEmpleado.IdEmpleado);
                  





                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (SqlException sqlEx)
            {

                {
                    // Verifica si el error está relacionado con la conversión de fecha
                    if (sqlEx.Number == 8114 || sqlEx.Number == 8114)
                    {
                        // 241: Conversion failed when converting date and/or time from character string.
                        // 242: The conversion of a nvarchar data type to a datetime data type resulted in an out-of-range value.

                        idautogenerado = 0;
                        Mensaje = "Error al convertir la fecha. Utilice el formato yyyy/mm/dd.";
                    }

                }
            }
            catch (IOException ex)
            {
                idautogenerado = 0;

                Console.WriteLine(ex.Message);
            }
            return idautogenerado;
        }
        public bool Editar(Estadistica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                        SqlCommand cmd = new SqlCommand("ActualizarEstadisticaDiaria", oconexion);
                    cmd.Parameters.AddWithValue("IdEstadisticaDiaria", obj.IdEstadisticaDiaria);
                    cmd.Parameters.AddWithValue("FechaRegistro", obj.FechaRegistro);
                    cmd.Parameters.AddWithValue("horaInicio", obj.horaInicio);
                    cmd.Parameters.AddWithValue("horaFin", obj.horaFin);
                    cmd.Parameters.AddWithValue("IdEmpleado", obj.oEmpleado.IdEmpleado);






                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (SqlException sqlEx)
            {

                {
                    // Verifica si el error está relacionado con la conversión de fecha
                    if (sqlEx.Number == 8114 || sqlEx.Number == 8114)
                    {
                        // 241: Conversion failed when converting date and/or time from character string.
                        // 242: The conversion of a nvarchar data type to a datetime data type resulted in an out-of-range value.

                        resultado = false;
                        Mensaje = "Error al convertir la fecha. Utilice el formato yyyy/mm/dd.";
                    }

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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from ESTADISTICA_DIARIA where IdEstadisticaDiaria = @id", oconexion);
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
                    Mensaje = "No se puede eliminar la estadistica porque sean hecho estadistica de cada usuario en este dia ";
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
