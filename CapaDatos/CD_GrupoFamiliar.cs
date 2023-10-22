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
   public class CD_GrupoFamiliar
    {


        public List<GrupoFamiliar> Listar2(int IdFichaEstudioEconomico)
        {
            List<GrupoFamiliar> lista = new List<GrupoFamiliar>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("BUSCAR_TABLA_GRUPO_FAMILIAR", oconexion);
                    cmd.Parameters.AddWithValue("IdFichaEstudioEconomico", IdFichaEstudioEconomico);
                  

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new GrupoFamiliar()
                            {
                                IdGrupoFamiliar = Convert.ToInt32(dr["IdGrupoFamiliar"]),

                                nombre = dr["nombre"].ToString(),

                                eCivil = dr["eCivil"].ToString(),
                                relacion = dr["relacion"].ToString(),

                                edad = Convert.ToInt32(dr["edad"]),
                                escolaridad = dr["escolaridad"].ToString(),
                                ocupacion = dr["ocupacion"].ToString(),
                                salario = Convert.ToDecimal(dr["salario"]),
                                IdFichaEstudioEconomico = Convert.ToInt32(dr["IdFichaEstudioEconomico"]),
                                

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<GrupoFamiliar>();
            }

            return lista;

        }







        public BuscarGrupoFamiliar VerGrupoFamiliae (int IdFichaEstudioEconomico)
        {
            BuscarGrupoFamiliar objeto = new BuscarGrupoFamiliar();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("BUSCAR_TABLA_GRUPO_FAMILIAR", oconexion);
                    cmd.Parameters.AddWithValue("IdFichaEstudioEconomico", IdFichaEstudioEconomico);
             
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            objeto = new BuscarGrupoFamiliar()
                            {
                                IdGrupoFamiliar = Convert.ToInt32(dr["IdGrupoFamiliar"]),

                                nombre = dr["nombre"].ToString(),

                                eCivil = dr["eCivil"].ToString(),
                                relacion = dr["relacion"].ToString(),
                                
                                edad = Convert.ToInt32(dr["edad"]),
                                escolaridad = dr["escolaridad"].ToString(),
                                ocupacion = dr["ocupacion"].ToString(),
                                salario = Convert.ToDecimal(dr["salario"]),
                                IdFichaEstudioEconomico = Convert.ToInt32(dr["IdFichaEstudioEconomico"]),
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString()
                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objeto = new BuscarGrupoFamiliar();
                Console.WriteLine(ex.Message);
            }

            return objeto;
        }



        public int Registrar(GrupoFamiliar obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarGrupoFamiliar", oconexion);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@eCivil", obj.eCivil);
                    cmd.Parameters.AddWithValue("@relacion", obj.relacion);
                    cmd.Parameters.AddWithValue("@edad", obj.edad);
                    cmd.Parameters.AddWithValue("@escolaridad", obj.escolaridad);
                    cmd.Parameters.AddWithValue("@ocupacion", obj.ocupacion);
                    cmd.Parameters.AddWithValue("@salario", obj.salario);
                    cmd.Parameters.AddWithValue("@IdFichaEstudioEconomico", obj.IdFichaEstudioEconomico);


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


        public bool Editar(GrupoFamiliar obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarRegistroGrupoFamiliar", oconexion);
                    cmd.Parameters.AddWithValue("@IdGrupoFamiliar", obj.IdGrupoFamiliar);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@eCivil", obj.eCivil);
                    cmd.Parameters.AddWithValue("@relacion", obj.relacion);
                    cmd.Parameters.AddWithValue("@edad", obj.edad);
                    cmd.Parameters.AddWithValue("@escolaridad", obj.escolaridad);
                    cmd.Parameters.AddWithValue("@ocupacion", obj.ocupacion);
                    cmd.Parameters.AddWithValue("@salario", obj.salario);
                    cmd.Parameters.AddWithValue("@IdFichaEstudioEconomico", obj.IdFichaEstudioEconomico);



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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from GRUPO_FAMILAR where IdGrupoFamiliar = @id", oconexion);
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
