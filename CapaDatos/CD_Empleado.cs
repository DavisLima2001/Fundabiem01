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
  public  class CD_Empleado
    {
        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select	e.IdEmpleado,e.PrimerNombre,e.SegundoNombre,e.PrimerApellido,e.SegundoApellido,p.IdPuesto,p.NombrPuesto");
                    sb.AppendLine("from EMPLEADO e inner join PUESTO p on e.IdPuesto =p.IdPuesto");
                    sb.AppendLine("select p.IdPuesto,p.NombrPuesto from  PUESTO p");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Empleado()
                            {
                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                PrimerNombre = dr["PrimerNombre"].ToString(),

                                SegundoNombre = dr["SegundoNombre"].ToString(),

                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                oPuesto = new Puesto() { IdPuesto = Convert.ToInt32(dr["IdPuesto"]), NombrPuesto = dr["NombrPuesto"].ToString() },

                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<Empleado>();
            }

            return lista;
        }


        public int Registrar(Empleado obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_EMPLEADO", oconexion);

                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("IdPuesto", obj.oPuesto.IdPuesto);




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


        public bool Editar(Empleado obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_EMPLEADO", oconexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", obj.IdEmpleado);
                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("IdPuesto", obj.oPuesto.IdPuesto);





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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from EMPLEADO where IdEmpleado = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (SqlException ex)
            {
                resultado = false;

                // Verificar si la excepción es debido a restricción de clave externa
                if (ex.Number == 547)
                {
                    Mensaje = "No se puede eliminar el empleado porque esta relacionado con las fichas que tiene fUNDABIEM";
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
