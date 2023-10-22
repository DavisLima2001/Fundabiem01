using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
 public   class CD_TablaEstadistica
    {
        public List<BuscarTablaEstadistica> Listar2(string FechaRegistro)
        {
            List<BuscarTablaEstadistica> lista = new List<BuscarTablaEstadistica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("BuscarTablaEstadisctica", oconexion);
                    cmd.Parameters.AddWithValue("FechaRegistro", FechaRegistro);


                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new BuscarTablaEstadistica()
                            {
                                IdTabEstadistica = Convert.ToInt32(dr["IdTabEstadistica"]),
                                no = Convert.ToInt32(dr["no"]),
                                Nombre = dr["Nombre"].ToString(),                            
                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),
                                Edad = dr["Edad"].ToString(),

                                Sexo = dr["Sexo"].ToString(),
                                Procedencia = dr["Procedencia"].ToString(),
                                Consulta = dr["Consulta"].ToString(),
                                Diagnostico = dr["Diagnostico"].ToString(),
                                ConsTras = dr["ConsTras"].ToString(),
                                RaOrtesis = dr["RaOrtesis"].ToString(),
                                Comentario = dr["Comentario"].ToString(),
                                

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<BuscarTablaEstadistica>();
            }

            return lista;

        }

        public List<BuscarTablaEstadistica> Listar3(string FechaInicio, string FechaFin)
        {
            List<BuscarTablaEstadistica> lista = new List<BuscarTablaEstadistica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("BuscarEstaDiaXFechaInicioFin", oconexion);
                    cmd.Parameters.AddWithValue("FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", FechaFin);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new BuscarTablaEstadistica()
                            {
                                IdTabEstadistica = Convert.ToInt32(dr["IdTabEstadistica"]),
                                no = Convert.ToInt32(dr["no"]),

                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),
                                Edad = dr["Edad"].ToString(),

                                Sexo = dr["Sexo"].ToString(),
                                Procedencia = dr["Procedencia"].ToString(),
                                Consulta = dr["Consulta"].ToString(),
                                Diagnostico = dr["Diagnostico"].ToString(),
                                ConsTras = dr["ConsTras"].ToString(),
                                RaOrtesis = dr["RaOrtesis"].ToString(),
                                Comentario = dr["Comentario"].ToString(),


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<BuscarTablaEstadistica>();
            }

            return lista;

        }

        public int Registrar(TablaEstadistica obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarTabEstadistica", oconexion);
                    cmd.Parameters.AddWithValue("no", obj.no);
                    cmd.Parameters.AddWithValue("IdEstadisticaDiaria", obj.IdEstadisticaDiaria);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", obj.OFichaHistorialClinica.IdHistorialClinica);
                    cmd.Parameters.AddWithValue("Diagnostico", obj.Diagnostico);
                    cmd.Parameters.AddWithValue("Consulta", obj.Consulta);
                    cmd.Parameters.AddWithValue("ConsTras", obj.ConsTras);
                    cmd.Parameters.AddWithValue("RaOrtesis", obj.RaOrtesis);
                    cmd.Parameters.AddWithValue("Comentario", obj.Comentario);
                 

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


        public bool Editar(TablaEstadistica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarTabEstadistica", oconexion);
                    cmd.Parameters.AddWithValue("IdTabEstadistica", obj.IdTabEstadistica);
                    cmd.Parameters.AddWithValue("no", obj.no);
                    cmd.Parameters.AddWithValue("IdEstadisticaDiaria", obj.IdEstadisticaDiaria);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", obj.OFichaHistorialClinica.IdHistorialClinica);
                    cmd.Parameters.AddWithValue("Diagnostico", obj.Diagnostico);
                    cmd.Parameters.AddWithValue("Consulta", obj.Consulta);
                    cmd.Parameters.AddWithValue("ConsTras", obj.ConsTras);
                    cmd.Parameters.AddWithValue("RaOrtesis", obj.RaOrtesis);
                    cmd.Parameters.AddWithValue("Comentario", obj.Comentario);



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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from TAB_ESTADISTICA where IdTabEstadistica= @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
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
