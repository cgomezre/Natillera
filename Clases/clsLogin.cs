using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Examen3.Models;

namespace Examen3.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }

        public NATILLERAEntities dbNatilla = new NATILLERAEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }

        private bool ValidarUsuario()
        {
            try
            {
                Administrador administrador = dbNatilla.Administradors
                    .FirstOrDefault(u => u.Usuario == login.Usuario);
                if (administrador == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Administrador no existe";
                    return false;
                }

                login.Clave = administrador.Clave;
                return true;

            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = "Algo fallo, el error es: " + ex.Message;
                return false;
            }
        }

        private bool ValidarClave()
        {
            try
            {
                if (login.Clave != login.Clave)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = "Algo fallo al validar contraseña" + ex.Message;
                return false;
            }
        }

        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from A in dbNatilla.Administradors
                       where A.Usuario == login.Usuario && A.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = A.Usuario,
                           Autenticado = true,
                           Perfil = "Administrador",
                           PaginaInicio = "/Evento",
                           Token = token,
                           Mensaje = " "
                       };
            }
            else
            {
                return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
            }
        }
    }

}