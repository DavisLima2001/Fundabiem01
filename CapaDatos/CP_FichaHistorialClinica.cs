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
   public class CP_FichaHistorialClinica
    {


        public List<HistorialFichasClinica> ListarHistorial()
        {
            List<HistorialFichasClinica> lista = new List<HistorialFichasClinica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select f.IdHistorialClinica,FORMAT(f.Fecha, 'yyyy-MM-dd') as Fecha,u.PrimerNombre + ' ' + u.SegundoNombre + ' ' + u.PrimerApellido + ' ' + u.SegundoApellido Nombre, f.MotivoConsulta from FICHA_HISTORIAL_CLINICA f inner join USUARIO u on u.IdUsuario = f.IdUsuario order by f.Fecha desc";
                   
                    
                    
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new HistorialFichasClinica()
                            {
                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),
                                Fecha = dr["Fecha"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                MotivoConsulta = dr["MotivoConsulta"].ToString(),
                          
                           



                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<HistorialFichasClinica>();
            }

            return lista;
        }





        public int Registrar(FichaHistorialClinica obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarRegistroHistorialClinica", oconexion);

                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("MotivoConsulta", obj.MotivoConsulta);
                    cmd.Parameters.AddWithValue("AntecedentMadre", obj.AntecedentMadre);
                    cmd.Parameters.AddWithValue("e", obj.e);
                    cmd.Parameters.AddWithValue("ab", obj.ab);
                    cmd.Parameters.AddWithValue("HijosVivos", obj.HijosVivos);
                    cmd.Parameters.AddWithValue("EstadoSaludHv", obj.EstadoSaludHv);
                    cmd.Parameters.AddWithValue("HijosMuerteCausa", obj.HijosMuerteCausa);
                    cmd.Parameters.AddWithValue("Padres", obj.Padres);
                    cmd.Parameters.AddWithValue("Otros", obj.Otros);
                    cmd.Parameters.AddWithValue("PesoNacer", obj.PesoNacer);
                    cmd.Parameters.AddWithValue("DuracionEmbarazo", obj.DuracionEmbarazo);
                    cmd.Parameters.AddWithValue("ProblemaGestional", obj.ProblemaGestional);
                    cmd.Parameters.AddWithValue("MedicinaDuranteEmbarazo", obj.MedicinaDuranteEmbarazo);
                    cmd.Parameters.AddWithValue("Tabaquismo", obj.Tabaquismo);
                    cmd.Parameters.AddWithValue("Alcohol", obj.Alcohol);
                    cmd.Parameters.AddWithValue("DuracionParto", obj.DuracionParto);
                    cmd.Parameters.AddWithValue("SufrimientoFetal", obj.SufrimientoFetal);
                    cmd.Parameters.AddWithValue("Vaginal", obj.Vaginal);
                    cmd.Parameters.AddWithValue("Cesarea", obj.Cesarea);
                    cmd.Parameters.AddWithValue("EstadoNacer", obj.EstadoNacer);
                    cmd.Parameters.AddWithValue("Apgar", obj.Apgar);
                    cmd.Parameters.AddWithValue("SostenerCabeza", obj.SostenerCabeza);
                    cmd.Parameters.AddWithValue("Sonreir", obj.Sonreir);
                    cmd.Parameters.AddWithValue("RodarAlLado", obj.RodarAlLado);
                    cmd.Parameters.AddWithValue("SentarseSolo", obj.SentarseSolo);
                    cmd.Parameters.AddWithValue("Pararse", obj.Pararse);
                    cmd.Parameters.AddWithValue("Andar", obj.Andar);
                    cmd.Parameters.AddWithValue("CaminarSolo", obj.CaminarSolo);
                    cmd.Parameters.AddWithValue("Hablar", obj.Hablar);
                    cmd.Parameters.AddWithValue("Vacunaciones", obj.Vacunaciones);
                    cmd.Parameters.AddWithValue("Enfermedades", obj.Enfermedades);
                    cmd.Parameters.AddWithValue("AntecedentesQx", obj.AntecedentesQx);
                    cmd.Parameters.AddWithValue("Diagnosticos", obj.Diagnosticos);



                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }


        public bool Editar(FichaHistorialClinica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Actualizar_HistorialClinico", oconexion);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", obj.IdHistorialClinica);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("MotivoConsulta", obj.MotivoConsulta);
                    cmd.Parameters.AddWithValue("AntecedentMadre", obj.AntecedentMadre);
                    cmd.Parameters.AddWithValue("e", obj.e);
                    cmd.Parameters.AddWithValue("ab", obj.ab);
                    cmd.Parameters.AddWithValue("HijosVivos", obj.HijosVivos);
                    cmd.Parameters.AddWithValue("EstadoSaludHv", obj.EstadoSaludHv);
                    cmd.Parameters.AddWithValue("HijosMuerteCausa", obj.HijosMuerteCausa);
                    cmd.Parameters.AddWithValue("Padres", obj.Padres);
                    cmd.Parameters.AddWithValue("Otros", obj.Otros);
                    cmd.Parameters.AddWithValue("PesoNacer", obj.PesoNacer);
                    cmd.Parameters.AddWithValue("DuracionEmbarazo", obj.DuracionEmbarazo);
                    cmd.Parameters.AddWithValue("ProblemaGestional", obj.ProblemaGestional);
                    cmd.Parameters.AddWithValue("MedicinaDuranteEmbarazo", obj.MedicinaDuranteEmbarazo);
                    cmd.Parameters.AddWithValue("Tabaquismo", obj.Tabaquismo);
                    cmd.Parameters.AddWithValue("Alcohol", obj.Alcohol);
                    cmd.Parameters.AddWithValue("DuracionParto", obj.DuracionParto);
                    cmd.Parameters.AddWithValue("SufrimientoFetal", obj.SufrimientoFetal);
                    cmd.Parameters.AddWithValue("Vaginal", obj.Vaginal);
                    cmd.Parameters.AddWithValue("Cesarea", obj.Cesarea);
                    cmd.Parameters.AddWithValue("EstadoNacer", obj.EstadoNacer);
                    cmd.Parameters.AddWithValue("Apgar", obj.Apgar);
                    cmd.Parameters.AddWithValue("SostenerCabeza", obj.SostenerCabeza);
                    cmd.Parameters.AddWithValue("Sonreir", obj.Sonreir);
                    cmd.Parameters.AddWithValue("RodarAlLado", obj.RodarAlLado);
                    cmd.Parameters.AddWithValue("SentarseSolo", obj.SentarseSolo);
                    cmd.Parameters.AddWithValue("Pararse", obj.Pararse);
                    cmd.Parameters.AddWithValue("Andar", obj.Andar);
                    cmd.Parameters.AddWithValue("CaminarSolo", obj.CaminarSolo);
                    cmd.Parameters.AddWithValue("Hablar", obj.Hablar);
                    cmd.Parameters.AddWithValue("Vacunaciones", obj.Vacunaciones);
                    cmd.Parameters.AddWithValue("Enfermedades", obj.Enfermedades);
                    cmd.Parameters.AddWithValue("AntecedentesQx", obj.AntecedentesQx);
                    cmd.Parameters.AddWithValue("Diagnosticos", obj.Diagnosticos);





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
        public bool EditarDiagnosticos(FichaHistorialClinica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Actualizar_Diagnosticos", oconexion);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", obj.IdHistorialClinica);                 
                    cmd.Parameters.AddWithValue("Diagnosticos", obj.Diagnosticos);





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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from FICHA_HISTORIAL_CLINICA where IdHistorialClinica = @id", oconexion);
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
                    Mensaje = "No se puede eliminar el historial clinica porque tiene registros relacionados en otras fichas.";
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
