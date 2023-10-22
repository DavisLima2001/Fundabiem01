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
  public  class CD_TablaEvolucionMedica
    {

        public List<TablaEvolucionMedica> Listar()
        {
            List<TablaEvolucionMedica> lista = new List<TablaEvolucionMedica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select  IdTablaEvolucionMedica, columna1, columna2,IdFichaEvolucionMedica from TABLA_EVOLUCION_MEDICA";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TablaEvolucionMedica()
                            {
                                IdTablaEvolucionMedica = Convert.ToInt32(dr["IdTablaEvolucionMedica"]),
                                columna1 = dr["columna1"].ToString(),
                                columna2 = dr["columna2"].ToString(),
                             
                               
                                IdFichaEvolucionMedica = Convert.ToInt32(dr["IdFichaEvolucionMedica"]),



                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TablaEvolucionMedica>();
            }

            return lista;
        }


        public List<TablaEvolucionMedica> Listar2(int IdFichaEvolucionMedica)
        {
            List<TablaEvolucionMedica> lista = new List<TablaEvolucionMedica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("BUSCAR_TABLA_EVOLUCION_MEDICA", oconexion);
                    cmd.Parameters.AddWithValue("IdFichaEvolucionMedica", IdFichaEvolucionMedica);
                    

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TablaEvolucionMedica()
                            {
                                IdTablaEvolucionMedica = Convert.ToInt32(dr["IdTablaEvolucionMedica"]),
                                columna1 = dr["columna1"].ToString(),
                                columna2 = dr["columna2"].ToString(),
                              

                                IdFichaEvolucionMedica = Convert.ToInt32(dr["IdFichaEvolucionMedica"])

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TablaEvolucionMedica>();
            }

            return lista;

        }


        public int Registrar(TablaEvolucionMedica obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("IngresarTablaEvolutiva", oconexion);
                    cmd.Parameters.AddWithValue("@columna1", obj.columna1);
                    cmd.Parameters.AddWithValue("@columna2", obj.columna2);
                    cmd.Parameters.AddWithValue("@IdFichaEvolucionMedica", obj.IdFichaEvolucionMedica);
                   
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


        public bool Editar(TablaEvolucionMedica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("actualizarTablaEvoMedica", oconexion);
                    cmd.Parameters.AddWithValue("IdTablaEvolucionMedica", obj.IdTablaEvolucionMedica);
                    cmd.Parameters.AddWithValue("columna1", obj.columna1);
                    cmd.Parameters.AddWithValue("columna2", obj.columna2);
                    cmd.Parameters.AddWithValue("IdFichaEvolucionMedica", obj.IdFichaEvolucionMedica);
                



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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from TABLA_EVOLUCION_MEDICA where IdTablaEvolucionMedica= @id", oconexion);
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
