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
   public class CD_TablaEvolucionTecnica
    {

        public List<TablaEvolucionTecnica> Listar()
        {
            List<TablaEvolucionTecnica> lista = new List<TablaEvolucionTecnica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select  IdTablaEvolucionTecnica, columna1, columna2,IdFichaEvolucionTecnica from TABLA_EVOLUCION_TECNICA";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TablaEvolucionTecnica()
                            {
                                IdTablaEvolucionTecnica = Convert.ToInt32(dr["IdTablaEvolucionTecnica"]),
                                columna1 = dr["columna1"].ToString(),
                                columna2 = dr["columna2"].ToString(),


                                IdFichaEvolucionTecnica = Convert.ToInt32(dr["IdFichaEvolucionTecnica"]),



                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TablaEvolucionTecnica>();
            }

            return lista;
        }


        public List<TablaEvolucionTecnica> Listar2(int IdFichaEvolucionTecnica)
        {
            List<TablaEvolucionTecnica> lista = new List<TablaEvolucionTecnica>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("BUSCAR_TABLA_EVOLUCION_Tecnica", oconexion);
                    cmd.Parameters.AddWithValue("IdFichaEvolucionTecnica", IdFichaEvolucionTecnica);


                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TablaEvolucionTecnica()
                            {
                                IdTablaEvolucionTecnica = Convert.ToInt32(dr["IdTablaEvolucionTecnica"]),
                                columna1 = dr["columna1"].ToString(),
                                columna2 = dr["columna2"].ToString(),


                                IdFichaEvolucionTecnica = Convert.ToInt32(dr["IdFichaEvolucionTecnica"])

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<TablaEvolucionTecnica>();
            }

            return lista;

        }

        public int Registrar(TablaEvolucionTecnica obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("IngresarTablaEvolutivaTecnica", oconexion);
                    cmd.Parameters.AddWithValue("@columna2", obj.columna2);
                    cmd.Parameters.AddWithValue("@columna1", obj.columna1);
                    cmd.Parameters.AddWithValue("@IdFichaEvolucionTecnica", obj.IdFichaEvolucionTecnica);

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
        public bool Editar(TablaEvolucionTecnica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("actualizarTablaEvoTecnica", oconexion);
                    cmd.Parameters.AddWithValue("IdTablaEvolucionTecnica", obj.IdTablaEvolucionTecnica);
                    cmd.Parameters.AddWithValue("columna1", obj.columna1);
                    cmd.Parameters.AddWithValue("columna2", obj.columna2);
                    cmd.Parameters.AddWithValue("IdFichaEvolucionTecnica", obj.IdFichaEvolucionTecnica);




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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from TABLA_EVOLUCION_TECNICA where IdTablaEvolucionTecnica= @id", oconexion);
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
