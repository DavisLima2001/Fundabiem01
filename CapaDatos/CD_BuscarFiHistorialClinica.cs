using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.IO;
/*hola mundo*/
namespace CapaDatos
{
    public   class CD_BuscarFiHistorialClinica
    {
        public BuscarFiHistorialClinica VerFiHistorialClinica(int IdHistorialClinica)
        {
            BuscarFiHistorialClinica objeto = new BuscarFiHistorialClinica();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("BuscarFICHA_HISTORIAL_CLINICA", oconexion);
                    cmd.Parameters.AddWithValue("IdHistorialClinica", IdHistorialClinica);
                   
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            objeto = new BuscarFiHistorialClinica()
                            {
                                IdHistorialClinica = Convert.ToInt32(dr["IdHistorialClinica"]),

                                Fecha = dr["Fecha"].ToString(),
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                               
                                Edad = Convert.ToInt32(dr["Edad"]),
                                Sexo = dr["Sexo"].ToString(),
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                



                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                PersonaEncargada = dr["PersonaEncargada"].ToString(),
                                MotivoConsulta = dr["MotivoConsulta"].ToString(),
                                AntecedentMadre = dr["AntecedentMadre"].ToString(),
                                e = dr["e"].ToString(),
                                ab = dr["ab"].ToString(),
                                HijosVivos = dr["HijosVivos"].ToString(),
                                EstadoSaludHv = dr["EstadoSaludHv"].ToString(),
                                HijosMuerteCausa = dr["HijosMuerteCausa"].ToString(),
                                Padres = dr["Padres"].ToString(),
                                Otros1 = dr["Otros1"].ToString(),
                                PesoNacer = dr["PesoNacer"].ToString(),
                                DuracionEmbarazo = dr["DuracionEmbarazo"].ToString(),
                                ProblemaGestional = dr["ProblemaGestional"].ToString(),
                                MedicinaDuranteEmbarazo = dr["MedicinaDuranteEmbarazo"].ToString(),
                                Tabaquismo = dr["Tabaquismo"].ToString(),
                                Alcohol = dr["Alcohol"].ToString(),
                                DuracionParto = dr["DuracionParto"].ToString(),
                                SufrimientoFetal = dr["SufrimientoFetal"].ToString(),
                                Vaginal = dr["Vaginal"].ToString(),
                                Cesarea = dr["Cesarea"].ToString(),
                                EstadoNacer = dr["EstadoNacer"].ToString(),
                                Apgar = dr["Apgar"].ToString(),
                                SostenerCabeza = dr["SostenerCabeza"].ToString(),
                                Sonreir = dr["Sonreir"].ToString(),
                                RodarAlLado = dr["RodarAlLado"].ToString(),
                                SentarseSolo = dr["SentarseSolo"].ToString(),
                                Pararse = dr["Pararse"].ToString(),
                                Andar = dr["Andar"].ToString(),
                                CaminarSolo = dr["CaminarSolo"].ToString(),
                                Hablar = dr["Hablar"].ToString(),
                                Vacunaciones = dr["Vacunaciones"].ToString(),
                                Enfermedades = dr["Enfermedades"].ToString(),
                                AntecedentesQx = dr["AntecedentesQx"].ToString(),
                                Diagnosticos = dr["Diagnosticos"].ToString()
                                
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new BuscarFiHistorialClinica();
            }

            return objeto;
        }
    }
}
