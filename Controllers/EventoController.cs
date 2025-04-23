using Examen3.Clases;
using Examen3.Models;
using Natillera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Examen3.Controllers
{
    [RoutePrefix("api/Evento")]
    [Authorize]
    public class EventoController : ApiController
    {
        [HttpGet]
        [Route("ListarEventos")]
        public List<Evento> ListarEventos()
        {
            clsEvento even = new clsEvento();
            return even.ListarEventos();
        }

        [HttpGet]
        [Route("ConsultarEvento")]
        public Evento ConsultarEvento(int ID)
        {
            clsEvento even = new clsEvento();
            return even.ConsultarxID(ID);
        }

        [HttpGet]
        [Route("ConsultarXTipo")]
        public List<Evento> ConsultarXTipo(string tipo)
        {
            clsEvento even = new clsEvento();
            return even.Consultar_EventosxTipo(tipo);
        }

        [HttpGet]
        [Route("ConsultarXFecha")]
        public List<Evento> ConsultarXTipo(DateTime fecha)
        {
            clsEvento even = new clsEvento();
            return even.Consultar_EventosxFecha(fecha);
        }

        [HttpGet]
        [Route("ConsultarXNombre")]
        public List<Evento> ConsultarXNombre(string nombre)
        {
            clsEvento even = new clsEvento();
            return even.Consultar_EventosxNombre(nombre);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Evento evento)
        {
            clsEvento even = new clsEvento();
            even.evento = evento;
            return even.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Evento evento)
        {
            clsEvento even = new clsEvento();
            even.evento = evento;
            return even.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int ID)
        {
            clsEvento even = new clsEvento();
            return even.Eliminar(ID);
        }
    }
}