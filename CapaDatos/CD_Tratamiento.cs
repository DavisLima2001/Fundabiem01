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
  public  class CD_Tratamiento
    {


        public List<Tratamiento> Listar()
        {
            List<Tratamiento> lista = new List<Tratamiento>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "SELECT IdTablaTratamiento, fecha, tratamiento, duracion, no, ft, IdHistorialClinica FROM TAB_TRATAMIENTO";
                   
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Tratamiento()
                            {
                                IdTablaTratamiento = Convert.ToInt32(dr["IdTablaTratamiento"]),
                                fecha = dr["fecha"].ToString(),
                                tratamiento = dr["tratamiento"].ToString(),
                                duracion = dr["duracion"].ToString(),
                                no = Convert.ToInt32(dr["no"]),
                                ft = dr["ft"].ToString(),

                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),



                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Tratamiento>();
            }

            return lista;
        }



        public List<Tratamiento> Listar2(int IdHistorialClinica )
        {
            List<Tratamiento> lista = new List<Tratamiento>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("BUSCAR_TABLA_MEDICAMENTO", oconexion);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", IdHistorialClinica);
                   

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Tratamiento()
                            {
                                IdTablaTratamiento = Convert.ToInt32(dr["IdTablaTratamiento"]),
                                fecha = dr["fecha"].ToString(),
                                tratamiento = dr["tratamiento"].ToString(),
                                duracion = dr["duracion"].ToString(),
                                no = Convert.ToInt32(dr["no"]),
                                ft = dr["ft"].ToString(),

                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Tratamiento>();
            }

            return lista;

        }


        public int Registrar(Tratamiento obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarTratamiento", oconexion);
                    cmd.Parameters.AddWithValue("tratamiento", obj.tratamiento);
                    cmd.Parameters.AddWithValue("duracion", obj.duracion);
                    cmd.Parameters.AddWithValue("no", obj.no);
                    cmd.Parameters.AddWithValue("ft", obj.ft);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", obj.IdHistorialClinica);

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


        public bool Editar(Tratamiento obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarTratamiento", oconexion);
                    cmd.Parameters.AddWithValue("IdTablaTratamiento", obj.IdTablaTratamiento);
                    cmd.Parameters.AddWithValue("tratamiento", obj.tratamiento);
                    cmd.Parameters.AddWithValue("duracion", obj.duracion);
                    cmd.Parameters.AddWithValue("no", obj.no);
                    cmd.Parameters.AddWithValue("ft", obj.ft);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", obj.IdHistorialClinica);



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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from TAB_TRATAMIENTO where IdTablaTratamiento= @id", oconexion);
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
