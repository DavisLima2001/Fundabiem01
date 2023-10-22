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
   public class CD_FichaEvolucionMedica
    {

        public List<BuscarFichaEvolucionMedica2> Listar()
        {
            List<BuscarFichaEvolucionMedica2> lista = new List<BuscarFichaEvolucionMedica2>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT  f.IdFichaEvolucionMedica,f.fechaRegistro,  u.PrimerApellido+' '+ u. SegundoApellido+' '+u.PrimerNombre+' '+ u.SegundoNombre nombre, fh.IdHistorialClinica , ");
                    sb.AppendLine("f.Diagnostico");
                    sb.AppendLine("FROM FICHA_EVOLUCION_MEDICA f ");
                    sb.AppendLine("inner join FICHA_HISTORIAL_CLINICA fh on fh.IdHistorialClinica = f.IdHistorialClinica");
                    sb.AppendLine("inner join USUARIO u on u.IdUsuario = fh.IdUsuario");
                    sb.AppendLine("order by f.IdFichaEvolucionMedica DESC");
                    
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new BuscarFichaEvolucionMedica2()
                            {
                                IdFichaEvolucionMedica = Convert.ToInt32(dr["IdFichaEvolucionMedica"]),
                                fechaRegistro = dr["fechaRegistro"].ToString(),
                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),
                          
                                PrimerNombre = dr["nombre"].ToString(),
                                
                              
                                Diagnostico = dr["Diagnostico"].ToString()










                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<BuscarFichaEvolucionMedica2>();
            }

            return lista;
        }







        public BuscarFichaEvolucionMedica2 VerFichaEvolucionMedica2(int IdFichaEvolucionMedica)
        {
            BuscarFichaEvolucionMedica2 objeto = new BuscarFichaEvolucionMedica2();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("BUSCAR_FICHA_EVOLUCION_MEDICA", oconexion);
                    cmd.Parameters.AddWithValue("IdFichaEvolucionMedica", IdFichaEvolucionMedica);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            objeto = new BuscarFichaEvolucionMedica2()
                            {
                                IdFichaEvolucionMedica = Convert.ToInt32(dr["IdFichaEvolucionMedica"]),
                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                SegundoNombre = dr["SegundoNombre"].ToString(),
                                Sexo = dr["Sexo"].ToString(),
                                Diagnostico = dr["Diagnostico"].ToString()


                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objeto = new BuscarFichaEvolucionMedica2();
                Console.WriteLine(ex.Message);
            }

            return objeto;
        }








        public BuscarFichaEvolucionMedica VerFichaEvolucionMedica(int IdHistorialClinica)
        {
            BuscarFichaEvolucionMedica objeto = new BuscarFichaEvolucionMedica();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("BUSCAR_HISTORIAL", oconexion);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", IdHistorialClinica);
                  
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            objeto = new BuscarFichaEvolucionMedica()
                            {
                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                SegundoNombre = dr["SegundoNombre"].ToString(),
                                Sexo = dr["Sexo"].ToString(),
                                //Diagnosticos = dr["Diagnosticos"].ToString()


                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objeto = new BuscarFichaEvolucionMedica();
                Console.WriteLine(ex.Message);
            }

            return objeto;
        }



        public int Registrar(FichaEvolucionMedica obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("IngresarEvolucionMedica", oconexion);
                    cmd.Parameters.AddWithValue("@IdHistorialClinica", obj.IdHistorialClinica);

                    cmd.Parameters.AddWithValue("@Diagnostico", obj.Diagnostico);

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




        public bool Editar(FichaEvolucionMedica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_EVOLUCION_MEDICA", oconexion);
                    cmd.Parameters.AddWithValue("@IdFichaEvolucionMedica", obj.IdFichaEvolucionMedica);
                    cmd.Parameters.AddWithValue("@Diagnostico", obj.Diagnostico);
                    cmd.Parameters.AddWithValue("@IdHistorialClinica", obj.IdHistorialClinica);
                   



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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from FICHA_EVOLUCION_MEDICA where IdFichaEvolucionMedica = @id", oconexion);
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
                    Mensaje = "No se puede eliminar la ficha porque evoluciones asignadas";
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
