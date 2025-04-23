using Examen3.Clases;
using Examen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Examen3.Controllers
{
    [RoutePrefix("api/Login")]
    [AllowAnonymous]

    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]

        public IQueryable<LoginRespuesta> Ingresar(Login login)
        {
            clsLogin log = new clsLogin();
            log.login = login;
            return log.Ingresar();
        }
    }

}