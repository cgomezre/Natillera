using Natillera.Clases;
using Natillera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Login = Natillera.Models.Login;

namespace Natillera.Controllers
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