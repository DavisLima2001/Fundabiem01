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
  public  class CD_FichaEstudiSocioeconomico
    {


        public List<HistorialFichasEstudio> ListarHistorial()
        {
            List<HistorialFichasEstudio> lista = new List<HistorialFichasEstudio>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "SELECT f.IdFichaEstudioEconomico,FORMAT(f.fechaIngreso, 'yyyy-MM-dd') as fechaIngreso, u.PrimerNombre+' ' +u.SegundoNombre+' '+u.PrimerApellido+' '+u.SegundoApellido  nombre,f.atendidoPor FROM FICHA_ESTUDIO_ECONOMICO f inner join USUARIO u on u.IdUsuario =f.IdUsuario order by f.IdFichaEstudioEconomico desc";



                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new HistorialFichasEstudio()
                            {
                                IdFichaEstudioEconomico = Convert.ToInt32(dr["IdFichaEstudioEconomico"]),
                                fechaIngreso = dr["fechaIngreso"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                atendidoPor = dr["atendidoPor"].ToString(),





                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<HistorialFichasEstudio>();
            }

            return lista;
        }



        public BuscarFichaEstudio VerFiHaEstudio(int IdFichaEstudioEconomico)
        {
            BuscarFichaEstudio objeto = new BuscarFichaEstudio();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("BUSCAR_FICHA_ESTUDIO", oconexion);
                    cmd.Parameters.AddWithValue("IdFichaEstudioEconomico", IdFichaEstudioEconomico);
              
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            objeto = new BuscarFichaEstudio()
                            {
                            IdFichaEstudioEconomico = Convert.ToInt32(dr["IdFichaEstudioEconomico"]),
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                Direccion2 = dr["Direccion2"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                Sexo = dr["Sexo"].ToString(),
                              
                                FechaNacimiento = dr["FechaNacimiento"].ToString(),
                               
                                regMedicoNo = dr["regMedicoNo"].ToString(),
                            regSocialNo = dr["regSocialNo"].ToString(),
                            fechaIngreso = dr["fechaIngreso"].ToString(),
                            fechaEntrevista = dr["fechaEntrevista"].ToString(),
                            tsEntrevisto = dr["tsEntrevisto"].ToString(),
                            evaluo = dr["evaluo"].ToString(),
                            escolaridad = dr["escolaridad"].ToString(),
                            permanente = dr["permanente"].ToString(),
                            temporal = dr["temporal"].ToString(),
                            atendidoPor = dr["atendidoPor"].ToString(),
                            religion = dr["religion"].ToString(),
                            dxMedico = dr["dxMedico"].ToString(),
                            servicio = dr["servicio"].ToString(),
                            ft = dr["ft"].ToString(),
                            Pscina = dr["Pscina"].ToString(),
                            t_o = dr["t_o"].ToString(),
                            tl = dr["tl"].ToString(),
                            ee = dr["ee"].ToString(),
                            escuela = dr["escuela"].ToString(),
                                pSicol = dr["pSicol"].ToString(),
                                
                            indCasa = dr["indCasa"].ToString(),
                            motivoSolicitud = dr["motivoSolicitud"].ToString(),
                            paredes = dr["paredes"].ToString(),
                            techo = dr["techo"].ToString(),
                            pisos = dr["pisos"].ToString(),
                            noHabitaciones = dr["noHabitaciones"].ToString(),
                            agua = dr["agua"].ToString(),
                            luzeElectrica = dr["luzeElectrica"].ToString(),
                            servicioSanitario = dr["servicioSanitario"].ToString(),
                            letrina = dr["letrina"].ToString(),
                            otros1 = dr["otros1"].ToString(),
                            cosinaFuera = dr["cosinaFuera"].ToString(),
                            esPropia = dr["esPropia"].ToString(),
                            prestada = dr["prestada"].ToString(),
                            alquila = dr["alquila"].ToString(),
                            otros2 = dr["otros2"].ToString(),
                            pagoMensual = dr["pagoMensual"].ToString(),
                            diagnosticoSocial = dr["diagnosticoSocial"].ToString(),
                            opinionTS = dr["opinionTS"].ToString(),
                            observaciones = dr["observaciones"].ToString(),

                        };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objeto = new BuscarFichaEstudio();
                Console.WriteLine(ex.Message);
            }

            return objeto;
        }






            //public int Registrar(FichaEstudioSocioeconomico obj, out string Mensaje)
            //{
            //    int idautogenerado = 0;

            //    Mensaje = string.Empty;
            //    try
            //    {

            //        using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
            //        {
            //            SqlCommand cmd = new SqlCommand("InsertarFichaEstudioEconomico", oconexion);
            //            cmd.Parameters.AddWithValue("@idUsuario", obj.IdUsuario);
            //            cmd.Parameters.AddWithValue("@regMedicoNo", obj.regMedicoNo);
            //            cmd.Parameters.AddWithValue("@regSocialNo", obj.regSocialNo);
            //            cmd.Parameters.AddWithValue("@fechaIngreso", obj.fechaIngreso);
            //            cmd.Parameters.AddWithValue("@fechaEntrevista", obj.fechaEntrevista);
            //            cmd.Parameters.AddWithValue("@tsEntrevisto", obj.tsEntrevisto);
            //            cmd.Parameters.AddWithValue("@evaluo", obj.evaluo);
            //            cmd.Parameters.AddWithValue("@escolaridad", obj.escolaridad);
            //            cmd.Parameters.AddWithValue("@permanente", obj.permanente);
            //            cmd.Parameters.AddWithValue("@temporal", obj.temporal);
            //            cmd.Parameters.AddWithValue("@atendidoPor", obj.atendidoPor);
            //            cmd.Parameters.AddWithValue("@religion", obj.religion);
            //            cmd.Parameters.AddWithValue("@dxMedico", obj.dxMedico);
            //            cmd.Parameters.AddWithValue("@servicio", obj.servicio);
            //            cmd.Parameters.AddWithValue("@ft", obj.ft);
            //            cmd.Parameters.AddWithValue("@Pscina", obj.Pscina);
            //            cmd.Parameters.AddWithValue("@t_o", obj.t_o);
            //            cmd.Parameters.AddWithValue("@tl", obj.tl);
            //            cmd.Parameters.AddWithValue("@ee", obj.ee);
            //            cmd.Parameters.AddWithValue("@escuela", obj.escuela);
            //            cmd.Parameters.AddWithValue("@indCasa", obj.indCasa);
            //            cmd.Parameters.AddWithValue("@motivoSolicitud", obj.motivoSolicitud);
            //            cmd.Parameters.AddWithValue("@paredes", obj.paredes);
            //            cmd.Parameters.AddWithValue("@techo", obj.techo);
            //            cmd.Parameters.AddWithValue("@pisos", obj.pisos);
            //            cmd.Parameters.AddWithValue("@noHabitaciones", obj.noHabitaciones);
            //            cmd.Parameters.AddWithValue("@agua", obj.agua);
            //            cmd.Parameters.AddWithValue("@luzeElectrica", obj.luzeElectrica);
            //            cmd.Parameters.AddWithValue("@servicioSanitario", obj.servicioSanitario);
            //            cmd.Parameters.AddWithValue("@letrina", obj.letrina);
            //            cmd.Parameters.AddWithValue("@otros1", obj.otros1);
            //            cmd.Parameters.AddWithValue("@cosinaFuera", obj.cosinaFuera);
            //            cmd.Parameters.AddWithValue("@esPropia", obj.esPropia);
            //            cmd.Parameters.AddWithValue("@prestada", obj.prestada);
            //            cmd.Parameters.AddWithValue("@alquila", obj.alquila);
            //            cmd.Parameters.AddWithValue("@otros2", obj.otros2);
            //            cmd.Parameters.AddWithValue("@pagoMensual", obj.pagoMensual);
            //            cmd.Parameters.AddWithValue("@diagnosticoSocial", obj.diagnosticoSocial);
            //            cmd.Parameters.AddWithValue("@opinionTS", obj.opinionTS);
            //            cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                  

            //            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            //            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            oconexion.Open();

            //            cmd.ExecuteNonQuery();

            //            idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
            //            Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        idautogenerado = 0;
            //        Mensaje = ex.Message;
            //    }
            //    return idautogenerado;
            //}




        public int Registrar(FichaEstudioSocioeconomico obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {


                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarFichaEstudioEconomico", oconexion);




                    cmd.Parameters.AddWithValue("@idUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@regMedicoNo", obj.regMedicoNo);
                    cmd.Parameters.AddWithValue("@regSocialNo", obj.regSocialNo);
                    cmd.Parameters.AddWithValue("@fechaIngreso", obj.fechaIngreso);
                    cmd.Parameters.AddWithValue("@fechaEntrevista", obj.fechaEntrevista);
                    cmd.Parameters.AddWithValue("@tsEntrevisto", obj.tsEntrevisto);
                    cmd.Parameters.AddWithValue("@evaluo", obj.evaluo);
                    cmd.Parameters.AddWithValue("@escolaridad", obj.escolaridad);
                    cmd.Parameters.AddWithValue("@permanente", obj.permanente);
                    cmd.Parameters.AddWithValue("@temporal", obj.temporal);
                    cmd.Parameters.AddWithValue("@atendidoPor", obj.atendidoPor);
                    cmd.Parameters.AddWithValue("@religion", obj.religion);
                    cmd.Parameters.AddWithValue("@dxMedico", obj.dxMedico);
                    cmd.Parameters.AddWithValue("@servicio", obj.servicio);
                    cmd.Parameters.AddWithValue("@ft", obj.ft);
                    cmd.Parameters.AddWithValue("@Pscina", obj.Pscina);
                    cmd.Parameters.AddWithValue("@t_o", obj.t_o);
                    cmd.Parameters.AddWithValue("@tl", obj.tl);
                    cmd.Parameters.AddWithValue("@ee", obj.ee);
                    cmd.Parameters.AddWithValue("@escuela", obj.escuela); 
                    cmd.Parameters.AddWithValue("@pSicol", obj.pSicol);
                    cmd.Parameters.AddWithValue("@indCasa", obj.indCasa);
                    cmd.Parameters.AddWithValue("@motivoSolicitud", obj.motivoSolicitud);
                    cmd.Parameters.AddWithValue("@paredes", obj.paredes);
                    cmd.Parameters.AddWithValue("@techo", obj.techo);
                    cmd.Parameters.AddWithValue("@pisos", obj.pisos);
                    cmd.Parameters.AddWithValue("@noHabitaciones", obj.noHabitaciones);
                    cmd.Parameters.AddWithValue("@agua", obj.agua);
                    cmd.Parameters.AddWithValue("@luzeElectrica", obj.luzeElectrica);
                    cmd.Parameters.AddWithValue("@servicioSanitario", obj.servicioSanitario);
                    cmd.Parameters.AddWithValue("@letrina", obj.letrina);
                    cmd.Parameters.AddWithValue("@otros1", obj.otros1);
                    cmd.Parameters.AddWithValue("@cosinaFuera", obj.cosinaFuera);
                    cmd.Parameters.AddWithValue("@esPropia", obj.esPropia);
                    cmd.Parameters.AddWithValue("@prestada", obj.prestada);
                    cmd.Parameters.AddWithValue("@alquila", obj.alquila);
                    cmd.Parameters.AddWithValue("@otros2", obj.otros2);
                    cmd.Parameters.AddWithValue("@pagoMensual", obj.pagoMensual);
                    cmd.Parameters.AddWithValue("@diagnosticoSocial", obj.diagnosticoSocial);
                    cmd.Parameters.AddWithValue("@opinionTS", obj.opinionTS);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);

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
                        Mensaje = "Error en los campos fecha. Utilice el formato yyyy/mm/dd.";
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
























        public bool Editar(FichaEstudioSocioeconomico obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarRegistroFichaEstudioEconomico", oconexion);
                    cmd.Parameters.AddWithValue("@IdFichaEstudioEconomico", obj.IdFichaEstudioEconomico);
                    cmd.Parameters.AddWithValue("@idUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@regMedicoNo", obj.regMedicoNo);
                    cmd.Parameters.AddWithValue("@regSocialNo", obj.regSocialNo);
                    cmd.Parameters.AddWithValue("@fechaIngreso", obj.fechaIngreso);
                    cmd.Parameters.AddWithValue("@fechaEntrevista", obj.fechaEntrevista);
                    cmd.Parameters.AddWithValue("@tsEntrevisto", obj.tsEntrevisto);
                    cmd.Parameters.AddWithValue("@evaluo", obj.evaluo);
                    cmd.Parameters.AddWithValue("@escolaridad", obj.escolaridad);
                    cmd.Parameters.AddWithValue("@permanente", obj.permanente);
                    cmd.Parameters.AddWithValue("@temporal", obj.temporal);
                    cmd.Parameters.AddWithValue("@atendidoPor", obj.atendidoPor);
                    cmd.Parameters.AddWithValue("@religion", obj.religion);
                    cmd.Parameters.AddWithValue("@dxMedico", obj.dxMedico);
                    cmd.Parameters.AddWithValue("@servicio", obj.servicio);
                    cmd.Parameters.AddWithValue("@ft", obj.ft);
                    cmd.Parameters.AddWithValue("@Pscina", obj.Pscina);
                    cmd.Parameters.AddWithValue("@t_o", obj.t_o);
                    cmd.Parameters.AddWithValue("@tl", obj.tl);
                    cmd.Parameters.AddWithValue("@ee", obj.ee);
                    cmd.Parameters.AddWithValue("@escuela", obj.escuela);
                    cmd.Parameters.AddWithValue("@pSicol", obj.pSicol);
                    cmd.Parameters.AddWithValue("@indCasa", obj.indCasa);
                    cmd.Parameters.AddWithValue("@motivoSolicitud", obj.motivoSolicitud);
                    cmd.Parameters.AddWithValue("@paredes", obj.paredes);
                    cmd.Parameters.AddWithValue("@techo", obj.techo);
                    cmd.Parameters.AddWithValue("@pisos", obj.pisos);
                    cmd.Parameters.AddWithValue("@noHabitaciones", obj.noHabitaciones);
                    cmd.Parameters.AddWithValue("@agua", obj.agua);
                    cmd.Parameters.AddWithValue("@luzeElectrica", obj.luzeElectrica);
                    cmd.Parameters.AddWithValue("@servicioSanitario", obj.servicioSanitario);
                    cmd.Parameters.AddWithValue("@letrina", obj.letrina);
                    cmd.Parameters.AddWithValue("@otros1", obj.otros1);
                    cmd.Parameters.AddWithValue("@cosinaFuera", obj.cosinaFuera);
                    cmd.Parameters.AddWithValue("@esPropia", obj.esPropia);
                    cmd.Parameters.AddWithValue("@prestada", obj.prestada);
                    cmd.Parameters.AddWithValue("@alquila", obj.alquila);
                    cmd.Parameters.AddWithValue("@otros2", obj.otros2);
                    cmd.Parameters.AddWithValue("@pagoMensual", obj.pagoMensual);
                    cmd.Parameters.AddWithValue("@diagnosticoSocial", obj.diagnosticoSocial);
                    cmd.Parameters.AddWithValue("@opinionTS", obj.opinionTS);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);




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
                        Mensaje = "Error en los campos fecha. Utilice el formato yyyy/mm/dd.";
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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from FICHA_ESTUDIO_ECONOMICO where IdFichaEstudioEconomico = @id", oconexion);
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
                    Mensaje = "No se puede eliminar el usuario porque tiene registros en la tabla grupo familiar";
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
