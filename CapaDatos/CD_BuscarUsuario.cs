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
   public class CD_BuscarUsuario
    {
        public  BuscarUsuario VerUsuario(string PrimerApellido,string PrimerNombre) 
        {
            BuscarUsuario objeto = new BuscarUsuario();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("BuscarUsuarioPorId", oconexion);
                    cmd.Parameters.AddWithValue("PrimerApellido", PrimerApellido);
                    cmd.Parameters.AddWithValue("PrimerNombre", PrimerNombre);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new BuscarUsuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),

                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                SegundoNombre = dr["SegundoNombre"].ToString(),
                                Sexo = dr["Sexo"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                FechaNacimiento = dr["FechaNacimiento"].ToString(),
                                GrupoTecnico = dr["GrupoTecnico"].ToString(),
                                Otros = dr["Otros"].ToString(),
                                Direccion2 = dr["Direccion2"].ToString(),
                                Departamento = dr["Departamento"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                Pais = dr["Pais"].ToString(),
                                Residencia = dr["Residencia"].ToString(),
                                Lugar = dr["Lugar"].ToString(),
                                Padre = dr["Padre"].ToString(),
                                Madre = dr["Madre"].ToString(),
                                PersonaEncargada = dr["PersonaEncargada"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Firma = dr["Firma"].ToString(),
                                FechaHoraAdmicion = dr["FechaHoraAdmicion"].ToString(),
                                DiagnosticoFinal = dr["DiagnosticoFinal"].ToString(),
                                Recomendaciones = dr["Recomendaciones"].ToString(),
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = null;
            }

            return objeto;
        }


    }
}
