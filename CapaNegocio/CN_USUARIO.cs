using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
  public  class CN_USUARIO
    {
        private CD_USUARIO objCapaDato = new CD_USUARIO();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdUsuario != 0)
            {
                Mensaje = "Error, para poder guardar un usuario el formulario tiene que estar limpio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "El primer apellido no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "El segundo apellido no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "El primer nombre no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Sexo) || string.IsNullOrWhiteSpace(obj.Sexo))
            {
                Mensaje = "El sexo no puede ser vacio";
            }
            else if (obj.Edad == 0)
            {
                Mensaje = "la edad no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.FechaNacimiento) || string.IsNullOrWhiteSpace(obj.FechaNacimiento))
            {
                Mensaje = "La fecha de nacimiento no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.GrupoTecnico) || string.IsNullOrWhiteSpace(obj.GrupoTecnico))
            {
                Mensaje = "El grupo tecnico no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Otros) || string.IsNullOrWhiteSpace(obj.Otros))
            {
                Mensaje = "Otros no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion2) || string.IsNullOrWhiteSpace(obj.Direccion2))
            {
                Mensaje = "La direccion no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Departamento) || string.IsNullOrWhiteSpace(obj.Departamento))
            {
                Mensaje = "El departamento no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Ciudad) || string.IsNullOrWhiteSpace(obj.Ciudad))
            {
                Mensaje = "La ciudad  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "El pais no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Residencia) || string.IsNullOrWhiteSpace(obj.Residencia))
            {
                Mensaje = "La residencia no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Lugar) || string.IsNullOrWhiteSpace(obj.Lugar))
            {
                Mensaje = "El lugar no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Padre) || string.IsNullOrWhiteSpace(obj.Padre))
            {
                Mensaje = "El padre no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Madre) || string.IsNullOrWhiteSpace(obj.Madre))
            {
                Mensaje = "La madre no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.PersonaEncargada) || string.IsNullOrWhiteSpace(obj.PersonaEncargada))
            {
                Mensaje = "La persona encargada no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "La direccion no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "El telefono no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Firma) || string.IsNullOrWhiteSpace(obj.Firma))
            {
                Mensaje = "La firma no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.DiagnosticoFinal) || string.IsNullOrWhiteSpace(obj.DiagnosticoFinal))
            {
                Mensaje = "El diagnostico final no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Recomendaciones) || string.IsNullOrWhiteSpace(obj.Recomendaciones))
            {
                Mensaje = "Las recomendaciones no puede estar vacias";
            }


        




            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {


                return 0;
            }

        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = String.Empty;


            if (obj.IdUsuario == 0)
            {
                Mensaje = "Para actualizar un usuario tienes que buscarlo";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "El primer apellido no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "El segundo apellido no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "El primer nombre no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Sexo) || string.IsNullOrWhiteSpace(obj.Sexo))
            {
                Mensaje = "El sexo no puede ser vacio";
            }
            else if (obj.Edad == 0)
            {
                Mensaje = "la edad no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.FechaNacimiento) || string.IsNullOrWhiteSpace(obj.FechaNacimiento))
            {
                Mensaje = "La fecha de nacimiento no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.GrupoTecnico) || string.IsNullOrWhiteSpace(obj.GrupoTecnico))
            {
                Mensaje = "El grupo tecnico no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Otros) || string.IsNullOrWhiteSpace(obj.Otros))
            {
                Mensaje = "Otros no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion2) || string.IsNullOrWhiteSpace(obj.Direccion2))
            {
                Mensaje = "La direccion no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Departamento) || string.IsNullOrWhiteSpace(obj.Departamento))
            {
                Mensaje = "El departamento no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Ciudad) || string.IsNullOrWhiteSpace(obj.Ciudad))
            {
                Mensaje = "La ciudad  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "El pais no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Residencia) || string.IsNullOrWhiteSpace(obj.Residencia))
            {
                Mensaje = "La residencia no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Lugar) || string.IsNullOrWhiteSpace(obj.Lugar))
            {
                Mensaje = "El lugar no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Padre) || string.IsNullOrWhiteSpace(obj.Padre))
            {
                Mensaje = "El padre no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Madre) || string.IsNullOrWhiteSpace(obj.Madre))
            {
                Mensaje = "La madre no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.PersonaEncargada) || string.IsNullOrWhiteSpace(obj.PersonaEncargada))
            {
                Mensaje = "La persona encargada no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "La direccion no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "El telefono no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Firma) || string.IsNullOrWhiteSpace(obj.Firma))
            {
                Mensaje = "La firma no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.DiagnosticoFinal) || string.IsNullOrWhiteSpace(obj.DiagnosticoFinal))
            {
                Mensaje = "El diagnostico final no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Recomendaciones) || string.IsNullOrWhiteSpace(obj.Recomendaciones))
            {
                Mensaje = "Las recomendaciones no puede estar vacias";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }





    }
}
