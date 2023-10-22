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
   public  class CD_USUARIO
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT  IdUsuario,  PrimerApellido,  SegundoApellido,   PrimerNombre,  SegundoNombre,  Sexo,");
                    sb.AppendLine(" Edad,    FechaNacimiento,   GrupoTecnico,    Otros,   Direccion2,   Departamento,   Ciudad,   Pais,   Lugar,   Padre,   Madre,   PersonaEncargada,");
                    sb.AppendLine("    Direccion, Telefono,  FechaHoraAdmicion,  DiagnosticoFinal,  Recomendaciones ,Firma");
                    sb.AppendLine("FROM USUARIO ");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                              
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                SegundoNombre = dr["SegundoNombre"].ToString(),
                                Sexo = dr["SegundoApellido"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                FechaNacimiento = dr["FechaNacimiento"].ToString(),
                                GrupoTecnico = dr["GrupoTecnico"].ToString(),
                                Otros = dr["Otros"].ToString(),
                                Direccion2 = dr["Direccion2"].ToString(),
                                Departamento = dr["Departamento"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                Pais = dr["Pais"].ToString(),
                                Lugar = dr["Lugar"].ToString(),
                                Padre = dr["Padre"].ToString(),
                                Madre = dr["Madre"].ToString(),
                                PersonaEncargada = dr["PersonaEncargada"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Firma = dr["Firma"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                FechaHoraAdmicion = dr["FechaHoraAdmicion"].ToString(),
                                DiagnosticoFinal = dr["DiagnosticoFinal"].ToString(),
                                Recomendaciones = dr["Recomendaciones"].ToString(),
                              









                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<Usuario>();
            }

            return lista;
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("@PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("@SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("@PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("@SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("@Edad", obj.Edad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@GrupoTecnico", obj.GrupoTecnico);
                    cmd.Parameters.AddWithValue("@Otros", obj.Otros);
                    cmd.Parameters.AddWithValue("@Direccion2", obj.Direccion2);
                    cmd.Parameters.AddWithValue("@Departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("@Residencia", obj.Residencia);
                    cmd.Parameters.AddWithValue("@Lugar", obj.Lugar);
                    cmd.Parameters.AddWithValue("@Padre", obj.Padre);
                    cmd.Parameters.AddWithValue("@Madre", obj.Madre);
                    cmd.Parameters.AddWithValue("@PersonaEncargada", obj.PersonaEncargada);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Firma", obj.Firma);
                    cmd.Parameters.AddWithValue("@DiagnosticoFinal", obj.DiagnosticoFinal);
                    cmd.Parameters.AddWithValue("@Recomendaciones", obj.Recomendaciones);


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
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario); // Agregar el parámetro IdUsuario
                    cmd.Parameters.AddWithValue("@PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("@SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("@PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("@SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("@Edad", obj.Edad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@GrupoTecnico", obj.GrupoTecnico);
                    cmd.Parameters.AddWithValue("@Otros", obj.Otros);
                    cmd.Parameters.AddWithValue("@Direccion2", obj.Direccion2);
                    cmd.Parameters.AddWithValue("@Departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("@Residencia", obj.Residencia);
                    cmd.Parameters.AddWithValue("@Lugar", obj.Lugar);
                    cmd.Parameters.AddWithValue("@Padre", obj.Padre);
                    cmd.Parameters.AddWithValue("@Madre", obj.Madre);
                    cmd.Parameters.AddWithValue("@PersonaEncargada", obj.PersonaEncargada);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Firma", obj.Firma);
                    
                    cmd.Parameters.AddWithValue("@DiagnosticoFinal", obj.DiagnosticoFinal);
                    cmd.Parameters.AddWithValue("@Recomendaciones", obj.Recomendaciones);




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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from USUARIO where IdUsuario = @id", oconexion);
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
                    Mensaje = "No se puede eliminar el usuario porque tiene registros relacionados en otras fichas.";
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
